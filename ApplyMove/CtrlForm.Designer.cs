namespace ApplyMove
{
    partial class CtrlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxMaterial = new System.Windows.Forms.ListBox();
            this.buttonSetTargetMaterial = new System.Windows.Forms.Button();
            this.buttonSetSourceMaterialPostMove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSourceMaterialPostMove = new System.Windows.Forms.TextBox();
            this.buttonOpenSourceMaterialPreMove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSourceMaterialPreMovePmxPath = new System.Windows.Forms.TextBox();
            this.textBoxTargetMaterial = new System.Windows.Forms.TextBox();
            this.comboBoxSourceMaterialPreMove = new System.Windows.Forms.ComboBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxMaterial
            // 
            this.listBoxMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxMaterial.FormattingEnabled = true;
            this.listBoxMaterial.ItemHeight = 20;
            this.listBoxMaterial.Location = new System.Drawing.Point(13, 14);
            this.listBoxMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxMaterial.Name = "listBoxMaterial";
            this.listBoxMaterial.Size = new System.Drawing.Size(239, 344);
            this.listBoxMaterial.TabIndex = 0;
            // 
            // buttonSetTargetMaterial
            // 
            this.buttonSetTargetMaterial.Location = new System.Drawing.Point(263, 37);
            this.buttonSetTargetMaterial.Name = "buttonSetTargetMaterial";
            this.buttonSetTargetMaterial.Size = new System.Drawing.Size(115, 36);
            this.buttonSetTargetMaterial.TabIndex = 1;
            this.buttonSetTargetMaterial.Text = ">>";
            this.buttonSetTargetMaterial.UseVisualStyleBackColor = true;
            this.buttonSetTargetMaterial.Click += new System.EventHandler(this.buttonSetTargetMaterial_Click);
            // 
            // buttonSetSourceMaterialPostMove
            // 
            this.buttonSetSourceMaterialPostMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSetSourceMaterialPostMove.Location = new System.Drawing.Point(263, 209);
            this.buttonSetSourceMaterialPostMove.Name = "buttonSetSourceMaterialPostMove";
            this.buttonSetSourceMaterialPostMove.Size = new System.Drawing.Size(115, 36);
            this.buttonSetSourceMaterialPostMove.TabIndex = 1;
            this.buttonSetSourceMaterialPostMove.Text = ">>";
            this.buttonSetSourceMaterialPostMove.UseVisualStyleBackColor = true;
            this.buttonSetSourceMaterialPostMove.Click += new System.EventHandler(this.buttonSetSourceMaterialPostMove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "移動量適用先材質";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "移動後材質";
            // 
            // textBoxSourceMaterialPostMove
            // 
            this.textBoxSourceMaterialPostMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceMaterialPostMove.Location = new System.Drawing.Point(384, 214);
            this.textBoxSourceMaterialPostMove.Name = "textBoxSourceMaterialPostMove";
            this.textBoxSourceMaterialPostMove.ReadOnly = true;
            this.textBoxSourceMaterialPostMove.Size = new System.Drawing.Size(388, 27);
            this.textBoxSourceMaterialPostMove.TabIndex = 4;
            // 
            // buttonOpenSourceMaterialPreMove
            // 
            this.buttonOpenSourceMaterialPreMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenSourceMaterialPreMove.Location = new System.Drawing.Point(263, 288);
            this.buttonOpenSourceMaterialPreMove.Name = "buttonOpenSourceMaterialPreMove";
            this.buttonOpenSourceMaterialPreMove.Size = new System.Drawing.Size(115, 36);
            this.buttonOpenSourceMaterialPreMove.TabIndex = 5;
            this.buttonOpenSourceMaterialPreMove.Text = "開く";
            this.buttonOpenSourceMaterialPreMove.UseVisualStyleBackColor = true;
            this.buttonOpenSourceMaterialPreMove.Click += new System.EventHandler(this.buttonOpenSourceMaterialPreMove_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "移動前材質";
            // 
            // textBoxSourceMaterialPreMovePmxPath
            // 
            this.textBoxSourceMaterialPreMovePmxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceMaterialPreMovePmxPath.Location = new System.Drawing.Point(384, 293);
            this.textBoxSourceMaterialPreMovePmxPath.Name = "textBoxSourceMaterialPreMovePmxPath";
            this.textBoxSourceMaterialPreMovePmxPath.ReadOnly = true;
            this.textBoxSourceMaterialPreMovePmxPath.Size = new System.Drawing.Size(388, 27);
            this.textBoxSourceMaterialPreMovePmxPath.TabIndex = 4;
            // 
            // textBoxTargetMaterial
            // 
            this.textBoxTargetMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetMaterial.Location = new System.Drawing.Point(384, 42);
            this.textBoxTargetMaterial.Name = "textBoxTargetMaterial";
            this.textBoxTargetMaterial.ReadOnly = true;
            this.textBoxTargetMaterial.Size = new System.Drawing.Size(388, 27);
            this.textBoxTargetMaterial.TabIndex = 4;
            // 
            // comboBoxSourceMaterialPreMove
            // 
            this.comboBoxSourceMaterialPreMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSourceMaterialPreMove.FormattingEnabled = true;
            this.comboBoxSourceMaterialPreMove.Location = new System.Drawing.Point(263, 330);
            this.comboBoxSourceMaterialPreMove.Name = "comboBoxSourceMaterialPreMove";
            this.comboBoxSourceMaterialPreMove.Size = new System.Drawing.Size(509, 28);
            this.comboBoxSourceMaterialPreMove.TabIndex = 6;
            this.comboBoxSourceMaterialPreMove.SelectedIndexChanged += new System.EventHandler(this.comboBoxSourceMaterialPreMove_SelectedIndexChanged);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Location = new System.Drawing.Point(263, 366);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(509, 37);
            this.buttonRun.TabIndex = 7;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonReload
            // 
            this.buttonReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReload.Location = new System.Drawing.Point(13, 366);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(239, 37);
            this.buttonReload.TabIndex = 8;
            this.buttonReload.Text = "再読込";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.comboBoxSourceMaterialPreMove);
            this.Controls.Add(this.buttonOpenSourceMaterialPreMove);
            this.Controls.Add(this.textBoxTargetMaterial);
            this.Controls.Add(this.textBoxSourceMaterialPreMovePmxPath);
            this.Controls.Add(this.textBoxSourceMaterialPostMove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSetSourceMaterialPostMove);
            this.Controls.Add(this.buttonSetTargetMaterial);
            this.Controls.Add(this.listBoxMaterial);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(500, 377);
            this.Name = "CtrlForm";
            this.Text = "材質の頂点移動量を転写";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMaterial;
        private System.Windows.Forms.Button buttonSetTargetMaterial;
        private System.Windows.Forms.Button buttonSetSourceMaterialPostMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSourceMaterialPostMove;
        private System.Windows.Forms.Button buttonOpenSourceMaterialPreMove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSourceMaterialPreMovePmxPath;
        private System.Windows.Forms.TextBox textBoxTargetMaterial;
        private System.Windows.Forms.ComboBox comboBoxSourceMaterialPreMove;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonReload;
    }
}