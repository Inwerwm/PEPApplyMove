using KdTree;
using KdTree.Math;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ApplyMove
{
    public partial class PreMovePointForm : Form
    {
        IPXPmx pmxPreMove;
        IPXPmx PmxPostMove;
        public IPXPmx PmxPreMove
        {
            get => pmxPreMove;
            set
            {
                pmxPreMove = value;
                if (pmxPreMove != null)
                {
                    textBoxPreMovePmxPath.Text = pmxPreMove.FilePath;
                    listBoxMaterial.Items.Clear();
                    listBoxMaterial.Items.AddRange(value.Material.Select(m => m.Name).ToArray());
                }
            }
        }

        public List<Correspond> Corresponds { get; set; }

        public PreMovePointForm(List<Correspond> corresponds, IPXPmx preMovePmx, IPXPmx postMovePmx)
        {
            InitializeComponent();
            PmxPreMove = preMovePmx;
            PmxPostMove = postMovePmx;
            Corresponds = corresponds;
        }

        private void PreMovePointForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void setPreMoveVertexID(KdTree<float, int> tree)
        {
            foreach (var c in Corresponds)
            {
                c.PreMoveVertexID = tree.GetNearestNeighbours(PmxPostMove.Vertex[c.PostMoveVertexID].Position.ToArray(), 1)[0].Value;
                c.Offset = PmxPostMove.Vertex[c.PostMoveVertexID].Position - PmxPostMove.Vertex[c.PreMoveVertexID].Position;
            }

            using (var writer = new StreamWriter($"SelectedPreMoveVertexID_{DateTime.Now:yyyyMMddHHmmss}.txt", false))
            {
                foreach (var c in Corresponds)
                {
                    writer.WriteLine(c.PreMoveVertexID);
                }
            }
        }

        private void buttonGetFromAll_Click(object sender, System.EventArgs e)
        {
            var tree = new KdTree<float, int>(3, new FloatMath());
            for (int i = 0; i < PmxPreMove.Vertex.Count; i++)
            {
                tree.Add(PmxPreMove.Vertex[i].Position.ToArray(), i);
            }
            setPreMoveVertexID(tree);
        }

        private void buttonGetFromMaterial_Click(object sender, System.EventArgs e)
        {
            List<IPXVertex> materialVertices = new List<IPXVertex>();
            foreach (IPXFace f in PmxPreMove.Material[listBoxMaterial.SelectedIndex].Faces)
            {
                materialVertices.Add(f.Vertex1);
                materialVertices.Add(f.Vertex2);
                materialVertices.Add(f.Vertex3);
            }
            materialVertices.Distinct();

            var tree = new KdTree<float, int>(3, new FloatMath());
            foreach (var v in materialVertices)
            {
                tree.Add(v.Position.ToArray(), PmxPreMove.Vertex.IndexOf(v));
            }

            setPreMoveVertexID(tree);
        }
    }
}
