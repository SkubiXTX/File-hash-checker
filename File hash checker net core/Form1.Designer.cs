namespace File_hash_checker_net_core
{
    partial class frmOknoGl
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bgwObliczHashe = new System.ComponentModel.BackgroundWorker();
            btnOtworz = new Button();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnFolder = new Button();
            dgwHashe = new DataGridView();
            colPlik = new DataGridViewTextBoxColumn();
            colMD5 = new DataGridViewTextBoxColumn();
            colSHA1 = new DataGridViewTextBoxColumn();
            colSHA256 = new DataGridViewTextBoxColumn();
            lblFolder = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            ttslLicznik = new ToolStripStatusLabel();
            txtHashWklejony = new TextBox();
            cmbHashe = new ComboBox();
            btnPorownaj = new Button();
            bgwFolder1 = new System.ComponentModel.BackgroundWorker();
            bgwFolder2 = new System.ComponentModel.BackgroundWorker();
            btnZapisz = new Button();
            saveFileDialog1 = new SaveFileDialog();
            btnOtwZapHash = new Button();
            groupBox1 = new GroupBox();
            rdbSHA256 = new RadioButton();
            rdbSHA1 = new RadioButton();
            rdbMD5 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgwHashe).BeginInit();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // bgwObliczHashe
            // 
            bgwObliczHashe.DoWork += bgwObliczHashe_DoWork;
            bgwObliczHashe.ProgressChanged += bgwObliczHashe_ProgressChanged;
            bgwObliczHashe.RunWorkerCompleted += bgwObliczHashe_RunWorkerCompleted;
            // 
            // btnOtworz
            // 
            btnOtworz.Location = new Point(10, 9);
            btnOtworz.Margin = new Padding(3, 2, 3, 2);
            btnOtworz.Name = "btnOtworz";
            btnOtworz.Size = new Size(97, 22);
            btnOtworz.TabIndex = 0;
            btnOtworz.Text = "Wybierz Plik";
            btnOtworz.UseVisualStyleBackColor = true;
            btnOtworz.Click += btnOtworz_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFolder
            // 
            btnFolder.Location = new Point(113, 9);
            btnFolder.Margin = new Padding(3, 2, 3, 2);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(108, 22);
            btnFolder.TabIndex = 1;
            btnFolder.Text = "WybierzFolder";
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // dgwHashe
            // 
            dgwHashe.AllowUserToAddRows = false;
            dgwHashe.AllowUserToDeleteRows = false;
            dgwHashe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwHashe.Columns.AddRange(new DataGridViewColumn[] { colPlik, colMD5, colSHA1, colSHA256 });
            dgwHashe.Location = new Point(10, 35);
            dgwHashe.Margin = new Padding(3, 2, 3, 2);
            dgwHashe.Name = "dgwHashe";
            dgwHashe.ReadOnly = true;
            dgwHashe.RowHeadersWidth = 51;
            dgwHashe.RowTemplate.Height = 29;
            dgwHashe.Size = new Size(1071, 370);
            dgwHashe.TabIndex = 2;
            dgwHashe.CellContentClick += dgwHashe_CellContentClick;
            // 
            // colPlik
            // 
            colPlik.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPlik.HeaderText = "Plik";
            colPlik.MinimumWidth = 20;
            colPlik.Name = "colPlik";
            colPlik.ReadOnly = true;
            colPlik.Width = 300;
            // 
            // colMD5
            // 
            colMD5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colMD5.HeaderText = "MD5";
            colMD5.MinimumWidth = 6;
            colMD5.Name = "colMD5";
            colMD5.ReadOnly = true;
            colMD5.Width = 57;
            // 
            // colSHA1
            // 
            colSHA1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colSHA1.HeaderText = "SHA1";
            colSHA1.MinimumWidth = 6;
            colSHA1.Name = "colSHA1";
            colSHA1.ReadOnly = true;
            colSHA1.Width = 61;
            // 
            // colSHA256
            // 
            colSHA256.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colSHA256.HeaderText = "SHA256";
            colSHA256.MinimumWidth = 6;
            colSHA256.Name = "colSHA256";
            colSHA256.ReadOnly = true;
            colSHA256.Width = 73;
            // 
            // lblFolder
            // 
            lblFolder.AutoSize = true;
            lblFolder.Location = new Point(611, 12);
            lblFolder.Name = "lblFolder";
            lblFolder.Size = new Size(38, 15);
            lblFolder.TabIndex = 3;
            lblFolder.Text = "folder";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1, ttslLicznik });
            statusStrip1.Location = new Point(0, 445);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(1092, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(62, 17);
            toolStripStatusLabel1.Text = "Obliczanie";
            toolStripStatusLabel1.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(350, 16);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Visible = false;
            // 
            // ttslLicznik
            // 
            ttslLicznik.Name = "ttslLicznik";
            ttslLicznik.Size = new Size(24, 17);
            ttslLicznik.Text = "0/0";
            ttslLicznik.Visible = false;
            // 
            // txtHashWklejony
            // 
            txtHashWklejony.Location = new Point(10, 411);
            txtHashWklejony.Margin = new Padding(3, 2, 3, 2);
            txtHashWklejony.Name = "txtHashWklejony";
            txtHashWklejony.Size = new Size(608, 23);
            txtHashWklejony.TabIndex = 6;
            // 
            // cmbHashe
            // 
            cmbHashe.FormattingEnabled = true;
            cmbHashe.Items.AddRange(new object[] { "MD5", "SHA1", "SHA256" });
            cmbHashe.Location = new Point(623, 410);
            cmbHashe.Margin = new Padding(3, 2, 3, 2);
            cmbHashe.Name = "cmbHashe";
            cmbHashe.Size = new Size(133, 23);
            cmbHashe.TabIndex = 7;
            // 
            // btnPorownaj
            // 
            btnPorownaj.Location = new Point(760, 410);
            btnPorownaj.Margin = new Padding(3, 2, 3, 2);
            btnPorownaj.Name = "btnPorownaj";
            btnPorownaj.Size = new Size(82, 22);
            btnPorownaj.TabIndex = 8;
            btnPorownaj.Text = "Porównaj";
            btnPorownaj.UseVisualStyleBackColor = true;
            btnPorownaj.Click += btnPorownaj_Click;
            // 
            // bgwFolder1
            // 
            bgwFolder1.DoWork += bgwFolder1_DoWork;
            bgwFolder1.RunWorkerCompleted += bgwFolder1_RunWorkerCompleted;
            // 
            // bgwFolder2
            // 
            bgwFolder2.DoWork += bgwFolder2_DoWork;
            bgwFolder2.RunWorkerCompleted += bgwFolder2_RunWorkerCompleted;
            // 
            // btnZapisz
            // 
            btnZapisz.Location = new Point(227, 9);
            btnZapisz.Margin = new Padding(3, 2, 3, 2);
            btnZapisz.Name = "btnZapisz";
            btnZapisz.Size = new Size(82, 22);
            btnZapisz.TabIndex = 9;
            btnZapisz.Text = "Zapisz";
            btnZapisz.UseVisualStyleBackColor = true;
            btnZapisz.Click += btnZapisz_Click;
            // 
            // btnOtwZapHash
            // 
            btnOtwZapHash.Location = new Point(314, 9);
            btnOtwZapHash.Margin = new Padding(3, 2, 3, 2);
            btnOtwZapHash.Name = "btnOtwZapHash";
            btnOtwZapHash.Size = new Size(82, 22);
            btnOtwZapHash.TabIndex = 10;
            btnOtwZapHash.Text = "Otwórz";
            btnOtwZapHash.UseVisualStyleBackColor = true;
            btnOtwZapHash.Click += btnOtwZapHash_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbSHA256);
            groupBox1.Controls.Add(rdbSHA1);
            groupBox1.Controls.Add(rdbMD5);
            groupBox1.Location = new Point(402, -2);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(204, 32);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hashe";
            // 
            // rdbSHA256
            // 
            rdbSHA256.AutoSize = true;
            rdbSHA256.Location = new Point(129, 12);
            rdbSHA256.Margin = new Padding(3, 2, 3, 2);
            rdbSHA256.Name = "rdbSHA256";
            rdbSHA256.Size = new Size(66, 19);
            rdbSHA256.TabIndex = 2;
            rdbSHA256.Text = "SHA256";
            rdbSHA256.UseVisualStyleBackColor = true;
            // 
            // rdbSHA1
            // 
            rdbSHA1.AutoSize = true;
            rdbSHA1.Location = new Point(65, 12);
            rdbSHA1.Margin = new Padding(3, 2, 3, 2);
            rdbSHA1.Name = "rdbSHA1";
            rdbSHA1.Size = new Size(54, 19);
            rdbSHA1.TabIndex = 1;
            rdbSHA1.Text = "SHA1";
            rdbSHA1.UseVisualStyleBackColor = true;
            // 
            // rdbMD5
            // 
            rdbMD5.AutoSize = true;
            rdbMD5.Checked = true;
            rdbMD5.Location = new Point(5, 12);
            rdbMD5.Margin = new Padding(3, 2, 3, 2);
            rdbMD5.Name = "rdbMD5";
            rdbMD5.Size = new Size(50, 19);
            rdbMD5.TabIndex = 0;
            rdbMD5.TabStop = true;
            rdbMD5.Text = "MD5";
            rdbMD5.UseVisualStyleBackColor = true;
            rdbMD5.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // frmOknoGl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 467);
            Controls.Add(groupBox1);
            Controls.Add(btnOtwZapHash);
            Controls.Add(btnZapisz);
            Controls.Add(btnPorownaj);
            Controls.Add(cmbHashe);
            Controls.Add(txtHashWklejony);
            Controls.Add(statusStrip1);
            Controls.Add(lblFolder);
            Controls.Add(dgwHashe);
            Controls.Add(btnFolder);
            Controls.Add(btnOtworz);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmOknoGl";
            Text = "Form1";
            Load += frmOknoGl_Load;
            ((System.ComponentModel.ISupportInitialize)dgwHashe).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwObliczHashe;
        private Button btnOtworz;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnFolder;
        private DataGridView dgwHashe;
        private Label lblFolder;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox txtHashWklejony;
        private ComboBox cmbHashe;
        private Button btnPorownaj;
        private System.ComponentModel.BackgroundWorker bgwFolder1;
        private System.ComponentModel.BackgroundWorker bgwFolder2;
        private DataGridViewTextBoxColumn colPlik;
        private DataGridViewTextBoxColumn colMD5;
        private DataGridViewTextBoxColumn colSHA1;
        private DataGridViewTextBoxColumn colSHA256;
        private ToolStripStatusLabel ttslLicznik;
        private Button btnZapisz;
        private SaveFileDialog saveFileDialog1;
        private Button btnOtwZapHash;
        private GroupBox groupBox1;
        private RadioButton rdbMD5;
        private RadioButton rdbSHA256;
        private RadioButton rdbSHA1;
    }
}