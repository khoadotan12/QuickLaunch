using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using System.Diagnostics;

namespace _1512252
{
    public partial class Form1 : Form
    {
        globalKeyboardHook gkh = new globalKeyboardHook();
        List<int> index = new List<int>();

        #region Functions
        public Form1()
        {
            InitializeComponent();
            txtNoidung.ForeColor = Color.LightGray;
            txtNoidung.Text = "Type here to search";
            this.txtNoidung.Leave += new System.EventHandler(this.txtNoidung_Leave);
            this.txtNoidung.Enter += new System.EventHandler(this.txtNoidung_Enter);
            ntfIcon.ShowBalloonTip(1000);
            gkh.HookedKeys.Add(Keys.Up);
            gkh.HookedKeys.Add(Keys.Control);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.unhook();
            string dat = "RecentApp.dat";
            if (File.Exists(dat))
            {
                using (StreamReader sr = new StreamReader(dat))
                {
                    string line, name, num;
                    while ((line = sr.ReadLine()) != null)
                    {
                        int index = line.IndexOf("\t", 0);
                        name = line.Substring(0, index);
                        num = line.Substring(index + 1);
                        Stats.filename.Add(name);
                        Stats.frequent.Add(Int32.Parse(num));
                    }
                }
            }

        }
        private void StartExeFile(int pos)
        {
            string path = Data.listpath[index[pos]];
            string file = Data.listfile[index[pos]];
            int i = 0, j, k;
            Process.Start(path);
            while (i < Stats.filename.Count)
            {
                if (Stats.filename[i] == file)
                {
                    Stats.frequent[i]++;
                    break;
                }
                i++;
            }
            if (i == Stats.filename.Count)
            {
                Stats.filename.Add(file);
                Stats.frequent.Add(1);
            }
            else //Sort
            {
                string strtemp;
                int itemp;
                for (j = i - 1; j >= 0; j--)
                    if (Stats.frequent[i] > Stats.frequent[j])
                    {
                        strtemp = Stats.filename[i];
                        Stats.filename[i] = Stats.filename[j];
                        Stats.filename[j] = strtemp;
                        itemp = Stats.frequent[i];
                        Stats.frequent[i] = Stats.frequent[j];
                        Stats.frequent[j] = itemp;
                        i = j;
                    }
            }
            for (i = 0; i < txtNoidung.Items.Count; i++)
                if (file == txtNoidung.Items[i].ToString())
                    return;
            txtNoidung.Items.Insert(0, file);
        }
        #endregion

        #region Events

        #region Form1
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                gkh.hook();
                showToolStripMenuItem.Text = "Show";
                showToolStripMenuItem.Image = global::_1512252.Properties.Resources.show;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlrs = MessageBox.Show("Are you sure you want to exit Quick Launch?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlrs == DialogResult.No)
                e.Cancel = true;
            else
            {
                if (Stats.filename.Count > 0)
                {
                    File.WriteAllText("RecentApp.dat", Stats.filename[0] + "\t" + Stats.frequent[0].ToString());
                    for (int i = 1; i < Stats.filename.Count; i++)
                        File.AppendAllText("RecentApp.dat", Environment.NewLine + Stats.filename[i] + "\t" + Stats.frequent[i].ToString());
                }
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            string dat = "Database.dat";
            if (File.Exists(dat))
            {
                using (StreamReader sr = new StreamReader(dat))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Data.listpath.Add(line);
                        Data.listfile.Add(Path.GetFileName(line).ToLower());
                    }
                }
            }
            else
            {
                Scanning scan = new Scanning();
                scan.ShowDialog(this);
            }
        }
        #endregion

        #region GlobalKeyboardHook
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Control)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                e.Handled = true;
                gkh.unhook();
                showToolStripMenuItem.Text = "Hide";
                showToolStripMenuItem.Image = global::_1512252.Properties.Resources.hide;
            }
        }
        #endregion

        #region txtNoidung
        private void txtNoidung_Leave(object sender, EventArgs e)
        {
            if (txtNoidung.Text == "")
            {
                txtNoidung.Text = "Type here to search";
                txtNoidung.ForeColor = Color.Gray;
                btnOK.Enabled = false;
                return;
            }
        }

        private void txtNoidung_Enter(object sender, EventArgs e)
        {
            if (txtNoidung.Text == "Type here to search")
            {
                txtNoidung.Text = "";
                txtNoidung.ForeColor = Color.Black;
            }
        }
        private void txtNoidung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listboxApp.Items.Count > 0)
            {
                e.Handled = true;
                listboxApp.Focus();
                listboxApp.SelectedIndex = 0;
            }
            if (e.KeyCode == Keys.Enter && txtNoidung.Text.Length > 0)
            {
                string name = txtNoidung.Text;
                if (name.Contains(".exe") == false)
                    name += ".exe";
                int i = 0;
                for (; i < listboxApp.Items.Count; i++)
                    if (name == listboxApp.Items[i].ToString())
                    {
                        StartExeFile(i);
                        return;
                    }
                if (i == listboxApp.Items.Count)
                    MessageBox.Show("Quick Launch cannot find '" + txtNoidung.Text + "'. Make sure you typed the name correctly, and then try again.", txtNoidung.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtNoidung_TextChanged(object sender, EventArgs e)
        {
            if (txtNoidung.Text.Length == 0)
            {
                listboxApp.Items.Clear();
                btnOK.Enabled = false;
            }
            if (txtNoidung.Text.Length > 0)
            {
                listboxApp.Items.Clear();
                index.Clear();
                btnOK.Enabled = true;
                string str = txtNoidung.Text.ToLower();
                /*Tim nhung ung dung uu tien*/
                for (int i = 0; i < Stats.filename.Count; i++)
                    if (Stats.filename[i].Contains(str) && Stats.filename[i].IndexOf(str, 0) == 0)
                        listboxApp.Items.Add(Stats.filename[i]);
                int[] temp = new int[listboxApp.Items.Count];
                for (int i = 0; i < Data.listfile.Count; i++)
                {
                    if (listboxApp.Items.Count == index.Count)
                        break;
                    for (int j = 0; j < listboxApp.Items.Count; j++)
                        if (listboxApp.Items[j].ToString() == Data.listfile[i])
                            temp[j] = i;
                }
                for (int i = 0; i < listboxApp.Items.Count; i++)
                    index.Add(temp[i]);
                /*Tim trong database*/
                for (int i = 0; i < Data.listfile.Count; i++)
                {
                    int j = 0;
                    while (j < temp.Length)
                    {
                        if (i == temp[j])
                            break;
                        j++;
                    }
                    if (j < temp.Length)
                        continue;
                    if (Data.listfile[i].Contains(str) && Data.listfile[i].IndexOf(str, 0) == 0)
                    {
                        listboxApp.Items.Add(Data.listfile[i]);
                        index.Add(i);
                    }
                }
            }
        }
        #endregion

        #region contextMenuStrip
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showToolStripMenuItem.Text == "Show")
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                gkh.unhook();
                showToolStripMenuItem.Text = "Hide";
                showToolStripMenuItem.Image = global::_1512252.Properties.Resources.hide;
                return;
            }
            if (showToolStripMenuItem.Text == "Hide")
            {
                this.Hide();
                gkh.hook();
                showToolStripMenuItem.Text = "Show";
                showToolStripMenuItem.Image = global::_1512252.Properties.Resources.show;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ntfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            gkh.unhook();
            showToolStripMenuItem.Text = "Hide";
            showToolStripMenuItem.Image = global::_1512252.Properties.Resources.hide;
        }
        private void viewDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary dict = new Dictionary();
            dict.ShowDialog(this);
        }

        private void scanToBuildDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Dictionary>().Count() == 1)
                Application.OpenForms.OfType<Dictionary>().First().Hide();
            Scanning scan = new Scanning();
            scan.ShowDialog(this);
            if (Application.OpenForms.OfType<Dictionary>().Count() == 1)
                Application.OpenForms.OfType<Dictionary>().First().Close();
        }

        private void viewSaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics stat = new Statistics();
            stat.ShowDialog(this);
        }
        #endregion

        #region listboxApp
        private void listboxApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && listboxApp.SelectedIndex == 0)
            {
                e.Handled = true;
                txtNoidung.Focus();
                listboxApp.SelectedIndex = -1;
            }
            if (e.KeyCode == Keys.Enter && listboxApp.SelectedIndex != -1)
            {
                int pos = listboxApp.SelectedIndex;
                StartExeFile(pos);
            }
        }

        private void listboxApp_DoubleClick(object sender, EventArgs e)
        {
            if (listboxApp.SelectedIndex != -1)
            {
                int pos = listboxApp.SelectedIndex;
                StartExeFile(pos);
            }
        }
        #endregion

        #region btnOK
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listboxApp.SelectedIndex != -1)
            {
                int pos = listboxApp.SelectedIndex;
                StartExeFile(pos);
            }
            else
            {
                string name = txtNoidung.Text;
                if (name.Contains(".exe") == false)
                    name += ".exe";
                int i = 0;
                for (; i < listboxApp.Items.Count; i++)
                    if (name == listboxApp.Items[i].ToString())
                    {
                        StartExeFile(i);
                        return;
                    }
                if (i == listboxApp.Items.Count)
                    MessageBox.Show("Quick Launch cannot find '" + txtNoidung.Text + "'. Make sure you typed the name correctly, and then try again.", txtNoidung.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion
    }
}
