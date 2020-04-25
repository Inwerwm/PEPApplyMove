namespace ApplyMove
{
    partial class PreMovePointForm
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
            this.textBoxPreMovePmxPath = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.tabMaterial = new System.Windows.Forms.TabPage();
            this.listBoxMaterial = new System.Windows.Forms.ListBox();
            this.buttonGetFromMaterial = new System.Windows.Forms.Button();
            this.buttonGetFromAll = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPreMovePmxPath
            // 
            this.textBoxPreMovePmxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPreMovePmxPath.Location = new System.Drawing.Point(13, 14);
            this.textBoxPreMovePmxPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPreMovePmxPath.Name = "textBoxPreMovePmxPath";
            this.textBoxPreMovePmxPath.ReadOnly = true;
            this.textBoxPreMovePmxPath.Size = new System.Drawing.Size(436, 27);
            this.textBoxPreMovePmxPath.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabAll);
            this.tabControl.Controls.Add(this.tabMaterial);
            this.tabControl.Location = new System.Drawing.Point(13, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(437, 577);
            this.tabControl.TabIndex = 5;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.buttonGetFromAll);
            this.tabAll.Location = new System.Drawing.Point(4, 29);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(429, 544);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "全体から取得";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // tabMaterial
            // 
            this.tabMaterial.Controls.Add(this.buttonGetFromMaterial);
            this.tabMaterial.Controls.Add(this.listBoxMaterial);
            this.tabMaterial.Location = new System.Drawing.Point(4, 29);
            this.tabMaterial.Name = "tabMaterial";
            this.tabMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaterial.Size = new System.Drawing.Size(429, 544);
            this.tabMaterial.TabIndex = 1;
            this.tabMaterial.Text = "材質から取得";
            this.tabMaterial.UseVisualStyleBackColor = true;
            // 
            // listBoxMaterial
            // 
            this.listBoxMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMaterial.FormattingEnabled = true;
            this.listBoxMaterial.ItemHeight = 20;
            this.listBoxMaterial.Location = new System.Drawing.Point(6, 6);
            this.listBoxMaterial.Name = "listBoxMaterial";
            this.listBoxMaterial.Size = new System.Drawing.Size(417, 484);
            this.listBoxMaterial.TabIndex = 0;
            // 
            // buttonGetFromMaterial
            // 
            this.buttonGetFromMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetFromMaterial.Location = new System.Drawing.Point(6, 496);
            this.buttonGetFromMaterial.Name = "buttonGetFromMaterial";
            this.buttonGetFromMaterial.Size = new System.Drawing.Size(417, 44);
            this.buttonGetFromMaterial.TabIndex = 1;
            this.buttonGetFromMaterial.Text = "取得";
            this.buttonGetFromMaterial.UseVisualStyleBackColor = true;
            this.buttonGetFromMaterial.Click += new System.EventHandler(this.buttonGetFromMaterial_Click);
            // 
            // buttonGetFromAll
            // 
            this.buttonGetFromAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetFromAll.Location = new System.Drawing.Point(6, 496);
            this.buttonGetFromAll.Name = "buttonGetFromAll";
            this.buttonGetFromAll.Size = new System.Drawing.Size(413, 44);
            this.buttonGetFromAll.TabIndex = 2;
            this.buttonGetFromAll.Text = "取得";
            this.buttonGetFromAll.UseVisualStyleBackColor = true;
            this.buttonGetFromAll.Click += new System.EventHandler(this.buttonGetFromAll_Click);
            // 
            // PreMovePointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 638);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.textBoxPreMovePmxPath);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PreMovePointForm";
            this.Text = "移動後頂点の近傍頂点から移動前頂点IDを取得";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreMovePointForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabMaterial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPreMovePmxPath;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.Button buttonGetFromAll;
        private System.Windows.Forms.TabPage tabMaterial;
        private System.Windows.Forms.Button buttonGetFromMaterial;
        private System.Windows.Forms.ListBox listBoxMaterial;
    }
}