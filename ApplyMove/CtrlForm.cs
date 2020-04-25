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
        IPXPmx pmxPreMove;

        PreMovePointForm pmpForm = null;

        List<Correspond> cor;

        bool canSelect = true;

        public CtrlForm(IPERunArgs input)
        {
            InitializeComponent();
            args = input;
            Format();
            contextMenuCell.Items.Add("セルに現在の選択頂点を挿入", null, setValueToCurrentCell);
            contextMenuCell.Items.Add("貼り付け", null, PasteMenuItem);
            dataGridPointMap.ContextMenuStrip = contextMenuCell;
        }

        public void Format()
        {
            pmx = args.Host.Connector.Pmx.GetCurrentState();
            cor = new List<Correspond>();
            pmxPreMove = null;
        }

        private V3 calcOffset(int preID, int postID)
        {
            if (pmxPreMove == null)
            {
                MessageBox.Show("移動前PMXファイルを読み込んでください。");
                return null;
            }

            var preVtx = pmxPreMove.Vertex[preID];
            var postVtx = pmx.Vertex[postID];
            return postVtx.Position - preVtx.Position;
        }

        private void PasteMenuItem(object sender, EventArgs e)
        {
            PasteToGrid();
        }

        private void PasteToGrid()
        {
            //現在のセルのある行から下にペーストする
            if (dataGridPointMap.CurrentCell == null)
                return;
            int insertRowIndex = dataGridPointMap.CurrentCell.RowIndex;

            //クリップボードの内容を取得して、行で分ける
            string pasteText = Clipboard.GetText();
            if (string.IsNullOrEmpty(pasteText))
                return;
            pasteText = pasteText.Replace("\r\n", "\n");
            pasteText = pasteText.Replace('\r', '\n');
            pasteText = pasteText.TrimEnd(new char[] { '\n' });
            string[] lines = pasteText.Split('\n');

            foreach (var line in lines)
            {
                string[] vals = line.Split('\t');
                DataGridViewRow row = dataGridPointMap.Rows[insertRowIndex];
                //各セルの値を設定
                foreach ((string s, int i) item in vals.Select((s, i) => (s, dataGridPointMap.CurrentCell.ColumnIndex + i)))
                {
                    if (item.i >= row.Cells.Count)
                        break;
                    row.Cells[item.i].Value = item.s;
                }

                //次の行へ
                insertRowIndex++;
                if (insertRowIndex >= dataGridPointMap.Rows.Count)
                    break;
            }
        }

        private void setValueToCurrentCell(object sender, EventArgs e)
        {
            if (dataGridPointMap.CurrentCell.ColumnIndex == 3) return;
            dataGridPointMap.CurrentCell.Value = args.Host.Connector.View.PmxView.GetSelectedVertexIndices()[0];
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void buttonOpenPreMovePmx_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PMXファイル(*.pmx)|*.pmx|すべてのファイル(*.*)|*.*";
            ofd.Title = "移動前PMXファイルを選択してください。";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pmxPreMove = args.Host.Builder.Pmx.Pmx();
                pmxPreMove.FromFile(ofd.FileName);
                textBoxPreMovePmxPath.Text = pmxPreMove.FilePath;
                if (pmpForm != null)
                {
                    pmpForm.PmxPreMove = pmxPreMove;
                }
            }
        }

        private void buttonGetPostMoveVertexID_Click(object sender, EventArgs e)
        {
            dataGridPointMap.DataSource = null;
            dataGridPointMap.Rows.Clear();
            cor.Clear();
            foreach (var i in args.Host.Connector.View.PmxView.GetSelectedVertexIndices())
            {
                cor.Add(new Correspond(i));
            }
            dataGridPointMap.DataSource = cor;
        }

        private void buttonGetTargetVertexID_Click(object sender, EventArgs e)
        {
            if (cor.Count < 1)
                return;

            int[] selectedVertexIndices = args.Host.Connector.View.PmxView.GetSelectedVertexIndices();
            if (selectedVertexIndices.Count() < 1)
                return;

            // 選択頂点からKdTreeを作る
            var tree = new KdTree<float, int>(3, new FloatMath(), AddDuplicateBehavior.Stock);
            foreach (var i in selectedVertexIndices)
            {
                tree.Add(pmx.Vertex[i].Position.ToArray(), i);
            }

            // 移動後頂点の最近傍点を対象頂点にする
            foreach (var c in cor)
            {
                c.TargetVertexID = tree.GetNearestNeighbours(pmx.Vertex[c.PostMoveVertexID].Position.ToArray(), 1)[0].Value;
            }

            /*
            // 移動後頂点でKdTreeを作る
            var tree = new KdTree<float, Correspond>(3, new FloatMath(), AddDuplicateBehavior.Stock);
            var postPos = cor.Select(c => pmx.Vertex[c.PostMoveVertexID].Position);
            foreach (var c in cor)
            {
                var p = pmx.Vertex[c.PostMoveVertexID].Position;
                tree.Add(new float[] { p.X, p.Y, p.Z }, c);
            }

            // 選択頂点を最も近い移動後頂点の対象頂点に設定
            foreach (var i in selectedVertexIndices)
            {
                var p = pmx.Vertex[i].Position;
                var closest = tree.GetNearestNeighbours(new float[] { p.X, p.Y, p.Z }, 1)[0];
                foreach (var c in closest.DupValue)
                {
                    if (c.TargetVertexID != -1)
                        cor.Add(new Correspond(c));
                    c.TargetVertexID = i;
                }
            }
            */
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (cor.Any(c => c.PreMoveVertexID < 0))
            {
                MessageBox.Show("移動前頂点IDが未指定の行があります。");
                return;
            }
            if (cor.Any(c => c.TargetVertexID < 0))
            {
                MessageBox.Show("移動対象頂点IDが未指定の行があります。");
                return;
            }

            foreach (var item in cor)
            {
                item.Offset = calcOffset(item.PreMoveVertexID, item.PostMoveVertexID);
                pmx.Vertex[item.TargetVertexID].Position += item.Offset;
            }

            Utility.Update(args.Host.Connector, pmx, PmxUpdateObject.Vertex);
            MessageBox.Show("完了");
        }

        private void CtrlForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridPointMap.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void buttonGetPreMoveVertexID_Click(object sender, EventArgs e)
        {
            try
            {
                if (pmpForm == null)
                {
                    pmpForm = new PreMovePointForm(cor, pmxPreMove, pmx);
                    pmpForm.Visible = true;
                }
                else
                {
                    pmpForm.PmxPreMove = pmxPreMove;
                    pmpForm.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridPointMap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!canSelect)
            {
                canSelect = true;
                return;
            }

            if (e.ColumnIndex < 0)
                return;

            if (e.RowIndex < 0)
            {
                // 項目名がクリックされた
                bool isAddMode = ((ModifierKeys & Keys.Shift) == Keys.Shift) || ((ModifierKeys & Keys.Control) == Keys.Control);
                foreach (DataGridViewRow r in dataGridPointMap.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if (isAddMode)
                        {
                            if (c.ColumnIndex == e.ColumnIndex)
                                c.Selected = true;
                        }
                        else
                            c.Selected = c.ColumnIndex == e.ColumnIndex;
                    }
                }
                return;
            }

            if (e.ColumnIndex == 0 || e.ColumnIndex == 3)
                return;

            DataGridViewCell cell = dataGridPointMap.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if ((int)cell.Value < 0)
                return;
            args.Host.Connector.View.PmxView.SetSelectedVertexIndices(new int[] { (int)cell.Value });

            args.Host.Connector.View.PmxView.UpdateView();
        }

        private void dataGridPointMap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var v = e.Value as V3;
                e.Value = $"({v.X}, {v.Y}, {v.Z})";
                e.FormattingApplied = true;
            }
        }

        private void dataGridPointMap_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;

            canSelect = false;
            dataGridPointMap.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            canSelect = true;
        }

        private void dataGridPointMap_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + V 貼り付け
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteToGrid();
            }
        }
    }

    public class Correspond
    {
        public int PreMoveVertexID { get; set; }
        public int PostMoveVertexID { get; set; }
        public int TargetVertexID { get; set; }
        public V3 Offset { get; set; }

        public Correspond(int postID)
        {
            PostMoveVertexID = postID;
            PreMoveVertexID = -1;
            TargetVertexID = -1;
            Offset = new V3();
        }

        public Correspond(Correspond correspond)
        {
            PreMoveVertexID = correspond.PreMoveVertexID;
            PostMoveVertexID = correspond.PostMoveVertexID;
            TargetVertexID = correspond.TargetVertexID;
            Offset = new V3(correspond.Offset);
        }
    }

}