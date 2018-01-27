using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1512252
{
    public partial class Dictionary : Form
    {
        bool isUpdated = false;

        #region Constructor
        public Dictionary()
        {
            InitializeComponent();
            ShowAllDictionary();
        }
        #endregion

        #region Functions
        private void ShowAllDictionary()
        {
            lvDictionary.Items.Clear();
            ListViewItem item;
            for (int i = 0; i < Data.listfile.Count; i++)
            {
                item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(Data.listfile[i]);
                item.SubItems.Add(Data.listpath[i]);
                lvDictionary.Items.Add(item);
            }
        }
        private void DeleteListView()
        {
            if (lvDictionary.SelectedItems.Count > 0)
            {
                int pos = lvDictionary.SelectedIndices[0];
                int index = Int32.Parse(lvDictionary.Items[pos].SubItems[0].Text) - 1;
                for (int i = 0; i < Stats.filename.Count; i++)
                    if (Stats.filename[i] == lvDictionary.Items[pos].SubItems[1].Text)
                    {
                        Stats.filename.RemoveAt(i);
                        Stats.frequent.RemoveAt(i);
                    }
                lvDictionary.Items[pos].Remove();
                Data.listpath.RemoveAt(index);
                Data.listfile.RemoveAt(index);
                for (int i = pos; i < lvDictionary.Items.Count; i++)
                {
                    index = Int32.Parse(lvDictionary.Items[i].SubItems[0].Text) - 1;
                    lvDictionary.Items[i].SubItems[0].Text = index.ToString();
                }
                isUpdated = true;
            }
        }
        #endregion

        #region EVENTS
        private void lvDictionary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteListView();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteListView();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            CreatingDatabase a = new CreatingDatabase();
            a.ShowDialog(this);
            isUpdated = false;
        }

        private void Dictionary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isUpdated)
            {
                DialogResult dlrs = MessageBox.Show("Your dictionary has changed. Do you want to save your changes in database file before quitting?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlrs == DialogResult.Yes)
                {
                    CreatingDatabase a = new CreatingDatabase();
                    a.ShowDialog(this);
                }
                if (dlrs == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                ShowAllDictionary();
            if (txtSearch.Text.Length > 0)
            {
                lvDictionary.Items.Clear();
                string str = txtSearch.Text.ToLower();
                ListViewItem item;
                for (int i = 0; i < Data.listfile.Count; i++)
                    if (Data.listfile[i].Contains(str) && Data.listfile[i].IndexOf(str, 0) == 0)
                    {
                        item = new ListViewItem((i + 1).ToString());
                        item.SubItems.Add(Data.listfile[i]);
                        item.SubItems.Add(Data.listpath[i]);
                        lvDictionary.Items.Add(item);
                    }
            }
        }
        #endregion
    }
}
