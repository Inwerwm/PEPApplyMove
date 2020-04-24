using PEPlugin;
using PEPlugin.Pmx;
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
            //移動前材質と移動量適用先材質で距離を元に対応関係を取得
            //移動量適用先材質の頂点を対応関係から移動
        }
    }
}