namespace _1512252
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listboxApp = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtNoidung = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToBuildDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listboxApp
            // 
            this.listboxApp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxApp.FormattingEnabled = true;
            this.listboxApp.ItemHeight = 19;
            this.listboxApp.Location = new System.Drawing.Point(97, 129);
            this.listboxApp.Name = "listboxApp";
            this.listboxApp.Size = new System.Drawing.Size(385, 403);
            this.listboxApp.TabIndex = 1;
            this.listboxApp.DoubleClick += new System.EventHandler(this.listboxApp_DoubleClick);
            this.listboxApp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listboxApp_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 58);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type the name of a program you want to run, and Quick Launch will open it for you" +
    ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Open:";
            // 
            // ntfIcon
            // 
            this.ntfIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfIcon.BalloonTipText = "Quick Launch has been started.";
            this.ntfIcon.BalloonTipTitle = "Notification";
            this.ntfIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
            this.ntfIcon.Text = "Quick Launch - 1512252";
            this.ntfIcon.Visible = true;
            this.ntfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.scanToBuildDatabaseToolStripMenuItem,
            this.viewDictionaryToolStripMenuItem,
            this.viewSaToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 136);
            // 
            // txtNoidung
            // 
            this.txtNoidung.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtNoidung.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoidung.FormattingEnabled = true;
            this.txtNoidung.IntegralHeight = false;
            this.txtNoidung.Location = new System.Drawing.Point(97, 83);
            this.txtNoidung.MaxDropDownItems = 5;
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.Size = new System.Drawing.Size(385, 27);
            this.txtNoidung.TabIndex = 0;
            this.txtNoidung.TextChanged += new System.EventHandler(this.txtNoidung_TextChanged);
            this.txtNoidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoidung_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(392, 546);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 35);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_1512252.Properties.Resources.app;
            this.pictureBox1.Location = new System.Drawing.Point(23, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::_1512252.Properties.Resources.hide;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.showToolStripMenuItem.Text = "Hide";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // scanToBuildDatabaseToolStripMenuItem
            // 
            this.scanToBuildDatabaseToolStripMenuItem.Image = global::_1512252.Properties.Resources.scan;
            this.scanToBuildDatabaseToolStripMenuItem.Name = "scanToBuildDatabaseToolStripMenuItem";
            this.scanToBuildDatabaseToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.scanToBuildDatabaseToolStripMenuItem.Text = "Scan to build database";
            this.scanToBuildDatabaseToolStripMenuItem.Click += new System.EventHandler(this.scanToBuildDatabaseToolStripMenuItem_Click);
            // 
            // viewDictionaryToolStripMenuItem
            // 
            this.viewDictionaryToolStripMenuItem.Image = global::_1512252.Properties.Resources.dictionary;
            this.viewDictionaryToolStripMenuItem.Name = "viewDictionaryToolStripMenuItem";
            this.viewDictionaryToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.viewDictionaryToolStripMenuItem.Text = "View dictionary";
            this.viewDictionaryToolStripMenuItem.Click += new System.EventHandler(this.viewDictionaryToolStripMenuItem_Click);
            // 
            // viewSaToolStripMenuItem
            // 
            this.viewSaToolStripMenuItem.Image = global::_1512252.Properties.Resources.statistics;
            this.viewSaToolStripMenuItem.Name = "viewSaToolStripMenuItem";
            this.viewSaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.viewSaToolStripMenuItem.Text = "View statistics";
            this.viewSaToolStripMenuItem.Click += new System.EventHandler(this.viewSaToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::_1512252.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 593);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNoidung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listboxApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Quick Launch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listboxApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon ntfIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanToBuildDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox txtNoidung;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolStripMenuItem viewDictionaryToolStripMenuItem;
    }
}

