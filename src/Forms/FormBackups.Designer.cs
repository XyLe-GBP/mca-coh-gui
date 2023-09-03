namespace mca_coh_gui.src.Forms
{
    partial class FormBackups
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
            components = new System.ComponentModel.Container();
            tabControl_Main = new TabControl();
            contextMenuStrip_Main = new ContextMenuStrip(components);
            openFileLocationOToolStripMenuItem = new ToolStripMenuItem();
            restoreRToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            deleteDToolStripMenuItem = new ToolStripMenuItem();
            tabPage1 = new TabPage();
            label_ONBackup = new Label();
            listView_Original = new ListView();
            columnHeader_OFileName = new ColumnHeader();
            columnHeader_OGameName = new ColumnHeader();
            columnHeader_OKey = new ColumnHeader();
            columnHeader_ODate = new ColumnHeader();
            tabPage2 = new TabPage();
            label_NBackup = new Label();
            listView_Changed = new ListView();
            columnHeader_FileName = new ColumnHeader();
            columnHeader_GameName = new ColumnHeader();
            columnHeader_Key = new ColumnHeader();
            columnHeader_Date = new ColumnHeader();
            button_Cancel = new Button();
            button_OK = new Button();
            checkBox_HKeys = new CheckBox();
            tabControl_Main.SuspendLayout();
            contextMenuStrip_Main.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl_Main
            // 
            tabControl_Main.ContextMenuStrip = contextMenuStrip_Main;
            tabControl_Main.Controls.Add(tabPage1);
            tabControl_Main.Controls.Add(tabPage2);
            tabControl_Main.Location = new Point(12, 12);
            tabControl_Main.Name = "tabControl_Main";
            tabControl_Main.SelectedIndex = 0;
            tabControl_Main.Size = new Size(755, 412);
            tabControl_Main.TabIndex = 0;
            tabControl_Main.SelectedIndexChanged += TabControl_Main_SelectedIndexChanged;
            // 
            // contextMenuStrip_Main
            // 
            contextMenuStrip_Main.Items.AddRange(new ToolStripItem[] { openFileLocationOToolStripMenuItem, restoreRToolStripMenuItem, toolStripMenuItem1, deleteDToolStripMenuItem });
            contextMenuStrip_Main.Name = "contextMenuStrip_Main";
            contextMenuStrip_Main.Size = new Size(194, 76);
            // 
            // openFileLocationOToolStripMenuItem
            // 
            openFileLocationOToolStripMenuItem.Name = "openFileLocationOToolStripMenuItem";
            openFileLocationOToolStripMenuItem.Size = new Size(193, 22);
            openFileLocationOToolStripMenuItem.Text = "Open File Location (&O)";
            openFileLocationOToolStripMenuItem.Click += OpenFileLocationOToolStripMenuItem_Click;
            // 
            // restoreRToolStripMenuItem
            // 
            restoreRToolStripMenuItem.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            restoreRToolStripMenuItem.Name = "restoreRToolStripMenuItem";
            restoreRToolStripMenuItem.Size = new Size(193, 22);
            restoreRToolStripMenuItem.Text = "Restore (&R)";
            restoreRToolStripMenuItem.Click += RestoreRToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(190, 6);
            // 
            // deleteDToolStripMenuItem
            // 
            deleteDToolStripMenuItem.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            deleteDToolStripMenuItem.ForeColor = Color.Red;
            deleteDToolStripMenuItem.Name = "deleteDToolStripMenuItem";
            deleteDToolStripMenuItem.Size = new Size(193, 22);
            deleteDToolStripMenuItem.Text = "Delete (&D)";
            deleteDToolStripMenuItem.Click += DeleteDToolStripMenuItem_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label_ONBackup);
            tabPage1.Controls.Add(listView_Original);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(747, 384);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Original";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_ONBackup
            // 
            label_ONBackup.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_ONBackup.Location = new Point(-4, 3);
            label_ONBackup.Name = "label_ONBackup";
            label_ONBackup.Size = new Size(755, 378);
            label_ONBackup.TabIndex = 1;
            label_ONBackup.Text = "No Backup.";
            label_ONBackup.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView_Original
            // 
            listView_Original.Columns.AddRange(new ColumnHeader[] { columnHeader_OFileName, columnHeader_OGameName, columnHeader_OKey, columnHeader_ODate });
            listView_Original.Location = new Point(3, 3);
            listView_Original.Name = "listView_Original";
            listView_Original.ShowItemToolTips = true;
            listView_Original.Size = new Size(741, 378);
            listView_Original.TabIndex = 0;
            listView_Original.UseCompatibleStateImageBehavior = false;
            listView_Original.View = View.Details;
            listView_Original.ColumnWidthChanging += ListView_Original_ColumnWidthChanging;
            listView_Original.SelectedIndexChanged += ListView_Original_SelectedIndexChanged;
            // 
            // columnHeader_OFileName
            // 
            columnHeader_OFileName.Text = "Filename";
            columnHeader_OFileName.Width = 170;
            // 
            // columnHeader_OGameName
            // 
            columnHeader_OGameName.Text = "Gamename";
            columnHeader_OGameName.Width = 180;
            // 
            // columnHeader_OKey
            // 
            columnHeader_OKey.Text = "Key";
            columnHeader_OKey.Width = 250;
            // 
            // columnHeader_ODate
            // 
            columnHeader_ODate.Text = "Date";
            columnHeader_ODate.Width = 130;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label_NBackup);
            tabPage2.Controls.Add(listView_Changed);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(747, 384);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Changed";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_NBackup
            // 
            label_NBackup.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_NBackup.Location = new Point(0, 3);
            label_NBackup.Name = "label_NBackup";
            label_NBackup.Size = new Size(747, 378);
            label_NBackup.TabIndex = 1;
            label_NBackup.Text = "No Backup.";
            label_NBackup.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView_Changed
            // 
            listView_Changed.Columns.AddRange(new ColumnHeader[] { columnHeader_FileName, columnHeader_GameName, columnHeader_Key, columnHeader_Date });
            listView_Changed.ContextMenuStrip = contextMenuStrip_Main;
            listView_Changed.Location = new Point(3, 3);
            listView_Changed.Name = "listView_Changed";
            listView_Changed.ShowItemToolTips = true;
            listView_Changed.Size = new Size(741, 378);
            listView_Changed.TabIndex = 0;
            listView_Changed.UseCompatibleStateImageBehavior = false;
            listView_Changed.View = View.Details;
            listView_Changed.ColumnWidthChanging += ListView_Changed_ColumnWidthChanging;
            listView_Changed.SelectedIndexChanged += ListView_Changed_SelectedIndexChanged;
            // 
            // columnHeader_FileName
            // 
            columnHeader_FileName.Text = "Filename";
            columnHeader_FileName.Width = 100;
            // 
            // columnHeader_GameName
            // 
            columnHeader_GameName.Text = "Gamename";
            columnHeader_GameName.Width = 180;
            // 
            // columnHeader_Key
            // 
            columnHeader_Key.Text = "Key";
            columnHeader_Key.Width = 320;
            // 
            // columnHeader_Date
            // 
            columnHeader_Date.Text = "Date";
            columnHeader_Date.Width = 130;
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new Point(607, 426);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(75, 23);
            button_Cancel.TabIndex = 1;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += Button_Cancel_Click;
            // 
            // button_OK
            // 
            button_OK.Location = new Point(688, 426);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(75, 23);
            button_OK.TabIndex = 2;
            button_OK.Text = "OK";
            button_OK.UseVisualStyleBackColor = true;
            button_OK.Click += Button_OK_Click;
            // 
            // checkBox_HKeys
            // 
            checkBox_HKeys.AutoSize = true;
            checkBox_HKeys.Checked = true;
            checkBox_HKeys.CheckState = CheckState.Checked;
            checkBox_HKeys.Location = new Point(22, 426);
            checkBox_HKeys.Name = "checkBox_HKeys";
            checkBox_HKeys.Size = new Size(78, 19);
            checkBox_HKeys.TabIndex = 3;
            checkBox_HKeys.Text = "Hide Keys";
            checkBox_HKeys.UseVisualStyleBackColor = true;
            checkBox_HKeys.CheckedChanged += CheckBox_HKeys_CheckedChanged;
            // 
            // FormBackups
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 475);
            ControlBox = false;
            Controls.Add(checkBox_HKeys);
            Controls.Add(button_OK);
            Controls.Add(button_Cancel);
            Controls.Add(tabControl_Main);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormBackups";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backuped Boot File(s)";
            Load += FormBackups_Load;
            tabControl_Main.ResumeLayout(false);
            contextMenuStrip_Main.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl_Main;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button_Cancel;
        private Button button_OK;
        private ListView listView_Original;
        private ListView listView_Changed;
        private ContextMenuStrip contextMenuStrip_Main;
        private ToolStripMenuItem restoreRToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem deleteDToolStripMenuItem;
        private ToolStripMenuItem openFileLocationOToolStripMenuItem;
        private ColumnHeader columnHeader_FileName;
        private ColumnHeader columnHeader_Key;
        private ColumnHeader columnHeader_Date;
        private ColumnHeader columnHeader_GameName;
        private ColumnHeader columnHeader_OFileName;
        private ColumnHeader columnHeader_OGameName;
        private ColumnHeader columnHeader_OKey;
        private ColumnHeader columnHeader_ODate;
        private Label label_ONBackup;
        private Label label_NBackup;
        private CheckBox checkBox_HKeys;
    }
}