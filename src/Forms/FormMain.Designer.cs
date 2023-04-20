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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Readlist = new System.Windows.Forms.Button();
            this.listView_Readcontents = new System.Windows.Forms.ListView();
            this.columnHeader_Name = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Size = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Date = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Time = new System.Windows.Forms.ColumnHeader();
            this.button_dump = new System.Windows.Forms.Button();
            this.button_dumpall = new System.Windows.Forms.Button();
            this.button_write = new System.Windows.Forms.Button();
            this.button_writeall = new System.Windows.Forms.Button();
            this.statusStrip_Information = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_format = new System.Windows.Forms.Button();
            this.button_keywrite = new System.Windows.Forms.Button();
            this.button_keydump = new System.Windows.Forms.Button();
            this.button_dumpimg = new System.Windows.Forms.Button();
            this.button_getinfo = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip_Information.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.helpHToolStripMenuItem,
            this.settingsSToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            resources.ApplyResources(this.fileFToolStripMenuItem, "fileFToolStripMenuItem");
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitXToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            // 
            // exitXToolStripMenuItem
            // 
            resources.ApplyResources(this.exitXToolStripMenuItem, "exitXToolStripMenuItem");
            this.exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            this.exitXToolStripMenuItem.Click += new System.EventHandler(this.ExitXToolStripMenuItem_Click);
            // 
            // helpHToolStripMenuItem
            // 
            resources.ApplyResources(this.helpHToolStripMenuItem, "helpHToolStripMenuItem");
            this.helpHToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAToolStripMenuItem});
            this.helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
            // 
            // aboutAToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutAToolStripMenuItem, "aboutAToolStripMenuItem");
            this.aboutAToolStripMenuItem.Name = "aboutAToolStripMenuItem";
            this.aboutAToolStripMenuItem.Click += new System.EventHandler(this.AboutAToolStripMenuItem_Click);
            // 
            // settingsSToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsSToolStripMenuItem, "settingsSToolStripMenuItem");
            this.settingsSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesPToolStripMenuItem});
            this.settingsSToolStripMenuItem.Name = "settingsSToolStripMenuItem";
            // 
            // preferencesPToolStripMenuItem
            // 
            resources.ApplyResources(this.preferencesPToolStripMenuItem, "preferencesPToolStripMenuItem");
            this.preferencesPToolStripMenuItem.Name = "preferencesPToolStripMenuItem";
            this.preferencesPToolStripMenuItem.Click += new System.EventHandler(this.PreferencesPToolStripMenuItem_Click);
            // 
            // button_Readlist
            // 
            resources.ApplyResources(this.button_Readlist, "button_Readlist");
            this.button_Readlist.Name = "button_Readlist";
            this.button_Readlist.UseVisualStyleBackColor = true;
            this.button_Readlist.Click += new System.EventHandler(this.Button_Readlist_Click);
            // 
            // listView_Readcontents
            // 
            resources.ApplyResources(this.listView_Readcontents, "listView_Readcontents");
            this.listView_Readcontents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_Size,
            this.columnHeader_Date,
            this.columnHeader_Time});
            this.listView_Readcontents.Name = "listView_Readcontents";
            this.listView_Readcontents.UseCompatibleStateImageBehavior = false;
            this.listView_Readcontents.View = System.Windows.Forms.View.Details;
            this.listView_Readcontents.SelectedIndexChanged += new System.EventHandler(this.ListView_Readcontents_SelectedIndexChanged);
            // 
            // columnHeader_Name
            // 
            resources.ApplyResources(this.columnHeader_Name, "columnHeader_Name");
            // 
            // columnHeader_Size
            // 
            resources.ApplyResources(this.columnHeader_Size, "columnHeader_Size");
            // 
            // columnHeader_Date
            // 
            resources.ApplyResources(this.columnHeader_Date, "columnHeader_Date");
            // 
            // columnHeader_Time
            // 
            resources.ApplyResources(this.columnHeader_Time, "columnHeader_Time");
            // 
            // button_dump
            // 
            resources.ApplyResources(this.button_dump, "button_dump");
            this.button_dump.Name = "button_dump";
            this.button_dump.UseVisualStyleBackColor = true;
            this.button_dump.Click += new System.EventHandler(this.Button_dump_Click);
            // 
            // button_dumpall
            // 
            resources.ApplyResources(this.button_dumpall, "button_dumpall");
            this.button_dumpall.Name = "button_dumpall";
            this.button_dumpall.UseVisualStyleBackColor = true;
            this.button_dumpall.Click += new System.EventHandler(this.Button_dumpall_Click);
            // 
            // button_write
            // 
            resources.ApplyResources(this.button_write, "button_write");
            this.button_write.Name = "button_write";
            this.button_write.UseVisualStyleBackColor = true;
            this.button_write.Click += new System.EventHandler(this.Button_write_Click);
            // 
            // button_writeall
            // 
            resources.ApplyResources(this.button_writeall, "button_writeall");
            this.button_writeall.Name = "button_writeall";
            this.button_writeall.UseVisualStyleBackColor = true;
            this.button_writeall.Click += new System.EventHandler(this.Button_writeall_Click);
            // 
            // statusStrip_Information
            // 
            resources.ApplyResources(this.statusStrip_Information, "statusStrip_Information");
            this.statusStrip_Information.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_info});
            this.statusStrip_Information.Name = "statusStrip_Information";
            // 
            // toolStripStatusLabel_info
            // 
            resources.ApplyResources(this.toolStripStatusLabel_info, "toolStripStatusLabel_info");
            this.toolStripStatusLabel_info.Name = "toolStripStatusLabel_info";
            // 
            // button_format
            // 
            resources.ApplyResources(this.button_format, "button_format");
            this.button_format.Name = "button_format";
            this.button_format.UseVisualStyleBackColor = true;
            this.button_format.Click += new System.EventHandler(this.Button_format_Click);
            // 
            // button_keywrite
            // 
            resources.ApplyResources(this.button_keywrite, "button_keywrite");
            this.button_keywrite.Name = "button_keywrite";
            this.button_keywrite.UseVisualStyleBackColor = true;
            this.button_keywrite.Click += new System.EventHandler(this.Button_keywrite_Click);
            // 
            // button_keydump
            // 
            resources.ApplyResources(this.button_keydump, "button_keydump");
            this.button_keydump.Name = "button_keydump";
            this.button_keydump.UseVisualStyleBackColor = true;
            this.button_keydump.Click += new System.EventHandler(this.Button_keydump_Click);
            // 
            // button_dumpimg
            // 
            resources.ApplyResources(this.button_dumpimg, "button_dumpimg");
            this.button_dumpimg.Name = "button_dumpimg";
            this.button_dumpimg.UseVisualStyleBackColor = true;
            this.button_dumpimg.Click += new System.EventHandler(this.Button_dumpimg_Click);
            // 
            // button_getinfo
            // 
            resources.ApplyResources(this.button_getinfo, "button_getinfo");
            this.button_getinfo.Name = "button_getinfo";
            this.button_getinfo.UseVisualStyleBackColor = true;
            this.button_getinfo.Click += new System.EventHandler(this.Button_getinfo_Click);
            // 
            // button_remove
            // 
            resources.ApplyResources(this.button_remove, "button_remove");
            this.button_remove.Name = "button_remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.Button_remove_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_getinfo);
            this.Controls.Add(this.button_dumpimg);
            this.Controls.Add(this.button_keydump);
            this.Controls.Add(this.button_keywrite);
            this.Controls.Add(this.button_format);
            this.Controls.Add(this.statusStrip_Information);
            this.Controls.Add(this.button_writeall);
            this.Controls.Add(this.button_write);
            this.Controls.Add(this.button_dumpall);
            this.Controls.Add(this.button_dump);
            this.Controls.Add(this.listView_Readcontents);
            this.Controls.Add(this.button_Readlist);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip_Information.ResumeLayout(false);
            this.statusStrip_Information.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}