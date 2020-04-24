using KdTree;
using KdTree.Math;
using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                if (value != null)
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
            ofd.Filter = "PMXファイル(*.pmx)|*.pmx|すべてのファイル(*.*)|*.*";
            ofd.Title = "移動前材質を含むPMXファイルを選択してください。";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // setterでテキストボックスにディレクトリを出力するためローカルを使う
                var m = args.Host.Builder.Pmx.Pmx();
                m.FromFile(ofd.FileName);
                PmxSourceMaterialPreMove = m;
                SourceMaterialPreMove = null;
                comboBoxSourceMaterialPreMove.SelectedIndex = -1;
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
            if (TargetMaterial == null)
            {
                MessageBox.Show("移動量適用先材質を選択してください。");
                return;
            }

            if (SourceMaterialPostMove == null)
            {
                MessageBox.Show("移動後材質を選択してください。");
                return;
            }

            if (SourceMaterialPreMove == null)
            {
                MessageBox.Show("移動前材質を選択してください。");
                return;
            }

            //移動前材質と移動後材質で面インデックスを元に移動量を取得
            if (SourceMaterialPreMove.Faces.Count != SourceMaterialPostMove.Faces.Count)
            {
                MessageBox.Show("移動前材質の面数と移動後材質の面数が異なるため処理に失敗しました。");
                return;
            }

            var faceCount = SourceMaterialPostMove.Faces.Count;
            var preFaces = SourceMaterialPreMove.Faces;
            var postFaces = SourceMaterialPostMove.Faces;
            var OffsetMap = new Dictionary<(float x, float y, float z), V3>();
            var tree = new KdTree<float, int>(3, new FloatMath(),AddDuplicateBehavior.Stock);
            var failedFaceIndices = new List<int>();
            for (int i = 0; i < faceCount; i++)
            {
                // KdTreeに追加
                tree.Add(preFaces[i].Vertex1.Position.ToArray(), faceCount);
                tree.Add(preFaces[i].Vertex2.Position.ToArray(), faceCount);
                tree.Add(preFaces[i].Vertex3.Position.ToArray(), faceCount);
            }
            for (int i = 0; i < faceCount; i++)
            {
                // <位置,移動量>マップを作成
                var prePos1 = preFaces[i].Vertex1.Position.ToTuple();
                var prePos2 = preFaces[i].Vertex2.Position.ToTuple();
                var prePos3 = preFaces[i].Vertex3.Position.ToTuple();

                // 移動後材質の同じ面に含まれる点について
                // 3つすべてで最近傍点のValueが一致している場合、同じ面に含まれていることを意味する
                var n1 = tree.GetNearestNeighbours(postFaces[i].Vertex1.Position.ToArray(), 1)[0];
                var n2 = tree.GetNearestNeighbours(postFaces[i].Vertex2.Position.ToArray(), 1)[0];
                var n3 = tree.GetNearestNeighbours(postFaces[i].Vertex3.Position.ToArray(), 1)[0];
                // 3点が共有しているValueの数
                var conNo = n1.DupValue.Intersect(n2.DupValue).Intersect(n3.DupValue).Count();

                if(conNo>0)
                {
                    if (!OffsetMap.ContainsKey(prePos1))
                        OffsetMap.Add(prePos1, postFaces[i].Vertex1.Position - n1.Point.ToV3());
                    if (!OffsetMap.ContainsKey(prePos2))
                        OffsetMap.Add(prePos2, postFaces[i].Vertex2.Position - n2.Point.ToV3());
                    if (!OffsetMap.ContainsKey(prePos3))
                        OffsetMap.Add(prePos3, postFaces[i].Vertex3.Position - n3.Point.ToV3());
                }
                else
                {
                    failedFaceIndices.Add(i);
                }
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
                V3 trans = OffsetMap[closest[0].Point.ToTuple()];
                v.Position = v.Position + trans;
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

        public static (float x,float y, float z) ToTuple(this V3 v)
        {
            return (v.X, v.Y, v.Z);
        }

        public static (float x, float y, float z) ToTuple(this float[] v)
        {
            return (v[0], v[1], v[2]);
        }

        public static V3 ToV3(this float[] a)
        {
            return new V3(a[0], a[1], a[2]);
        }
    }
}