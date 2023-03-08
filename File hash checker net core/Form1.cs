using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static System.Net.WebRequestMethods;

namespace File_hash_checker_net_core
{
    public partial class frmOknoGl : Form
    {
        private string plik = "";
        private string samplik = "";
        private string folder = "";
        public string hash256 = "", hash1 = "", hashmd5 = "";
        public Int32 licz = 0;
        public Int32 licz2 = 0;
        public string[] fileEntries = new string[10000];
        public string[] fileNames = new string[10000];

        public frmOknoGl()
        {
            InitializeComponent();
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(filename))
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
                using (var stream = System.IO.File.OpenRead(filename))
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
                using (var stream = System.IO.File.OpenRead(filename))
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
                //Debug.WriteLine(plik);
                //Debug.WriteLine(folder);

                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel1.Visible = true;
                bgwObliczHashe.RunWorkerAsync(plik);
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            licz = 0;
            dgwHashe.Rows.Clear();

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folder = folderBrowserDialog1.SelectedPath;
                Debug.WriteLine(folder);
                lblFolder.Text = folder;

                DirectoryInfo info = new DirectoryInfo(folder);

                FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();

                foreach (FileInfo file in files)
                {
                    fileEntries[licz] = folder + "\\" + file.Name;
                    fileNames[licz] = file.Name;
                    licz++;
                }

                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel1.Visible = true;
                ttslLicznik.Visible = true;
                bgwFolder1.RunWorkerAsync(fileEntries[licz2]);

                //Console.Beep();

            }

        }

        private void bgwObliczHashe_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            String filearg = (String)e.Argument;

            if (System.IO.File.Exists(filearg))
            {
                hash256 = CalculateSHA256(filearg);

                hash1 = CalculateSHA1(filearg);

                hashmd5 = CalculateMD5(filearg);
            }

        }

        private void bgwObliczHashe_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //lblFolder.Text = folder;
            dgwHashe.Rows.Add(plik, hashmd5, hash1, hash256);
            toolStripStatusLabel1.Visible = false;
            toolStripProgressBar1.Visible = false;
        }

        private void bgwObliczHashe_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void dgwHashe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPorownaj_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection wybranywiersz = null;
            wybranywiersz = dgwHashe.SelectedRows;

            if (wybranywiersz.Count != 0)
            {
                switch (cmbHashe.SelectedIndex)
                {
                    case 0:
                        if (txtHashWklejony.Text.Equals(wybranywiersz[0].Cells[1].Value.ToString()))
                        {
                            MessageBox.Show("Hash identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Hash nie jest identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case 1:
                        if (txtHashWklejony.Text.Equals(wybranywiersz[0].Cells[2].Value.ToString()))
                        {
                            MessageBox.Show("Hash identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Hash nie jest identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case 2:
                        if (txtHashWklejony.Text.Equals(wybranywiersz[0].Cells[3].Value.ToString()))
                        {
                            MessageBox.Show("Hash identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Hash nie jest identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    default:
                        if (txtHashWklejony.Text.Equals(wybranywiersz[0].Cells[1].Value.ToString()))
                        {
                            MessageBox.Show("Hash identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Hash nie jest identyczny", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Zaznacz ca³y wiersz", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Console.Beep();
        }

        private void frmOknoGl_Load(object sender, EventArgs e)
        {
            cmbHashe.SelectedIndex = 0;
            dgwHashe.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgwHashe.RowTemplate.Height = 96;
        }

        private void bgwFolder1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            String filearg = (String)e.Argument;

            if (System.IO.File.Exists(filearg))
            {
                hash256 = CalculateSHA256(filearg);

                hash1 = CalculateSHA1(filearg);

                hashmd5 = CalculateMD5(filearg);
            }
        }

        private void bgwFolder1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            dgwHashe.Rows.Add(fileNames[licz2], hashmd5, hash1, hash256);
            licz2++;

            if (licz2 < licz)
            {
                ttslLicznik.Text = licz2.ToString() + "/" + licz.ToString();
                bgwFolder2.RunWorkerAsync(fileEntries[licz2]);
            }
            else
            {
                toolStripStatusLabel1.Visible = false;
                toolStripProgressBar1.Visible = false;
                ttslLicznik.Visible = false;
            }

        }

        private void bgwFolder2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            String filearg = (String)e.Argument;

            if (System.IO.File.Exists(filearg))
            {
                hash256 = CalculateSHA256(filearg);

                hash1 = CalculateSHA1(filearg);

                hashmd5 = CalculateMD5(filearg);
            }

        }

        private void bgwFolder2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dgwHashe.Rows.Add(fileNames[licz2], hashmd5, hash1, hash256);
            licz2++;

            if (licz2 < licz)
            {
                ttslLicznik.Text = licz2.ToString() + "/" + licz.ToString();
                bgwFolder1.RunWorkerAsync(fileEntries[licz2]);
            }
            else
            {
                toolStripStatusLabel1.Visible = false;
                toolStripProgressBar1.Visible = false;
                ttslLicznik.Visible = false;
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Plik tekstowy (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = "Wska¿ plik";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int r = 0; r < dgwHashe.RowCount; r++)
                    {
                        for (int c = 0; c < dgwHashe.ColumnCount; c++)
                        {
                            outputFile.WriteLine(dgwHashe.Rows[r].Cells[c].Value.ToString());
                        }
                    }
                }
            }
        }
    }
}