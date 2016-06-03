namespace MusicIdentification
{
    partial class f_Main
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
            this.btnBrowserMediaScanner = new System.Windows.Forms.Button();
            this.txtPathScanner = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbFingerLength = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_process = new System.Windows.Forms.Label();
            this.lbl_end = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFileScanner = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.Ino = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnMediaScanner = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMediaScanner);
            this.groupBox1.Controls.Add(this.btnBrowserMediaScanner);
            this.groupBox1.Controls.Add(this.txtPathScanner);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbFingerLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl_process);
            this.groupBox1.Controls.Add(this.lbl_end);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFileScanner);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.btnIdentify);
            this.groupBox1.Controls.Add(this.Ino);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1027, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // btnBrowserMediaScanner
            // 
            this.btnBrowserMediaScanner.Location = new System.Drawing.Point(937, 24);
            this.btnBrowserMediaScanner.Name = "btnBrowserMediaScanner";
            this.btnBrowserMediaScanner.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserMediaScanner.TabIndex = 19;
            this.btnBrowserMediaScanner.Text = "Browser";
            this.btnBrowserMediaScanner.UseVisualStyleBackColor = true;
            this.btnBrowserMediaScanner.Click += new System.EventHandler(this.btnBrowserMediaScanner_Click);
            // 
            // txtPathScanner
            // 
            this.txtPathScanner.Location = new System.Drawing.Point(666, 25);
            this.txtPathScanner.Name = "txtPathScanner";
            this.txtPathScanner.ReadOnly = true;
            this.txtPathScanner.Size = new System.Drawing.Size(264, 20);
            this.txtPathScanner.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(562, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "File Media Scanner";
            // 
            // cbbFingerLength
            // 
            this.cbbFingerLength.FormattingEnabled = true;
            this.cbbFingerLength.Location = new System.Drawing.Point(342, 80);
            this.cbbFingerLength.Name = "cbbFingerLength";
            this.cbbFingerLength.Size = new System.Drawing.Size(121, 21);
            this.cbbFingerLength.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Fingerprint Length";
            // 
            // lbl_process
            // 
            this.lbl_process.AutoSize = true;
            this.lbl_process.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_process.ForeColor = System.Drawing.Color.Red;
            this.lbl_process.Location = new System.Drawing.Point(469, 80);
            this.lbl_process.Name = "lbl_process";
            this.lbl_process.Size = new System.Drawing.Size(12, 16);
            this.lbl_process.TabIndex = 14;
            this.lbl_process.Text = ".";
            // 
            // lbl_end
            // 
            this.lbl_end.AutoSize = true;
            this.lbl_end.Location = new System.Drawing.Point(505, 29);
            this.lbl_end.Name = "lbl_end";
            this.lbl_end.Size = new System.Drawing.Size(13, 13);
            this.lbl_end.TabIndex = 13;
            this.lbl_end.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fingerprint Interval";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(130, 82);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(946, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Artist Compare ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(808, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Track Compare ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_name
            // 
            this.txt_name.AutoSize = true;
            this.txt_name.Location = new System.Drawing.Point(75, 55);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(0, 13);
            this.txt_name.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File Name:";
            // 
            // btnFileScanner
            // 
            this.btnFileScanner.Location = new System.Drawing.Point(342, 24);
            this.btnFileScanner.Name = "btnFileScanner";
            this.btnFileScanner.Size = new System.Drawing.Size(75, 23);
            this.btnFileScanner.TabIndex = 3;
            this.btnFileScanner.Text = "Browser";
            this.btnFileScanner.UseVisualStyleBackColor = true;
            this.btnFileScanner.Click += new System.EventHandler(this.btnFileScanner_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(71, 25);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(264, 20);
            this.txt_path.TabIndex = 2;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(600, 78);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(75, 23);
            this.btnIdentify.TabIndex = 1;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.buttonIdentify_Click);
            // 
            // Ino
            // 
            this.Ino.AutoSize = true;
            this.Ino.Location = new System.Drawing.Point(12, 28);
            this.Ino.Name = "Ino";
            this.Ino.Size = new System.Drawing.Size(53, 13);
            this.Ino.TabIndex = 0;
            this.Ino.Text = "File Audio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1027, 616);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reponse Information";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1021, 597);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnMediaScanner
            // 
            this.btnMediaScanner.Location = new System.Drawing.Point(681, 78);
            this.btnMediaScanner.Name = "btnMediaScanner";
            this.btnMediaScanner.Size = new System.Drawing.Size(121, 23);
            this.btnMediaScanner.TabIndex = 20;
            this.btnMediaScanner.Text = "Media Scanner";
            this.btnMediaScanner.UseVisualStyleBackColor = true;
            this.btnMediaScanner.Click += new System.EventHandler(this.btnMediaScanner_Click);
            // 
            // f_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 724);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "f_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Identification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_Main_FormClosing);
            this.Load += new System.EventHandler(this.f_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFileScanner;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Label Ino;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lbl_end;
        private System.Windows.Forms.Label lbl_process;
        private System.Windows.Forms.ComboBox cbbFingerLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowserMediaScanner;
        private System.Windows.Forms.TextBox txtPathScanner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMediaScanner;
    }
}

