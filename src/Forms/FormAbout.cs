using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using mca_coh_gui.src;
using static mca_coh_gui.src.Common;

namespace mca_coh_gui
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            label1.Text = string.Format(label1.Text, ver.FileMajorPart.ToString() + "." + ver.FileMinorPart.ToString());
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                pictureBox_icon.ImageLocation = "https://avatars.githubusercontent.com/u/59692068?v=4";
            }
            else
            {
                pictureBox_icon.Image = Resources.Resource.f089e80b819fe6da7d36bea8bf647d04_t;
            }
        }

        private void linkLabel_web_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://github.com/XyLe-GBP");
        }

        private void linkLabel_git_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Common.Utils.OpenURI("https://xyle-official.com");
        }

        private void pictureBox_icon_Click(object sender, EventArgs e)
        {
            Common.Utils.OpenURI("https://twitter.com/x1lep");
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox_icon_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                Bitmap canvas = new Bitmap(pictureBox_icon.Width, pictureBox_icon.Height);
                Graphics g = Graphics.FromImage(canvas);
                GraphicsPath gp = new();
                gp.AddEllipse(g.VisibleClipBounds);
                Region rgn = new(gp);
                pictureBox_icon.Region = rgn;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception occured.", ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }
    }
}
