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
            this.dataGridView_ListTrack = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_ListFound = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_ListResult = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtListMediaScanner = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListTrack)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListFound)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListResult)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListMediaScanner)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_ListTrack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Track";
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
            this.dataGridView_ListTrack.Size = new System.Drawing.Size(905, 137);
            this.dataGridView_ListTrack.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_ListFound);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(911, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List found";
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
            this.dataGridView_ListFound.Size = new System.Drawing.Size(905, 137);
            this.dataGridView_ListFound.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.dataGridView_ListResult);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(911, 470);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List result";
            // 
            // dataGridView_ListResult
            // 
            this.dataGridView_ListResult.AllowUserToAddRows = false;
            this.dataGridView_ListResult.AllowUserToDeleteRows = false;
            this.dataGridView_ListResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListResult.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_ListResult.Name = "dataGridView_ListResult";
            this.dataGridView_ListResult.ReadOnly = true;
            this.dataGridView_ListResult.Size = new System.Drawing.Size(905, 188);
            this.dataGridView_ListResult.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtListMediaScanner);
            this.groupBox4.Location = new System.Drawing.Point(6, 210);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(902, 234);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "List By Media Scanner";
            // 
            // dtListMediaScanner
            // 
            this.dtListMediaScanner.AllowUserToAddRows = false;
            this.dtListMediaScanner.AllowUserToDeleteRows = false;
            this.dtListMediaScanner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListMediaScanner.Location = new System.Drawing.Point(6, 19);
            this.dtListMediaScanner.Name = "dtListMediaScanner";
            this.dtListMediaScanner.ReadOnly = true;
            this.dtListMediaScanner.Size = new System.Drawing.Size(890, 209);
            this.dtListMediaScanner.TabIndex = 2;
            // 
            // f_tracklist_compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 782);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "f_tracklist_compare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_tracklist_compare";
            this.Load += new System.EventHandler(this.f_tracklist_compare_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListTrack)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListFound)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListResult)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListMediaScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_ListTrack;
        private System.Windows.Forms.DataGridView dataGridView_ListFound;
        private System.Windows.Forms.DataGridView dataGridView_ListResult;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dtListMediaScanner;
    }
}