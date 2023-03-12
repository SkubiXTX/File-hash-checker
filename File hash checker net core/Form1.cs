using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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
            Array.Clear(fileNames, 0, fileNames.Length);
            Array.Clear(fileEntries, 0, fileEntries.Length);

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
            txtHashWklejony.Text = txtHashWklejony.Text.ToLower();

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

            String temp = "";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int r = 0; r < dgwHashe.RowCount; r++)
                    {
                        temp = "";

                        for (int c = 1; c < dgwHashe.ColumnCount; c++)
                        {
                            temp = temp + ";" + dgwHashe.Rows[r].Cells[c].Value.ToString();
                        }

                        outputFile.WriteLine(fileEntries[r] + temp);
                    }
                }
            }

            MessageBox.Show("Plik zosta³ zapisany", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOtwZapHash_Click(object sender, EventArgs e)
        {
            String plikhash = "";
            string[] zawplik = new string[40000];
            Array.Clear(fileNames, 0, fileNames.Length);
            Array.Clear(fileEntries, 0, fileEntries.Length);

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Plik tekstowy (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Wska¿ plik z zapisanymi hashami";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                plikhash = openFileDialog1.FileName;

                using (TextFieldParser csvParser = new TextFieldParser(plikhash))
                {
                    csvParser.CommentTokens = new string[] { "#" };
                    csvParser.SetDelimiters(new string[] { ";" });
                    csvParser.HasFieldsEnclosedInQuotes = false;

                    int i = 0;

                    while (!csvParser.EndOfData)
                    {
                        string[] wiersz = csvParser.ReadFields();
                        String sciezka = Path.GetDirectoryName(wiersz[0]);

                        if (!sciezka.Equals(lblFolder.Text))
                        {
                            MessageBox.Show("Scie¿ka z pliku jest inna ni¿ œciezka akrualnie wybrana", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        if (rdbMD5.Checked == true)
                        {
                            if (wiersz[1].Equals(dgwHashe.Rows[i].Cells[1].Value.ToString()))
                            {
                                dgwHashe.Rows[i].Cells[0].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                dgwHashe.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            }
                        }

                        if (rdbSHA1.Checked == true)
                        {
                            if (wiersz[2].Equals(dgwHashe.Rows[i].Cells[2].Value.ToString()))
                            {
                                dgwHashe.Rows[i].Cells[0].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                dgwHashe.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            }
                        }

                        if (rdbSHA256.Checked == true)
                        {
                            if (wiersz[3].Equals(dgwHashe.Rows[i].Cells[3].Value.ToString()))
                            {
                                dgwHashe.Rows[i].Cells[0].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                dgwHashe.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            }
                        }

                        i++;
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}