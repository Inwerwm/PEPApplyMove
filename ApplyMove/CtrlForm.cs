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
using static ApplyMove.ApplyMove;

namespace ApplyMove
{
    public partial class CtrlForm : Form
    {
        IPERunArgs args;
        IPXPmx pmx;

        List<Correspond> cor;

        public CtrlForm(IPERunArgs input)
        {
            InitializeComponent();
            args = input;
            Format();
        }

        public void Format()
        {
            pmx = args.Host.Connector.Pmx.GetCurrentState();
            cor = new List<Correspond>();
            dataGridPointMap.DataSource = cor;
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }
    }

}