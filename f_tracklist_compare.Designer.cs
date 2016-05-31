namespace MusicIdentification
{
    partial class f_tracklist_compare
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_ListTrack = new System.Windows.Forms.DataGridView();
            this.dataGridView_ListFound = new System.Windows.Forms.DataGridView();
            this.dataGridView_ListResult = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListFound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_ListTrack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Track";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_ListFound);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(852, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List found";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_ListResult);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(852, 208);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List result";
            // 
            // dataGridView_ListTrack
            // 
            this.dataGridView_ListTrack.AllowUserToAddRows = false;
            this.dataGridView_ListTrack.AllowUserToDeleteRows = false;
            this.dataGridView_ListTrack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ListTrack.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_ListTrack.Name = "dataGridView_ListTrack";
            this.dataGridView_ListTrack.ReadOnly = true;
            this.dataGridView_ListTrack.Size = new System.Drawing.Size(846, 137);
            this.dataGridView_ListTrack.TabIndex = 0;
            // 
            // dataGridView_ListFound
            // 
            this.dataGridView_ListFound.AllowUserToAddRows = false;
            this.dataGridView_ListFound.AllowUserToDeleteRows = false;
            this.dataGridView_ListFound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ListFound.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_ListFound.Name = "dataGridView_ListFound";
            this.dataGridView_ListFound.ReadOnly = true;
            this.dataGridView_ListFound.Size = new System.Drawing.Size(846, 137);
            this.dataGridView_ListFound.TabIndex = 1;
            // 
            // dataGridView_ListResult
            // 
            this.dataGridView_ListResult.AllowUserToAddRows = false;
            this.dataGridView_ListResult.AllowUserToDeleteRows = false;
            this.dataGridView_ListResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ListResult.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_ListResult.Name = "dataGridView_ListResult";
            this.dataGridView_ListResult.ReadOnly = true;
            this.dataGridView_ListResult.Size = new System.Drawing.Size(846, 189);
            this.dataGridView_ListResult.TabIndex = 1;
            // 
            // f_tracklist_compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 520);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "f_tracklist_compare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_tracklist_compare";
            this.Load += new System.EventHandler(this.f_tracklist_compare_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListFound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_ListTrack;
        private System.Windows.Forms.DataGridView dataGridView_ListFound;
        private System.Windows.Forms.DataGridView dataGridView_ListResult;
    }
}