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
            this.components = new System.ComponentModel.Container();
            this.dataGridPointMap = new System.Windows.Forms.DataGridView();
            this.preMoveVertexIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postMoveVertexIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetVertexIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offsetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correspondBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxPreMovePmxPath = new System.Windows.Forms.TextBox();
            this.buttonOpenPreMovePmx = new System.Windows.Forms.Button();
            this.buttonGetPostMoveVertexID = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonGetTargetVertexID = new System.Windows.Forms.Button();
            this.buttonGetPreMoveVertexID = new System.Windows.Forms.Button();
            this.contextMenuCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPointMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correspondBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPointMap
            // 
            this.dataGridPointMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPointMap.AutoGenerateColumns = false;
            this.dataGridPointMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPointMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.preMoveVertexIDDataGridViewTextBoxColumn,
            this.postMoveVertexIDDataGridViewTextBoxColumn,
            this.targetVertexIDDataGridViewTextBoxColumn,
            this.offsetDataGridViewTextBoxColumn});
            this.dataGridPointMap.DataSource = this.correspondBindingSource;
            this.dataGridPointMap.Location = new System.Drawing.Point(18, 157);
            this.dataGridPointMap.Name = "dataGridPointMap";
            this.dataGridPointMap.RowTemplate.Height = 21;
            this.dataGridPointMap.Size = new System.Drawing.Size(643, 801);
            this.dataGridPointMap.TabIndex = 0;
            this.dataGridPointMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPointMap_CellClick);
            this.dataGridPointMap.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridPointMap_CellContextMenuStripNeeded);
            this.dataGridPointMap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridPointMap_CellFormatting);
            this.dataGridPointMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridPointMap_KeyDown);
            // 
            // preMoveVertexIDDataGridViewTextBoxColumn
            // 
            this.preMoveVertexIDDataGridViewTextBoxColumn.DataPropertyName = "PreMoveVertexID";
            this.preMoveVertexIDDataGridViewTextBoxColumn.HeaderText = "PreMoveVertexID";
            this.preMoveVertexIDDataGridViewTextBoxColumn.Name = "preMoveVertexIDDataGridViewTextBoxColumn";
            this.preMoveVertexIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // postMoveVertexIDDataGridViewTextBoxColumn
            // 
            this.postMoveVertexIDDataGridViewTextBoxColumn.DataPropertyName = "PostMoveVertexID";
            this.postMoveVertexIDDataGridViewTextBoxColumn.HeaderText = "PostMoveVertexID";
            this.postMoveVertexIDDataGridViewTextBoxColumn.Name = "postMoveVertexIDDataGridViewTextBoxColumn";
            this.postMoveVertexIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // targetVertexIDDataGridViewTextBoxColumn
            // 
            this.targetVertexIDDataGridViewTextBoxColumn.DataPropertyName = "TargetVertexID";
            this.targetVertexIDDataGridViewTextBoxColumn.HeaderText = "TargetVertexID";
            this.targetVertexIDDataGridViewTextBoxColumn.Name = "targetVertexIDDataGridViewTextBoxColumn";
            this.targetVertexIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // offsetDataGridViewTextBoxColumn
            // 
            this.offsetDataGridViewTextBoxColumn.DataPropertyName = "Offset";
            this.offsetDataGridViewTextBoxColumn.HeaderText = "Offset";
            this.offsetDataGridViewTextBoxColumn.Name = "offsetDataGridViewTextBoxColumn";
            this.offsetDataGridViewTextBoxColumn.Width = 150;
            // 
            // correspondBindingSource
            // 
            this.correspondBindingSource.DataSource = typeof(Correspond);
            // 
            // textBoxPreMovePmxPath
            // 
            this.textBoxPreMovePmxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPreMovePmxPath.Location = new System.Drawing.Point(142, 13);
            this.textBoxPreMovePmxPath.Name = "textBoxPreMovePmxPath";
            this.textBoxPreMovePmxPath.ReadOnly = true;
            this.textBoxPreMovePmxPath.Size = new System.Drawing.Size(513, 27);
            this.textBoxPreMovePmxPath.TabIndex = 1;
            // 
            // buttonOpenPreMovePmx
            // 
            this.buttonOpenPreMovePmx.Location = new System.Drawing.Point(12, 13);
            this.buttonOpenPreMovePmx.Name = "buttonOpenPreMovePmx";
            this.buttonOpenPreMovePmx.Size = new System.Drawing.Size(124, 27);
            this.buttonOpenPreMovePmx.TabIndex = 2;
            this.buttonOpenPreMovePmx.Text = "移動前PMX読込";
            this.buttonOpenPreMovePmx.UseVisualStyleBackColor = true;
            this.buttonOpenPreMovePmx.Click += new System.EventHandler(this.buttonOpenPreMovePmx_Click);
            // 
            // buttonGetPostMoveVertexID
            // 
            this.buttonGetPostMoveVertexID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetPostMoveVertexID.Location = new System.Drawing.Point(12, 46);
            this.buttonGetPostMoveVertexID.Name = "buttonGetPostMoveVertexID";
            this.buttonGetPostMoveVertexID.Size = new System.Drawing.Size(643, 31);
            this.buttonGetPostMoveVertexID.TabIndex = 3;
            this.buttonGetPostMoveVertexID.Text = "移動後頂点IDを選択頂点から取得";
            this.buttonGetPostMoveVertexID.UseVisualStyleBackColor = true;
            this.buttonGetPostMoveVertexID.Click += new System.EventHandler(this.buttonGetPostMoveVertexID_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Location = new System.Drawing.Point(18, 964);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(643, 31);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonGetTargetVertexID
            // 
            this.buttonGetTargetVertexID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetTargetVertexID.Location = new System.Drawing.Point(12, 83);
            this.buttonGetTargetVertexID.Name = "buttonGetTargetVertexID";
            this.buttonGetTargetVertexID.Size = new System.Drawing.Size(643, 31);
            this.buttonGetTargetVertexID.TabIndex = 3;
            this.buttonGetTargetVertexID.Text = "移動後頂点の選択された内の最近傍頂点を対象頂点にする";
            this.buttonGetTargetVertexID.UseVisualStyleBackColor = true;
            this.buttonGetTargetVertexID.Click += new System.EventHandler(this.buttonGetTargetVertexID_Click);
            // 
            // buttonGetPreMoveVertexID
            // 
            this.buttonGetPreMoveVertexID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetPreMoveVertexID.Location = new System.Drawing.Point(12, 120);
            this.buttonGetPreMoveVertexID.Name = "buttonGetPreMoveVertexID";
            this.buttonGetPreMoveVertexID.Size = new System.Drawing.Size(643, 31);
            this.buttonGetPreMoveVertexID.TabIndex = 3;
            this.buttonGetPreMoveVertexID.Text = "移動後頂点の近傍頂点から移動前頂点IDを取得";
            this.buttonGetPreMoveVertexID.UseVisualStyleBackColor = true;
            this.buttonGetPreMoveVertexID.Click += new System.EventHandler(this.buttonGetPreMoveVertexID_Click);
            // 
            // contextMenuCell
            // 
            this.contextMenuCell.Name = "contextMenuCell";
            this.contextMenuCell.Size = new System.Drawing.Size(61, 4);
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 1000);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonGetPreMoveVertexID);
            this.Controls.Add(this.buttonGetTargetVertexID);
            this.Controls.Add(this.buttonGetPostMoveVertexID);
            this.Controls.Add(this.buttonOpenPreMovePmx);
            this.Controls.Add(this.textBoxPreMovePmxPath);
            this.Controls.Add(this.dataGridPointMap);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CtrlForm";
            this.Text = "頂点移動量を転写";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.Load += new System.EventHandler(this.CtrlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPointMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correspondBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPointMap;
        private System.Windows.Forms.BindingSource correspondBindingSource;
        private System.Windows.Forms.TextBox textBoxPreMovePmxPath;
        private System.Windows.Forms.Button buttonOpenPreMovePmx;
        private System.Windows.Forms.Button buttonGetPostMoveVertexID;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn preMoveVertexIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postMoveVertexIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetVertexIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn offsetDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonGetTargetVertexID;
        private System.Windows.Forms.Button buttonGetPreMoveVertexID;
        private System.Windows.Forms.ContextMenuStrip contextMenuCell;
    }
}