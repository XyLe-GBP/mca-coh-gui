namespace mca_coh_gui
{
    partial class FormPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPreferences));
            this.radioButton_norm = new System.Windows.Forms.RadioButton();
            this.radioButton_fixed = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.button_Location = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.checkBox_Showdir = new System.Windows.Forms.CheckBox();
            this.checkBox_write_withkey = new System.Windows.Forms.CheckBox();
            this.toolTip_Info = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_norm
            // 
            resources.ApplyResources(this.radioButton_norm, "radioButton_norm");
            this.radioButton_norm.Checked = true;
            this.radioButton_norm.Name = "radioButton_norm";
            this.radioButton_norm.TabStop = true;
            this.toolTip_Info.SetToolTip(this.radioButton_norm, resources.GetString("radioButton_norm.ToolTip"));
            this.radioButton_norm.UseVisualStyleBackColor = true;
            this.radioButton_norm.CheckedChanged += new System.EventHandler(this.RadioButton_norm_CheckedChanged);
            // 
            // radioButton_fixed
            // 
            resources.ApplyResources(this.radioButton_fixed, "radioButton_fixed");
            this.radioButton_fixed.Name = "radioButton_fixed";
            this.toolTip_Info.SetToolTip(this.radioButton_fixed, resources.GetString("radioButton_fixed.ToolTip"));
            this.radioButton_fixed.UseVisualStyleBackColor = true;
            this.radioButton_fixed.CheckedChanged += new System.EventHandler(this.RadioButton_fixed_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.radioButton_norm);
            this.groupBox1.Controls.Add(this.radioButton_fixed);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Clear);
            this.groupBox2.Controls.Add(this.textBox_Path);
            this.groupBox2.Controls.Add(this.button_Location);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // button_Clear
            // 
            resources.ApplyResources(this.button_Clear, "button_Clear");
            this.button_Clear.Name = "button_Clear";
            this.toolTip_Info.SetToolTip(this.button_Clear, resources.GetString("button_Clear.ToolTip"));
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // textBox_Path
            // 
            resources.ApplyResources(this.textBox_Path, "textBox_Path");
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.ReadOnly = true;
            // 
            // button_Location
            // 
            resources.ApplyResources(this.button_Location, "button_Location");
            this.button_Location.Name = "button_Location";
            this.toolTip_Info.SetToolTip(this.button_Location, resources.GetString("button_Location.ToolTip"));
            this.button_Location.UseVisualStyleBackColor = true;
            this.button_Location.Click += new System.EventHandler(this.Button_Location_Click);
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Cancel
            // 
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // checkBox_Showdir
            // 
            resources.ApplyResources(this.checkBox_Showdir, "checkBox_Showdir");
            this.checkBox_Showdir.Checked = true;
            this.checkBox_Showdir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Showdir.Name = "checkBox_Showdir";
            this.toolTip_Info.SetToolTip(this.checkBox_Showdir, resources.GetString("checkBox_Showdir.ToolTip"));
            this.checkBox_Showdir.UseVisualStyleBackColor = true;
            this.checkBox_Showdir.CheckedChanged += new System.EventHandler(this.CheckBox_Showdir_CheckedChanged);
            // 
            // checkBox_write_withkey
            // 
            resources.ApplyResources(this.checkBox_write_withkey, "checkBox_write_withkey");
            this.checkBox_write_withkey.Checked = true;
            this.checkBox_write_withkey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_write_withkey.Name = "checkBox_write_withkey";
            this.toolTip_Info.SetToolTip(this.checkBox_write_withkey, resources.GetString("checkBox_write_withkey.ToolTip"));
            this.checkBox_write_withkey.UseVisualStyleBackColor = true;
            this.checkBox_write_withkey.CheckedChanged += new System.EventHandler(this.CheckBox_write_withkey_CheckedChanged);
            // 
            // FormPreferences
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_write_withkey);
            this.Controls.Add(this.checkBox_Showdir);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPreferences";
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton radioButton_norm;
        private RadioButton radioButton_fixed;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button_Clear;
        private TextBox textBox_Path;
        private Button button_Location;
        private Button button_OK;
        private Button button_Cancel;
        private CheckBox checkBox_Showdir;
        private CheckBox checkBox_write_withkey;
        private ToolTip toolTip_Info;
    }
}