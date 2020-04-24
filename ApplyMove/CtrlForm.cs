using KdTree;
using KdTree.Math;
using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplyMove
{
    public partial class CtrlForm : Form
    {
        IPERunArgs args;
        IPXPmx pmx;
        private IPXMaterial targetMaterial;
        private IPXMaterial sourceMaterialPostMove;
        private IPXPmx pmxSourceMaterialPreMove;

        IPXPmx PmxSourceMaterialPreMove
        {
            get => pmxSourceMaterialPreMove;
            set
            {
                pmxSourceMaterialPreMove = value;
                textBoxSourceMaterialPreMovePmxPath.Text = value == null ? "" : value.FilePath;
                comboBoxSourceMaterialPreMove.Items.Clear();
                comboBoxSourceMaterialPreMove.Items.AddRange(pmxSourceMaterialPreMove.Material.Select(m => m.Name).ToArray());
            }
        }
        IPXMaterial TargetMaterial
        {
            get => targetMaterial;
            set
            {
                targetMaterial = value;
                textBoxTargetMaterial.Text = value == null ? "" : value.Name;
            }
        }
        IPXMaterial SourceMaterialPreMove
        {
            get;
            set;
        }
        IPXMaterial SourceMaterialPostMove
        {
            get => sourceMaterialPostMove;
            set
            {
                sourceMaterialPostMove = value;
                textBoxSourceMaterialPostMove.Text = value == null ? "" : value.Name;
            }
        }

        public CtrlForm(IPERunArgs input)
        {
            InitializeComponent();
            args = input;
            Format();
        }

        public void Format()
        {
            pmx = args.Host.Connector.Pmx.GetCurrentState();
            listBoxMaterial.Items.Clear();
            listBoxMaterial.Items.AddRange(pmx.Material.Select(m => m.Name).ToArray());
            TargetMaterial = null;
            SourceMaterialPostMove = null;
            SourceMaterialPreMove = null;
            PmxSourceMaterialPreMove = null;
            comboBoxSourceMaterialPreMove.Items.Clear();
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void buttonSetTargetMaterial_Click(object sender, EventArgs e)
        {
            if (listBoxMaterial.SelectedIndex < 0)
                return;

            TargetMaterial = pmx.Material[listBoxMaterial.SelectedIndex];
        }

        private void buttonSetSourceMaterialPostMove_Click(object sender, EventArgs e)
        {
            if (listBoxMaterial.SelectedIndex < 0)
                return;

            SourceMaterialPostMove = pmx.Material[listBoxMaterial.SelectedIndex];
        }

        private void buttonOpenSourceMaterialPreMove_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PMXファイル(*.pmx)|*.pmx;すべてのファイル(*.*)|*.*";
            ofd.Title = "移動前材質を含むPMXファイルを選択してください。";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // setterでテキストボックスにディレクトリを出力するためローカルを使う
                var m = args.Host.Builder.Pmx.Pmx();
                m.FromFile(ofd.FileName);
                PmxSourceMaterialPreMove = m;
            }
        }

        private void comboBoxSourceMaterialPreMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = sender as ComboBox;
            if (s.SelectedIndex < 0)
            {
                SourceMaterialPreMove = null;
                return;
            }

            SourceMaterialPreMove = PmxSourceMaterialPreMove.Material[s.SelectedIndex];
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            Format();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if(TargetMaterial == null)
            {
                MessageBox.Show("移動量適用先材質を選択してください。");
                return;
            }

            if(SourceMaterialPostMove == null)
            {
                MessageBox.Show("移動後材質を選択してください。");
                return;
            }

            if(SourceMaterialPreMove == null)
            {
                MessageBox.Show("移動前材質を選択してください。");
                return;
            }

            //移動前材質と移動後材質で面インデックスを元に移動量を取得
            if(SourceMaterialPreMove.Faces.Count != SourceMaterialPostMove.Faces.Count)
            {
                MessageBox.Show("移動前材質の面数と移動後材質の面数が異なるため処理に失敗しました。");
                return;
            }

            var faceCount = SourceMaterialPostMove.Faces.Count;
            var preFaces = SourceMaterialPreMove.Faces;
            var postFaces = SourceMaterialPostMove.Faces;
            var OffsetMap = new Dictionary<float[], V3>();
            var tree = new KdTree<float, int>(3,new FloatMath());
            for (int i = 0; i < faceCount; i++)
            {
                // <位置,移動量>マップを作成
                if (!OffsetMap.ContainsKey(preFaces[i].Vertex1.Position.ToArray()))
                    OffsetMap.Add(preFaces[i].Vertex1.Position.ToArray(), postFaces[i].Vertex1.Position - preFaces[i].Vertex1.Position);
                if (!OffsetMap.ContainsKey(preFaces[i].Vertex2.Position.ToArray()))
                    OffsetMap.Add(preFaces[i].Vertex2.Position.ToArray(), postFaces[i].Vertex2.Position - preFaces[i].Vertex2.Position);
                if (!OffsetMap.ContainsKey(preFaces[i].Vertex3.Position.ToArray()))
                    OffsetMap.Add(preFaces[i].Vertex3.Position.ToArray(), postFaces[i].Vertex3.Position - preFaces[i].Vertex3.Position);

                // KdTreeに追加
                tree.Add(preFaces[i].Vertex1.Position.ToArray(), faceCount * 3);
                tree.Add(preFaces[i].Vertex2.Position.ToArray(), faceCount * 3 + 1);
                tree.Add(preFaces[i].Vertex3.Position.ToArray(), faceCount * 3 + 2);
            }

            
            var Vertices = new List<IPXVertex>();
            foreach (var f in TargetMaterial.Faces)
            {
                Vertices.Add(f.Vertex1);
                Vertices.Add(f.Vertex2);
                Vertices.Add(f.Vertex3);
            }
            Vertices.Distinct();

            //移動前材質と移動量適用先材質で距離を元に対応関係を取得
            //移動量適用先材質の頂点を対応関係から移動
            foreach (var v in Vertices)
            {
                var closest = tree.GetNearestNeighbours(v.Position.ToArray(), 1);
                v.Position += OffsetMap[closest[0].Point];
            }

            Utility.Update(args.Host.Connector, pmx, PmxUpdateObject.Vertex);
            MessageBox.Show("完了");
        }
    }

    static class Extentions
    {
        public static float[] ToArray(this V3 v)
        {
            return new float[] { v.X, v.Y, v.Z };
        }

        public static V3 ToV3(this float[] a)
        {
            return new V3(a[0], a[1], a[2]);
        }
    }
}