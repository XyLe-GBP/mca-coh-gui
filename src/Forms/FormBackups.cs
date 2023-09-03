using mca_coh_gui.Localizations;
using static mca_coh_gui.src.Common;

namespace mca_coh_gui.src.Forms
{
    public partial class FormBackups : Form
    {
        private bool IsOriginal = true;
        private bool IsHideKey = true;
        private int lvindex = 0;
        private readonly List<string> list = new();

        public FormBackups()
        {
            InitializeComponent();

            label_ONBackup.Enabled = true;
            label_ONBackup.Visible = true;
            label_NBackup.Enabled = true;
            label_NBackup.Visible = true;
        }

        private void FormBackups_Load(object sender, EventArgs e)
        {
            string[] files = GetFilelists(Common.CurrentDir + @"\keys");
            if (files.Length <= 0)
            {
                label_ONBackup.Enabled = true;
                label_ONBackup.Visible = true;
                return;
            }
            label_ONBackup.Enabled = false;
            label_ONBackup.Visible = false;

            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToUpper() == ".TXT")
                {
                    continue;
                }
                list.Add(file);
                string name = Path.GetFileName(file);
                string[] gnamebuf = new string[2];
                string gamename;
                if (File.Exists(Common.CurrentDir + @"\keys\" + name.Replace(".hex", ".txt")))
                {
                    Utils.GetDongleTitleAlreadyTxt(Common.CurrentDir + @"\keys\" + name.Replace(".hex", ".txt"), gnamebuf);
                    gamename = Utils.GetGameName(gnamebuf[1]);
                }
                else
                {
                    gamename = "Unknown";
                }

                string key;
                DateTime creationtime = File.GetCreationTime(file);

                if (IsHideKey == true)
                {
                    key = "********************";
                }
                else
                {
                    key = Common.Utils.GetKey(file);
                }

                string[] data = { name, gamename, key, creationtime.ToString() };
                listView_Original.Items.Add(new ListViewItem(data));
            }
            return;
        }

        private void TabControl_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_Main.SelectedIndex == 0) // Original
            {
                IsOriginal = true;
                LoadLists(IsOriginal);
            }
            else // Changed
            {
                IsOriginal = false;
                LoadLists(IsOriginal);
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static string[] GetFilelists(string FolderPath)
        {
            string[] files;
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                files = Directory.GetFiles(FolderPath, "*", SearchOption.AllDirectories);
                return files;
            }
            else
            {
                files = Directory.GetFiles(FolderPath, "*", SearchOption.AllDirectories);
                return files;
            }
        }

        private void ListView_Original_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Original.SelectedItems.Count > 0)
            {
                lvindex = listView_Original.SelectedItems[0].Index;
                contextMenuStrip_Main.Enabled = true;
            }
            else
            {
                contextMenuStrip_Main.Enabled = false;
            }
        }

        private void ListView_Changed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Changed.SelectedItems.Count > 0)
            {
                lvindex = listView_Changed.SelectedItems[0].Index;
                contextMenuStrip_Main.Enabled = true;
            }
            else
            {
                contextMenuStrip_Main.Enabled = false;
            }
        }

        private void OpenFileLocationOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lst = list.ToArray();
            Generals.IsCompletedShowDirectory(lst[lvindex], true);
        }

        private void RestoreRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            string[] lst = list.ToArray();
            if (MessageBox.Show(this, "Restore selected files.\r\nFiles currently written to the dongle will be lost.\r\nDo you wish to continue?", Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (IsOriginal == true)
                {

                    Utils.DumpBootFile(CurrentDir + @"\boot.bin");
                    Bootbin_Location = CurrentDir + @"\boot.bin";
                    string path = Utils.DumpOrWriteKeyWithAutoKey(lst[lvindex], 1);
                    SaveLocation = CurrentDir + @"\boot.bin";
                    OpenProgressDlg(3, 1);

                    MessageBox.Show(this, "Key restored from backup.", Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Bootbin_Location = lst[lvindex];
                    OpenProgressDlg(3, 1);

                    MessageBox.Show(this, "Restored boot.bin from backup.", Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                return;
            }
        }

        private void DeleteDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lst = list.ToArray();
            if (MessageBox.Show(this, "Delete backup files.\r\nDeleted files cannot be restored.\r\nDo you wish to continue?", Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (IsOriginal == true)
                {
                    File.Delete(lst[lvindex]);
                    File.Delete(lst[lvindex].Replace(".hex", ".txt"));
                    LoadLists(IsOriginal);
                }
                else
                {
                    Utils.DeleteDirectory(Path.GetDirectoryName(lst[lvindex]));
                    LoadLists(IsOriginal);
                }
            }
            else
            {
                return;
            }
        }

        private void LoadLists(bool originalflag)
        {
            string[] lst = list.ToArray();
            if (originalflag)
            {
                list.Clear();
                listView_Original.Items.Clear();
                string[] files = GetFilelists(Common.CurrentDir + @"\keys");
                if (files.Length <= 0)
                {
                    label_ONBackup.Enabled = true;
                    label_ONBackup.Visible = true;
                    return;
                }
                label_ONBackup.Enabled = false;
                label_ONBackup.Visible = false;

                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToUpper() == ".TXT")
                    {
                        continue;
                    }
                    list.Add(file);
                    string name = Path.GetFileName(file);
                    string[] gnamebuf = new string[2];
                    string gamename;
                    if (File.Exists(Common.CurrentDir + @"\keys\" + name.Replace(".hex", ".txt")))
                    {
                        Utils.GetDongleTitleAlreadyTxt(Common.CurrentDir + @"\keys\" + name.Replace(".hex", ".txt"), gnamebuf);
                        gamename = Utils.GetGameName(gnamebuf[1]);
                    }
                    else
                    {
                        gamename = "Unknown";
                    }

                    string key;
                    DateTime creationtime = File.GetCreationTime(file);

                    if (IsHideKey == true)
                    {
                        key = "********************";
                    }
                    else
                    {
                        key = Common.Utils.GetKey(file);
                    }

                    string[] data = { name, gamename, key, creationtime.ToString() };
                    listView_Original.Items.Add(new ListViewItem(data));
                }
            }
            else
            {
                list.Clear();
                listView_Changed.Items.Clear();
                string[] files = GetFilelists(Common.CurrentDir + @"\key_changed");
                if (files.Length <= 0)
                {
                    label_NBackup.Enabled = true;
                    label_NBackup.Visible = true;
                    return;
                }
                label_NBackup.Enabled = false;
                label_NBackup.Visible = false;

                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToUpper() == ".TXT")
                    {
                        continue;
                    }
                    list.Add(file);
                    string keydump = Common.Utils.DumpOrWriteKeyWithAutoKey(file, 0);
                    string[] gnamebuf = new string[2];
                    string name = Path.GetFileName(file);
                    string gamename;
                    if (File.Exists(Path.GetDirectoryName(file) + @"\title.txt"))
                    {
                        Utils.GetDongleTitleAlreadyTxt(Path.GetDirectoryName(file) + @"\title.txt", gnamebuf);
                        gamename = Utils.GetGameName(gnamebuf[1]);
                    }
                    else
                    {
                        gamename = "Unknown";
                    }

                    string key;
                    DateTime creationtime = File.GetCreationTime(file);

                    if (IsHideKey == true)
                    {
                        key = "********************";
                    }
                    else
                    {
                        key = Common.Utils.GetKey(keydump);
                    }

                    File.Delete(keydump);
                    string[] data = { name, gamename, key, creationtime.ToString() };
                    listView_Changed.Items.Add(new ListViewItem(data));
                }
            }
        }

        private static void OpenProgressDlg(int type, int count)
        {
            Count = count;
            ProgressType = type;
            ProgressMax = Count;

            FormProgress Form = new();
            Form.ShowDialog();
            Form.Dispose();
        }

        private void ListView_Original_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_Original.Columns[e.ColumnIndex].Width;
        }

        private void ListView_Changed_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_Changed.Columns[e.ColumnIndex].Width;
        }

        private bool ErrChk(string item)
        {
            if (item.Contains("(-1)"))
            {
                MessageBox.Show(this, Localization.FailedAttachText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (item.Contains("(-3)"))
            {
                MessageBox.Show(this, Localization.FormattedText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (item.Contains("(-11)"))
            {
                MessageBox.Show(this, Localization.NotInsertText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (item.Contains("(-90)"))
            {
                MessageBox.Show(this, Localization.UnableRecognizeText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void CheckBox_HKeys_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HKeys.Checked != true)
            {
                IsHideKey = false;
                LoadLists(IsOriginal);
            }
            else
            {
                IsHideKey = true;
                LoadLists(IsOriginal);
            }
        }
    }
}
