using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace File_hash_checker_net_core
{
    public partial class Form1 : Form
    {
        private string plik = "";
        private string samplik = "";
        private string folder = "";
        public string hash256 = "", hash1 = "", hashmd5 = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOtworz_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Wszystkie pliki (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Wska¿ plik";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                plik = openFileDialog1.FileName;
                folder = System.IO.Path.GetDirectoryName(plik);
                samplik = System.IO.Path.GetFileName(plik);
                Debug.WriteLine(plik);
                Debug.WriteLine(folder);

                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel1.Visible = true;
                bgwObliczHashe.RunWorkerAsync();
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folder = folderBrowserDialog1.SelectedPath;
                Debug.WriteLine(folder);
                lblFolder.Text = folder;

            }

        }

        private void bgwObliczHashe_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            if (File.Exists(plik))
            {

                Byte[] buffer = null;
                var file = new FileInfo(plik);

                using (FileStream fs = new FileStream(plik, FileMode.Open, FileAccess.Read))
                {
                    SHA256 sha256 = SHA256.Create();
                    buffer = sha256.ComputeHash(fs);
                    sha256.Clear();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        sb.Append(buffer[i].ToString("x2"));
                    }
                    hash256 = sb.ToString();

                    SHA1 sha1 = SHA1.Create();
                    buffer = sha1.ComputeHash(fs);
                    sha1.Clear();
                    StringBuilder sb2 = new StringBuilder();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        sb2.Append(buffer[i].ToString("x2"));
                    }
                    hash1 = sb2.ToString();


                    MD5 md5 = MD5.Create();
                    buffer = md5.ComputeHash(fs);
                    md5.Clear();
                    StringBuilder sb3 = new StringBuilder();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        sb3.Append(buffer[i].ToString("x2"));
                    }
                    hashmd5 = sb3.ToString();


                }

            }

        }

        private void bgwObliczHashe_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblFolder.Text = folder;
            dgwHashe.Rows.Add(samplik, hashmd5, hash1, hash256);
            toolStripStatusLabel1.Visible = false;
            toolStripProgressBar1.Visible = false;
        }

        private void bgwObliczHashe_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value += 1;
        }
    }
}