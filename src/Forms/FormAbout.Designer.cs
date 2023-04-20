namespace mca_coh_gui
{
    partial class FormAbout
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel_web = new System.Windows.Forms.LinkLabel();
            this.linkLabel_git = new System.Windows.Forms.LinkLabel();
            this.pictureBox_icon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "mca-coh gui : version {0}b";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(342, 206);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "Done!";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(405, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Copyright © 2011 - jimmikaelkael & \'someone who wants to stay anonymous\'";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Extra functions - 2021 - l_oliveira";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(372, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "GUI functions - Copyright © 2023 - XyLe (Special thanks: Hajime0512)";
            // 
            // linkLabel_web
            // 
            this.linkLabel_web.AutoSize = true;
            this.linkLabel_web.Location = new System.Drawing.Point(177, 152);
            this.linkLabel_web.Name = "linkLabel_web";
            this.linkLabel_web.Size = new System.Drawing.Size(85, 15);
            this.linkLabel_web.TabIndex = 5;
            this.linkLabel_web.TabStop = true;
            this.linkLabel_web.Text = "XyLe\'s Website";
            this.linkLabel_web.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_web_LinkClicked);
            // 
            // linkLabel_git
            // 
            this.linkLabel_git.AutoSize = true;
            this.linkLabel_git.Location = new System.Drawing.Point(303, 152);
            this.linkLabel_git.Name = "linkLabel_git";
            this.linkLabel_git.Size = new System.Drawing.Size(81, 15);
            this.linkLabel_git.TabIndex = 6;
            this.linkLabel_git.TabStop = true;
            this.linkLabel_git.Text = "XyLe\'s GitHub";
            this.linkLabel_git.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_git_LinkClicked);
            // 
            // pictureBox_icon
            // 
            this.pictureBox_icon.Location = new System.Drawing.Point(12, 108);
            this.pictureBox_icon.Name = "pictureBox_icon";
            this.pictureBox_icon.Size = new System.Drawing.Size(128, 128);
            this.pictureBox_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_icon.TabIndex = 7;
            this.pictureBox_icon.TabStop = false;
            this.pictureBox_icon.Click += new System.EventHandler(this.pictureBox_icon_Click);
            this.pictureBox_icon.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_icon_Paint);
            // 
            // FormAbout
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 241);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_icon);
            this.Controls.Add(this.linkLabel_git);
            this.Controls.Add(this.linkLabel_web);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About mca-coh gui";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button_OK;
        private Label label2;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel_web;
        private LinkLabel linkLabel_git;
        private PictureBox pictureBox_icon;
    }
}