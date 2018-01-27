using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1512252
{
    public partial class Scanning : Form
    {
        #region Constructor
        public Scanning()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
        }
        #endregion

        #region Events
        #region backgoundWorker
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Data.listfile.Clear();
                Data.listpath.Clear();
                Data.listpath = Directory.GetFiles(@"C:\Windows\system32", "*.exe", SearchOption.TopDirectoryOnly).ToList();
                backgroundWorker.ReportProgress(100 / 3);
                Data.listpath.AddRange(Directory.GetFiles(@"C:\Program Files", "*.exe", SearchOption.AllDirectories).ToList());
                backgroundWorker.ReportProgress(200 / 3);
                Data.listpath.AddRange(Directory.GetFiles(@"C:\Program Files (x86)", "*.exe", SearchOption.AllDirectories).ToList());
                backgroundWorker.ReportProgress(100);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            foreach (string path in Data.listpath)
            {
                Data.listfile.Add(Path.GetFileName(path).ToLower());
            }
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "Scanning your exe files: " + e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "Configuring...";
            progressBar1.Value = 100;
            int size = Data.listfile.Count * (Data.listfile.Count - 1), i, j;
            for (i = 0; i < Data.listfile.Count - 1; i++)
                for (j = i + 1; j < Data.listfile.Count; j++)
                {
                    if (Data.listfile[i] == Data.listfile[j])
                    {
                        Data.listfile.RemoveAt(j);
                        Data.listpath.RemoveAt(j);
                        size--;
                    }
                }
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        #region backgroundWorker1
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            File.WriteAllText("Database.dat", Data.listpath[0]);
            int i;
            for (i = 1; i < Data.listpath.Count; i++)
            {
                backgroundWorker1.ReportProgress((i * 100) / (Data.listpath.Count - 1));
                File.AppendAllText("Database.dat", Environment.NewLine + Data.listpath[i]);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            MessageBox.Show("Scan completed. Quick Launch is ready to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "Creating database file: " + e.ProgressPercentage.ToString() + "%";
        }
        #endregion

        private void Scanning_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
        #endregion
    }
}
