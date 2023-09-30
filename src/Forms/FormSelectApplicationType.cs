using mca_coh_gui.src;

namespace mca_coh_gui
{
    public partial class FormSelectApplicationType : Form
    {
        public FormSelectApplicationType()
        {
            InitializeComponent();
        }

        private void FormSelectApplicationType_Load(object sender, EventArgs e)
        {
            comboBox_Type.SelectedIndex = 0;
        }

        private void ComboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_Type.SelectedIndex == 0)
            {
                Common.ApplicationPortable = false;
            }
            else if (comboBox_Type.SelectedIndex == 1)
            {
                Common.ApplicationPortable = true;
            }
            else
            {
                Common.ApplicationPortable = false;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
