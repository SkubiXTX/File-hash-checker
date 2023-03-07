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
            txtHashWklejony = new TextBox();
            cmbHashe = new ComboBox();
            btnPorownaj = new Button();
            ((System.ComponentModel.ISupportInitialize)dgwHashe).BeginInit();
            statusStrip1.SuspendLayout();
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
            btnOtworz.Location = new Point(12, 12);
            btnOtworz.Name = "btnOtworz";
            btnOtworz.Size = new Size(111, 29);
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
            btnFolder.Location = new Point(129, 12);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(124, 29);
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
            dgwHashe.Location = new Point(12, 47);
            dgwHashe.Name = "dgwHashe";
            dgwHashe.ReadOnly = true;
            dgwHashe.RowHeadersWidth = 51;
            dgwHashe.RowTemplate.Height = 29;
            dgwHashe.Size = new Size(1224, 322);
            dgwHashe.TabIndex = 2;
            dgwHashe.CellContentClick += dgwHashe_CellContentClick;
            // 
            // colPlik
            // 
            colPlik.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPlik.HeaderText = "Plik";
            colPlik.MinimumWidth = 6;
            colPlik.Name = "colPlik";
            colPlik.ReadOnly = true;
            colPlik.Width = 61;
            // 
            // colMD5
            // 
            colMD5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colMD5.HeaderText = "MD5";
            colMD5.MinimumWidth = 6;
            colMD5.Name = "colMD5";
            colMD5.ReadOnly = true;
            colMD5.Width = 70;
            // 
            // colSHA1
            // 
            colSHA1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colSHA1.HeaderText = "SHA1";
            colSHA1.MinimumWidth = 6;
            colSHA1.Name = "colSHA1";
            colSHA1.ReadOnly = true;
            colSHA1.Width = 75;
            // 
            // colSHA256
            // 
            colSHA256.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colSHA256.HeaderText = "SHA256";
            colSHA256.MinimumWidth = 6;
            colSHA256.Name = "colSHA256";
            colSHA256.ReadOnly = true;
            colSHA256.Width = 91;
            // 
            // lblFolder
            // 
            lblFolder.AutoSize = true;
            lblFolder.Location = new Point(279, 16);
            lblFolder.Name = "lblFolder";
            lblFolder.Size = new Size(50, 20);
            lblFolder.TabIndex = 3;
            lblFolder.Text = "label1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1248, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(79, 20);
            toolStripStatusLabel1.Text = "Obliczanie";
            toolStripStatusLabel1.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(500, 18);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Visible = false;
            // 
            // txtHashWklejony
            // 
            txtHashWklejony.Location = new Point(12, 387);
            txtHashWklejony.Name = "txtHashWklejony";
            txtHashWklejony.Size = new Size(694, 27);
            txtHashWklejony.TabIndex = 6;
            // 
            // cmbHashe
            // 
            cmbHashe.FormattingEnabled = true;
            cmbHashe.Items.AddRange(new object[] { "MD5", "SHA1", "SHA256" });
            cmbHashe.Location = new Point(712, 386);
            cmbHashe.Name = "cmbHashe";
            cmbHashe.Size = new Size(151, 28);
            cmbHashe.TabIndex = 7;
            // 
            // btnPorownaj
            // 
            btnPorownaj.Location = new Point(869, 385);
            btnPorownaj.Name = "btnPorownaj";
            btnPorownaj.Size = new Size(94, 29);
            btnPorownaj.TabIndex = 8;
            btnPorownaj.Text = "Porównaj";
            btnPorownaj.UseVisualStyleBackColor = true;
            btnPorownaj.Click += btnPorownaj_Click;
            // 
            // frmOknoGl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 450);
            Controls.Add(btnPorownaj);
            Controls.Add(cmbHashe);
            Controls.Add(txtHashWklejony);
            Controls.Add(statusStrip1);
            Controls.Add(lblFolder);
            Controls.Add(dgwHashe);
            Controls.Add(btnFolder);
            Controls.Add(btnOtworz);
            Name = "frmOknoGl";
            Text = "Form1";
            Load += frmOknoGl_Load;
            ((System.ComponentModel.ISupportInitialize)dgwHashe).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private DataGridViewTextBoxColumn colPlik;
        private DataGridViewTextBoxColumn colMD5;
        private DataGridViewTextBoxColumn colSHA1;
        private DataGridViewTextBoxColumn colSHA256;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox txtHashWklejony;
        private ComboBox cmbHashe;
        private Button btnPorownaj;
    }
}