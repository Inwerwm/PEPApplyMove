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
            this.correspondBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonOpenPreMovePmx = new System.Windows.Forms.Button();
            this.buttonGetPostMoveVertexID = new System.Windows.Forms.Button();
            this.preMoveVertexIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postMoveVertexIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offsetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPointMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correspondBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPointMap
            // 
            this.dataGridPointMap.AutoGenerateColumns = false;
            this.dataGridPointMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPointMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.preMoveVertexIDDataGridViewTextBoxColumn,
            this.postMoveVertexIDDataGridViewTextBoxColumn,
            this.offsetDataGridViewTextBoxColumn});
            this.dataGridPointMap.DataSource = this.correspondBindingSource;
            this.dataGridPointMap.Location = new System.Drawing.Point(12, 83);
            this.dataGridPointMap.Name = "dataGridPointMap";
            this.dataGridPointMap.RowTemplate.Height = 21;
            this.dataGridPointMap.Size = new System.Drawing.Size(643, 618);
            this.dataGridPointMap.TabIndex = 0;
            // 
            // correspondBindingSource
            // 
            this.correspondBindingSource.DataSource = typeof(ApplyMove.ApplyMove.Correspond);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(513, 27);
            this.textBox1.TabIndex = 1;
            // 
            // buttonOpenPreMovePmx
            // 
            this.buttonOpenPreMovePmx.Location = new System.Drawing.Point(12, 13);
            this.buttonOpenPreMovePmx.Name = "buttonOpenPreMovePmx";
            this.buttonOpenPreMovePmx.Size = new System.Drawing.Size(124, 27);
            this.buttonOpenPreMovePmx.TabIndex = 2;
            this.buttonOpenPreMovePmx.Text = "移動前PMX読込";
            this.buttonOpenPreMovePmx.UseVisualStyleBackColor = true;
            // 
            // buttonGetPostMoveVertexID
            // 
            this.buttonGetPostMoveVertexID.Location = new System.Drawing.Point(12, 46);
            this.buttonGetPostMoveVertexID.Name = "buttonGetPostMoveVertexID";
            this.buttonGetPostMoveVertexID.Size = new System.Drawing.Size(643, 31);
            this.buttonGetPostMoveVertexID.TabIndex = 3;
            this.buttonGetPostMoveVertexID.Text = "移動後頂点IDを選択頂点から取得";
            this.buttonGetPostMoveVertexID.UseVisualStyleBackColor = true;
            // 
            // preMoveVertexIDDataGridViewTextBoxColumn
            // 
            this.preMoveVertexIDDataGridViewTextBoxColumn.DataPropertyName = "preMoveVertexID";
            this.preMoveVertexIDDataGridViewTextBoxColumn.HeaderText = "移動前頂点ID";
            this.preMoveVertexIDDataGridViewTextBoxColumn.Name = "preMoveVertexIDDataGridViewTextBoxColumn";
            this.preMoveVertexIDDataGridViewTextBoxColumn.Width = 200;
            // 
            // postMoveVertexIDDataGridViewTextBoxColumn
            // 
            this.postMoveVertexIDDataGridViewTextBoxColumn.DataPropertyName = "postMoveVertexID";
            this.postMoveVertexIDDataGridViewTextBoxColumn.HeaderText = "移動後頂点ID";
            this.postMoveVertexIDDataGridViewTextBoxColumn.Name = "postMoveVertexIDDataGridViewTextBoxColumn";
            this.postMoveVertexIDDataGridViewTextBoxColumn.Width = 200;
            // 
            // offsetDataGridViewTextBoxColumn
            // 
            this.offsetDataGridViewTextBoxColumn.DataPropertyName = "offset";
            this.offsetDataGridViewTextBoxColumn.HeaderText = "移動量";
            this.offsetDataGridViewTextBoxColumn.Name = "offsetDataGridViewTextBoxColumn";
            this.offsetDataGridViewTextBoxColumn.Width = 200;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(12, 707);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(643, 31);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 750);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonGetPostMoveVertexID);
            this.Controls.Add(this.buttonOpenPreMovePmx);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridPointMap);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CtrlForm";
            this.Text = "頂点移動量を転写";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPointMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correspondBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPointMap;
        private System.Windows.Forms.BindingSource correspondBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn preMoveVertexIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postMoveVertexIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn offsetDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonOpenPreMovePmx;
        private System.Windows.Forms.Button buttonGetPostMoveVertexID;
        private System.Windows.Forms.Button buttonRun;
    }
}