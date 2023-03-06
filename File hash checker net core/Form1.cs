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

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        static string CalculateSHA1(string filename)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        static string CalculateSHA256(string filename)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
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
                var file = new FileInfo(plik);

                using (FileStream fs = new FileStream(plik, FileMode.Open, FileAccess.Read))
                {
                    SHA256 sha256 = SHA256.Create();
                    Byte[] buffer = sha256.ComputeHash(fs);
                    sha256.Clear();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        sb.Append(buffer[i].ToString("x2"));
                    }
                    hash256 = CalculateSHA256(plik);

                    hash1 = CalculateSHA1(plik);

                    hashmd5 = CalculateMD5(plik);


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