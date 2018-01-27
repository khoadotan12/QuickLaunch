using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1512252
{
    public partial class CreatingDatabase : Form
    {
        #region Constructor
        public CreatingDatabase()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
        }
        #endregion

        #region Events
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
            MessageBox.Show("Database file was updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "Completed: " + e.ProgressPercentage.ToString() + "%";
        }
        #endregion

        private void CreatingDatabase_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion
    }
}
