namespace mca_coh_gui
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            menuStrip1 = new MenuStrip();
            fileFToolStripMenuItem = new ToolStripMenuItem();
            exitXToolStripMenuItem = new ToolStripMenuItem();
            helpHToolStripMenuItem = new ToolStripMenuItem();
            aboutAToolStripMenuItem = new ToolStripMenuItem();
            settingsSToolStripMenuItem = new ToolStripMenuItem();
            preferencesPToolStripMenuItem = new ToolStripMenuItem();
            toolsTToolStripMenuItem = new ToolStripMenuItem();
            backupsBToolStripMenuItem = new ToolStripMenuItem();
            button_Readlist = new Button();
            listView_Readcontents = new ListView();
            columnHeader_Name = new ColumnHeader();
            columnHeader_Size = new ColumnHeader();
            columnHeader_Date = new ColumnHeader();
            columnHeader_Time = new ColumnHeader();
            button_dump = new Button();
            button_dumpall = new Button();
            button_write = new Button();
            button_writeall = new Button();
            statusStrip_Information = new StatusStrip();
            toolStripStatusLabel_info = new ToolStripStatusLabel();
            button_format = new Button();
            button_keywrite = new Button();
            button_keydump = new Button();
            button_dumpimg = new Button();
            button_getinfo = new Button();
            button_remove = new Button();
            timer_monitor = new System.Windows.Forms.Timer(components);
            toolStripMenuItem1 = new ToolStripSeparator();
            checkForUpdatesUToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip_Information.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileFToolStripMenuItem, helpHToolStripMenuItem, settingsSToolStripMenuItem, toolsTToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            fileFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitXToolStripMenuItem });
            fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            resources.ApplyResources(fileFToolStripMenuItem, "fileFToolStripMenuItem");
            // 
            // exitXToolStripMenuItem
            // 
            exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            resources.ApplyResources(exitXToolStripMenuItem, "exitXToolStripMenuItem");
            exitXToolStripMenuItem.Click += ExitXToolStripMenuItem_Click;
            // 
            // helpHToolStripMenuItem
            // 
            helpHToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            helpHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutAToolStripMenuItem, toolStripMenuItem1, checkForUpdatesUToolStripMenuItem });
            helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
            resources.ApplyResources(helpHToolStripMenuItem, "helpHToolStripMenuItem");
            // 
            // aboutAToolStripMenuItem
            // 
            aboutAToolStripMenuItem.Name = "aboutAToolStripMenuItem";
            resources.ApplyResources(aboutAToolStripMenuItem, "aboutAToolStripMenuItem");
            aboutAToolStripMenuItem.Click += AboutAToolStripMenuItem_Click;
            // 
            // settingsSToolStripMenuItem
            // 
            settingsSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { preferencesPToolStripMenuItem });
            settingsSToolStripMenuItem.Name = "settingsSToolStripMenuItem";
            resources.ApplyResources(settingsSToolStripMenuItem, "settingsSToolStripMenuItem");
            // 
            // preferencesPToolStripMenuItem
            // 
            preferencesPToolStripMenuItem.Name = "preferencesPToolStripMenuItem";
            resources.ApplyResources(preferencesPToolStripMenuItem, "preferencesPToolStripMenuItem");
            preferencesPToolStripMenuItem.Click += PreferencesPToolStripMenuItem_Click;
            // 
            // toolsTToolStripMenuItem
            // 
            toolsTToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupsBToolStripMenuItem });
            toolsTToolStripMenuItem.Name = "toolsTToolStripMenuItem";
            resources.ApplyResources(toolsTToolStripMenuItem, "toolsTToolStripMenuItem");
            // 
            // backupsBToolStripMenuItem
            // 
            backupsBToolStripMenuItem.Name = "backupsBToolStripMenuItem";
            resources.ApplyResources(backupsBToolStripMenuItem, "backupsBToolStripMenuItem");
            backupsBToolStripMenuItem.Click += BackupsBToolStripMenuItem_Click;
            // 
            // button_Readlist
            // 
            resources.ApplyResources(button_Readlist, "button_Readlist");
            button_Readlist.Name = "button_Readlist";
            button_Readlist.UseVisualStyleBackColor = true;
            button_Readlist.Click += Button_Readlist_Click;
            // 
            // listView_Readcontents
            // 
            listView_Readcontents.Columns.AddRange(new ColumnHeader[] { columnHeader_Name, columnHeader_Size, columnHeader_Date, columnHeader_Time });
            resources.ApplyResources(listView_Readcontents, "listView_Readcontents");
            listView_Readcontents.Name = "listView_Readcontents";
            listView_Readcontents.UseCompatibleStateImageBehavior = false;
            listView_Readcontents.View = View.Details;
            listView_Readcontents.ColumnWidthChanging += ListView_Readcontents_ColumnWidthChanging;
            listView_Readcontents.SelectedIndexChanged += ListView_Readcontents_SelectedIndexChanged;
            // 
            // columnHeader_Name
            // 
            resources.ApplyResources(columnHeader_Name, "columnHeader_Name");
            // 
            // columnHeader_Size
            // 
            resources.ApplyResources(columnHeader_Size, "columnHeader_Size");
            // 
            // columnHeader_Date
            // 
            resources.ApplyResources(columnHeader_Date, "columnHeader_Date");
            // 
            // columnHeader_Time
            // 
            resources.ApplyResources(columnHeader_Time, "columnHeader_Time");
            // 
            // button_dump
            // 
            resources.ApplyResources(button_dump, "button_dump");
            button_dump.Name = "button_dump";
            button_dump.UseVisualStyleBackColor = true;
            button_dump.Click += Button_dump_Click;
            // 
            // button_dumpall
            // 
            resources.ApplyResources(button_dumpall, "button_dumpall");
            button_dumpall.Name = "button_dumpall";
            button_dumpall.UseVisualStyleBackColor = true;
            button_dumpall.Click += Button_dumpall_Click;
            // 
            // button_write
            // 
            resources.ApplyResources(button_write, "button_write");
            button_write.Name = "button_write";
            button_write.UseVisualStyleBackColor = true;
            button_write.Click += Button_write_Click;
            // 
            // button_writeall
            // 
            resources.ApplyResources(button_writeall, "button_writeall");
            button_writeall.Name = "button_writeall";
            button_writeall.UseVisualStyleBackColor = true;
            button_writeall.Click += Button_writeall_Click;
            // 
            // statusStrip_Information
            // 
            statusStrip_Information.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel_info });
            resources.ApplyResources(statusStrip_Information, "statusStrip_Information");
            statusStrip_Information.Name = "statusStrip_Information";
            // 
            // toolStripStatusLabel_info
            // 
            toolStripStatusLabel_info.Name = "toolStripStatusLabel_info";
            resources.ApplyResources(toolStripStatusLabel_info, "toolStripStatusLabel_info");
            // 
            // button_format
            // 
            resources.ApplyResources(button_format, "button_format");
            button_format.Name = "button_format";
            button_format.UseVisualStyleBackColor = true;
            button_format.Click += Button_format_Click;
            // 
            // button_keywrite
            // 
            resources.ApplyResources(button_keywrite, "button_keywrite");
            button_keywrite.Name = "button_keywrite";
            button_keywrite.UseVisualStyleBackColor = true;
            button_keywrite.Click += Button_keywrite_Click;
            // 
            // button_keydump
            // 
            resources.ApplyResources(button_keydump, "button_keydump");
            button_keydump.Name = "button_keydump";
            button_keydump.UseVisualStyleBackColor = true;
            button_keydump.Click += Button_keydump_Click;
            // 
            // button_dumpimg
            // 
            resources.ApplyResources(button_dumpimg, "button_dumpimg");
            button_dumpimg.Name = "button_dumpimg";
            button_dumpimg.UseVisualStyleBackColor = true;
            button_dumpimg.Click += Button_dumpimg_Click;
            // 
            // button_getinfo
            // 
            resources.ApplyResources(button_getinfo, "button_getinfo");
            button_getinfo.Name = "button_getinfo";
            button_getinfo.UseVisualStyleBackColor = true;
            button_getinfo.Click += Button_getinfo_Click;
            // 
            // button_remove
            // 
            resources.ApplyResources(button_remove, "button_remove");
            button_remove.Name = "button_remove";
            button_remove.UseVisualStyleBackColor = true;
            button_remove.Click += Button_remove_Click;
            // 
            // timer_monitor
            // 
            timer_monitor.Tick += timer_monitor_Tick;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // checkForUpdatesUToolStripMenuItem
            // 
            checkForUpdatesUToolStripMenuItem.Name = "checkForUpdatesUToolStripMenuItem";
            resources.ApplyResources(checkForUpdatesUToolStripMenuItem, "checkForUpdatesUToolStripMenuItem");
            checkForUpdatesUToolStripMenuItem.Click += CheckForUpdatesUToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button_remove);
            Controls.Add(button_getinfo);
            Controls.Add(button_dumpimg);
            Controls.Add(button_keydump);
            Controls.Add(button_keywrite);
            Controls.Add(button_format);
            Controls.Add(statusStrip_Information);
            Controls.Add(button_writeall);
            Controls.Add(button_write);
            Controls.Add(button_dumpall);
            Controls.Add(button_dump);
            Controls.Add(listView_Readcontents);
            Controls.Add(button_Readlist);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormMain";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip_Information.ResumeLayout(false);
            statusStrip_Information.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileFToolStripMenuItem;
        private ToolStripMenuItem exitXToolStripMenuItem;
        private ToolStripMenuItem helpHToolStripMenuItem;
        private ToolStripMenuItem aboutAToolStripMenuItem;
        private Button button_Readlist;
        private ListView listView_Readcontents;
        private ColumnHeader columnHeader_Name;
        private ColumnHeader columnHeader_Date;
        private ColumnHeader columnHeader_Size;
        private Button button_dump;
        private Button button_dumpall;
        private Button button_write;
        private Button button_writeall;
        private ColumnHeader columnHeader_Time;
        private StatusStrip statusStrip_Information;
        private ToolStripStatusLabel toolStripStatusLabel_info;
        private ToolStripMenuItem settingsSToolStripMenuItem;
        private ToolStripMenuItem preferencesPToolStripMenuItem;
        private Button button_format;
        private Button button_keywrite;
        private Button button_keydump;
        private Button button_dumpimg;
        private Button button_getinfo;
        private Button button_remove;
        private ToolStripMenuItem toolsTToolStripMenuItem;
        private ToolStripMenuItem backupsBToolStripMenuItem;
        private System.Windows.Forms.Timer timer_monitor;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem checkForUpdatesUToolStripMenuItem;
    }
}