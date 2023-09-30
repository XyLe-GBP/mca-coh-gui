namespace mca_coh_gui
{
    partial class FormSelectApplicationType
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
            comboBox_Type = new ComboBox();
            button_Cancel = new Button();
            button_OK = new Button();
            SuspendLayout();
            // 
            // comboBox_Type
            // 
            comboBox_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Type.FormattingEnabled = true;
            comboBox_Type.Items.AddRange(new object[] { "Release (High capacity, no runtime installation required)", "Portable (Capacity saving, runtime installation required)" });
            comboBox_Type.Location = new Point(12, 12);
            comboBox_Type.Name = "comboBox_Type";
            comboBox_Type.Size = new Size(399, 23);
            comboBox_Type.TabIndex = 0;
            comboBox_Type.SelectedIndexChanged += ComboBox_Type_SelectedIndexChanged;
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new Point(336, 41);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(75, 23);
            button_Cancel.TabIndex = 1;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += Button_Cancel_Click;
            // 
            // button_OK
            // 
            button_OK.Location = new Point(255, 41);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(75, 23);
            button_OK.TabIndex = 2;
            button_OK.Text = "OK";
            button_OK.UseVisualStyleBackColor = true;
            button_OK.Click += Button_OK_Click;
            // 
            // FormSelectApplicationType
            // 
            AcceptButton = button_OK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_Cancel;
            ClientSize = new Size(424, 73);
            ControlBox = false;
            Controls.Add(button_OK);
            Controls.Add(button_Cancel);
            Controls.Add(comboBox_Type);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormSelectApplicationType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Download Type";
            Load += FormSelectApplicationType_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox_Type;
        private Button button_Cancel;
        private Button button_OK;
    }
}