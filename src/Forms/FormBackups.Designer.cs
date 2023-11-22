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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBackups));
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
            resources.ApplyResources(tabControl_Main, "tabControl_Main");
            tabControl_Main.ContextMenuStrip = contextMenuStrip_Main;
            tabControl_Main.Controls.Add(tabPage1);
            tabControl_Main.Controls.Add(tabPage2);
            tabControl_Main.Name = "tabControl_Main";
            tabControl_Main.SelectedIndex = 0;
            tabControl_Main.SelectedIndexChanged += TabControl_Main_SelectedIndexChanged;
            // 
            // contextMenuStrip_Main
            // 
            resources.ApplyResources(contextMenuStrip_Main, "contextMenuStrip_Main");
            contextMenuStrip_Main.Items.AddRange(new ToolStripItem[] { openFileLocationOToolStripMenuItem, restoreRToolStripMenuItem, toolStripMenuItem1, deleteDToolStripMenuItem });
            contextMenuStrip_Main.Name = "contextMenuStrip_Main";
            // 
            // openFileLocationOToolStripMenuItem
            // 
            resources.ApplyResources(openFileLocationOToolStripMenuItem, "openFileLocationOToolStripMenuItem");
            openFileLocationOToolStripMenuItem.Name = "openFileLocationOToolStripMenuItem";
            openFileLocationOToolStripMenuItem.Click += OpenFileLocationOToolStripMenuItem_Click;
            // 
            // restoreRToolStripMenuItem
            // 
            resources.ApplyResources(restoreRToolStripMenuItem, "restoreRToolStripMenuItem");
            restoreRToolStripMenuItem.Name = "restoreRToolStripMenuItem";
            restoreRToolStripMenuItem.Click += RestoreRToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // deleteDToolStripMenuItem
            // 
            resources.ApplyResources(deleteDToolStripMenuItem, "deleteDToolStripMenuItem");
            deleteDToolStripMenuItem.ForeColor = Color.Red;
            deleteDToolStripMenuItem.Name = "deleteDToolStripMenuItem";
            deleteDToolStripMenuItem.Click += DeleteDToolStripMenuItem_Click;
            // 
            // tabPage1
            // 
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Controls.Add(label_ONBackup);
            tabPage1.Controls.Add(listView_Original);
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_ONBackup
            // 
            resources.ApplyResources(label_ONBackup, "label_ONBackup");
            label_ONBackup.Name = "label_ONBackup";
            // 
            // listView_Original
            // 
            resources.ApplyResources(listView_Original, "listView_Original");
            listView_Original.Columns.AddRange(new ColumnHeader[] { columnHeader_OFileName, columnHeader_OGameName, columnHeader_OKey, columnHeader_ODate });
            listView_Original.Name = "listView_Original";
            listView_Original.ShowItemToolTips = true;
            listView_Original.UseCompatibleStateImageBehavior = false;
            listView_Original.View = View.Details;
            listView_Original.ColumnWidthChanging += ListView_Original_ColumnWidthChanging;
            listView_Original.SelectedIndexChanged += ListView_Original_SelectedIndexChanged;
            // 
            // columnHeader_OFileName
            // 
            resources.ApplyResources(columnHeader_OFileName, "columnHeader_OFileName");
            // 
            // columnHeader_OGameName
            // 
            resources.ApplyResources(columnHeader_OGameName, "columnHeader_OGameName");
            // 
            // columnHeader_OKey
            // 
            resources.ApplyResources(columnHeader_OKey, "columnHeader_OKey");
            // 
            // columnHeader_ODate
            // 
            resources.ApplyResources(columnHeader_ODate, "columnHeader_ODate");
            // 
            // tabPage2
            // 
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Controls.Add(label_NBackup);
            tabPage2.Controls.Add(listView_Changed);
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_NBackup
            // 
            resources.ApplyResources(label_NBackup, "label_NBackup");
            label_NBackup.Name = "label_NBackup";
            // 
            // listView_Changed
            // 
            resources.ApplyResources(listView_Changed, "listView_Changed");
            listView_Changed.Columns.AddRange(new ColumnHeader[] { columnHeader_FileName, columnHeader_GameName, columnHeader_Key, columnHeader_Date });
            listView_Changed.ContextMenuStrip = contextMenuStrip_Main;
            listView_Changed.Name = "listView_Changed";
            listView_Changed.ShowItemToolTips = true;
            listView_Changed.UseCompatibleStateImageBehavior = false;
            listView_Changed.View = View.Details;
            listView_Changed.ColumnWidthChanging += ListView_Changed_ColumnWidthChanging;
            listView_Changed.SelectedIndexChanged += ListView_Changed_SelectedIndexChanged;
            // 
            // columnHeader_FileName
            // 
            resources.ApplyResources(columnHeader_FileName, "columnHeader_FileName");
            // 
            // columnHeader_GameName
            // 
            resources.ApplyResources(columnHeader_GameName, "columnHeader_GameName");
            // 
            // columnHeader_Key
            // 
            resources.ApplyResources(columnHeader_Key, "columnHeader_Key");
            // 
            // columnHeader_Date
            // 
            resources.ApplyResources(columnHeader_Date, "columnHeader_Date");
            // 
            // button_Cancel
            // 
            resources.ApplyResources(button_Cancel, "button_Cancel");
            button_Cancel.Name = "button_Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += Button_Cancel_Click;
            // 
            // button_OK
            // 
            resources.ApplyResources(button_OK, "button_OK");
            button_OK.Name = "button_OK";
            button_OK.UseVisualStyleBackColor = true;
            button_OK.Click += Button_OK_Click;
            // 
            // checkBox_HKeys
            // 
            resources.ApplyResources(checkBox_HKeys, "checkBox_HKeys");
            checkBox_HKeys.Checked = true;
            checkBox_HKeys.CheckState = CheckState.Checked;
            checkBox_HKeys.Name = "checkBox_HKeys";
            checkBox_HKeys.UseVisualStyleBackColor = true;
            checkBox_HKeys.CheckedChanged += CheckBox_HKeys_CheckedChanged;
            // 
            // FormBackups
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(checkBox_HKeys);
            Controls.Add(button_OK);
            Controls.Add(button_Cancel);
            Controls.Add(tabControl_Main);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormBackups";
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