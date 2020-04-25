using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ApplyMove
{
    public class ApplyMove : PEPluginClass
    {
        public ApplyMove() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "頂点移動量を転写";
            }
        }

        public override string Version
        {
            get
            {
                return "0.0";
            }
        }

        public override string Description
        {
            get
            {
                return "異なるモデルから頂点の移動量を転写する";
            }
        }

        public override IPEPluginOption Option
        {
            get
            {
                // boot時実行, プラグインメニューへの登録, メニュー登録名
                return new PEPluginOption(false, true, "頂点移動量を転写");
            }
        }

        public override void Run(IPERunArgs args)
        {
            try
            {
                if (ctrlForm == null)
                {
                    ctrlForm = new CtrlForm(args);
                    ctrlForm.Visible = true;
                }
                else
                {
                    ctrlForm.Format();
                    ctrlForm.Visible = !ctrlForm.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override void Dispose()
        {
            if (ctrlForm != null)
            {
                ctrlForm.Close();
                ctrlForm = null;
            }
        }

        CtrlForm ctrlForm;
    }

    static class Extentions
    {
        public static float[] ToArray(this V3 v)
        {
            return new float[] { v.X, v.Y, v.Z };
        }
    }
}