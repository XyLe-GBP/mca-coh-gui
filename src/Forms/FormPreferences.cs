using static mca_coh_gui.Common;
using mca_coh_gui.Localizations;
using System.Runtime.CompilerServices;

namespace mca_coh_gui
{
    public partial class FormPreferences : Form
    {
        public FormPreferences()
        {
            InitializeComponent();
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            Config.Load(xmlpath);

            switch (bool.Parse(Config.Entry["SETTINGS_DumpLocationFixed"].Value))
            {
                case true:
                    {
                        radioButton_fixed.Checked = true;
                        radioButton_norm.Checked = false;
                        button_Location.Enabled = true;
                        button_Clear.Enabled = true;
                        textBox_Path.Enabled = true;
                    }
                    break;
                case false:
                    {
                        radioButton_fixed.Checked = false;
                        radioButton_norm.Checked = true;
                        button_Location.Enabled = false;
                        button_Clear.Enabled = false;
                        textBox_Path.Enabled = false;
                    }
                    break;
            }
            switch (bool.Parse(Config.Entry["SETTINGS_CompleteDirectory"].Value))
            {
                case true:
                    {
                        checkBox_Showdir.Checked = true;
                    }
                    break;
                case false:
                    {
                        checkBox_Showdir.Checked = false;
                    }
                    break;
            }
            switch (bool.Parse(Config.Entry["SETTINGS_AutoWriteKey"].Value))
            {
                case true:
                    {
                        checkBox_write_withkey.Checked = true;
                    }
                    break;
                case false:
                    {
                        checkBox_write_withkey.Checked = false;
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(Config.Entry["SETTINGS_DumpLocationDirectory"].Value))
            {
                textBox_Path.Text = Config.Entry["SETTINGS_DumpLocationDirectory"].Value;
            }
            else
            {
                textBox_Path.Text = string.Empty;
            }
        }

        private void RadioButton_norm_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_norm.Checked != true)
            {
                radioButton_fixed.Checked = true;
                textBox_Path.Enabled = true;
                button_Location.Enabled = true;
                button_Clear.Enabled = true;
            }
            else
            {
                radioButton_fixed.Checked = false;
                textBox_Path.Enabled = false;
                button_Location.Enabled = false;
                button_Clear.Enabled = false;
                textBox_Path.Text = string.Empty;
            }
        }

        private void RadioButton_fixed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_fixed.Checked != true)
            {
                radioButton_norm.Checked = true;
                textBox_Path.Enabled = false;
                button_Location.Enabled = false;
                button_Clear.Enabled = false;
                textBox_Path.Text = string.Empty;
            }
            else
            {
                radioButton_norm.Checked = false;
                textBox_Path.Enabled = true;
                button_Location.Enabled = true;
                button_Clear.Enabled = true;
            }
        }

        private void Button_Location_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new()
            {
                Description = Localization.SpecifyDumpFileCaption,
                ShowNewFolderButton = true,
            };
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                textBox_Path.Text = fbd.SelectedPath;
                return;
            }
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Path.Clear();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (radioButton_fixed.Checked != false && string.IsNullOrWhiteSpace(textBox_Path.Text))
            {
                MessageBox.Show(this, Localization.ErrorSpecifyDumpText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton_norm.Checked != false)
            {
                Config.Entry["SETTINGS_DumpLocationFixed"].Value = "false";
                Config.Entry["SETTINGS_DumpLocationDirectory"].Value = "";
            }
            if (radioButton_fixed.Checked != false)
            {
                Config.Entry["SETTINGS_DumpLocationFixed"].Value = "true";
                Config.Entry["SETTINGS_DumpLocationDirectory"].Value = textBox_Path.Text;
            }
            if (checkBox_Showdir.Checked != false)
            {
                Config.Entry["SETTINGS_CompleteDirectory"].Value = "true";
            }
            else
            {
                Config.Entry["SETTINGS_CompleteDirectory"].Value = "false";
            }
            if (checkBox_write_withkey.Checked != false)
            {
                Config.Entry["SETTINGS_AutoWriteKey"].Value = "true";
            }
            else
            {
                Config.Entry["SETTINGS_AutoWriteKey"].Value = "false";
            }

            Config.Save(xmlpath);

            Close();
        }

        private void CheckBox_Showdir_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_write_withkey_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
