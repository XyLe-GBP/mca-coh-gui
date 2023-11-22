using System.Diagnostics;
using System.Text.RegularExpressions;
using static mca_coh_gui.src.Common;
using mca_coh_gui.Localizations;
using mca_coh_gui.src;
using mca_coh_gui.src.Forms;
using System.Net.NetworkInformation;

namespace mca_coh_gui
{
    public partial class FormMain : Form
    {
        #region NetworkCommon
        private static readonly HttpClientHandler handler = new()
        {
            UseProxy = false,
            UseCookies = false
        };
        private static readonly HttpClient appUpdatechecker = new(handler);
        #endregion

        private bool isfixed = false;
        private bool isshowdir = true;
        private bool iskeyautowrite = true;
        private string fixeddir = null!;
        private int listindex = 0;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            if (ver.FileVersion != null)
            {
                Text = "mca-coh-gui";
            }

            if (!File.Exists(Common.xmlpath))
            {
                Generals.InitConfig();
            }

            ReInitializeConfig();

            if (File.Exists(Directory.GetCurrentDirectory() + @"\updated.dat"))
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\updated.dat");
                string updpath = Directory.GetCurrentDirectory()[..Directory.GetCurrentDirectory().LastIndexOf('\\')];
                File.Delete(updpath + @"\updater.exe");
                File.Delete(updpath + @"\mca-coh-gui.zip");
                Common.Utils.DeleteDirectory(updpath + @"\updater-temp");

                MessageBox.Show(this, Localization.UpdateCompletedCaption, Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var update = Task.Run(() => CheckForUpdatesForInit());
                update.Wait();
            }

            string[] buffer = new string[1];
            if (!CheckUSBDevice(buffer))
            {
                MessageBox.Show(this, buffer[0], "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (ver.FileVersion != null)
            {
                Text = "mca-coh gui ( build: " + ver.FileVersion.ToString() + "b )";
            }
        }

        private void Button_Readlist_Click(object sender, EventArgs e)
        {

            toolStripStatusLabel_info.Text = Localization.RetrievingText;

            button_getinfo.Enabled = false;
            button_dump.Enabled = false;
            button_dumpall.Enabled = false;
            button_write.Enabled = false;
            button_writeall.Enabled = false;
            button_remove.Enabled = false;
            button_dumpimg.Enabled = false;
            button_keydump.Enabled = false;
            button_keywrite.Enabled = false;
            button_format.Enabled = false;

            listView_Readcontents.Items.Clear();
            string read;
            ProcessStartInfo? psi = new()
            {
                FileName = ResourcesDir + @"\mca-coh.exe",
                Arguments = "-ls /",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            Process? p = Process.Start(psi);
            if (p is not null)
            {
                List<string> list = new();
                read = p.StandardOutput.ReadToEnd();
                read = read.Replace(Environment.NewLine, "\r");
                read = read.Trim('\r');
                string[] readlist = read.Split('\r');


                foreach (var item in readlist)
                {
                    if (item.Contains("(-1)"))
                    {
                        MessageBox.Show(this, Localization.FailedAttachText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel_info.Text = Localization.FailedRetrievingText;
                        return;
                    }
                    if (item.Contains("(-90)"))
                    {
                        MessageBox.Show(this, Localization.UnableRecognizeText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel_info.Text = Localization.FailedRetrievingText;
                        return;
                    }
                    if (item.Contains("(-3)"))
                    {
                        MessageBox.Show(this, Localization.FormattedText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel_info.Text = Localization.FailedRetrievingText;
                        return;
                    }
                    if (item.Contains("(-11)"))
                    {
                        MessageBox.Show(this, Localization.NotInsertText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel_info.Text = Localization.FailedRetrievingText;
                        return;
                    }
                    if (!item.Contains("PS3") && !item.Contains("<dir>"))
                    {
                        Match matchname = Regex.Match(item, "[a-z]*.[a-z]*[A-Z]*.[A-Z]*[0-9]*.[A-Z]*[^ ]*[^ ]");
                        Match matchdate = Regex.Match(item, "[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])");
                        Match matchclock = Regex.Match(item, "([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
                        Match matchsize = Regex.Match(item, "[ ][0-9]{2,7}");
                        list.Add(matchname.Value.Trim());
                        string[] data = { matchname.Value.Trim(), matchsize.Value, matchdate.Value, matchclock.Value };
                        listView_Readcontents.Items.Add(new ListViewItem(data));

                    }

                };
                Donglefilenames = list.ToArray();

                toolStripStatusLabel_info.Text = Localization.CompleteRetrievingText;

                button_getinfo.Enabled = true;
                button_dumpall.Enabled = true;
                button_writeall.Enabled = true;
                button_dumpimg.Enabled = true;
                button_keydump.Enabled = true;
                button_keywrite.Enabled = true;
                button_format.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, Localization.NoresponseText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Button_getinfo_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }
            IsGetInfo = true;

            string[] dongleinfo = new string[2];
            Utils.GetDongleTitle(dongleinfo);

            ProcessStartInfo? psi = new()
            {
                FileName = ResourcesDir + @"\mca-coh.exe",
                Arguments = "-i",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            Process? p = Process.Start(psi);
            if (p is not null)
            {

                string? read, title = null, info = string.Format(Localization.GetInfoText, dongleinfo[1], Utils.GetGameName(dongleinfo[1]), dongleinfo[0]);
                read = p.StandardOutput.ReadToEnd();
                read = read.Replace(Environment.NewLine, "\r");
                read = read.Trim('\r');
                string[] readlist = read.Split('\r');
                foreach (var item in readlist)
                {
                    if (item.Contains("PS3"))
                    {
                        title = item;
                    }
                    if (item.Contains("PS2"))
                    {
                        title += ": " + item;
                    }
                    if (!item.Contains("PS3") && !item.Contains("PS2"))
                    {
                        info += item + Environment.NewLine;
                    }
                }
                Utils.DumpBootFile(ResourcesDir + @"\boot.bin");
                string dmp_path = Utils.DumpOrWriteKeyWithAutoKey(ResourcesDir + @"\boot.bin", 0);
                info += "Key: " + Utils.GetKey(dmp_path);
                File.Delete(ResourcesDir + @"\boot.bin");
                File.Delete(dmp_path);
                File.Delete(Directory.GetCurrentDirectory() + @"\title.txt");
                IsGetInfo = false;
                MessageBox.Show(this, info, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                IsGetInfo = false;
                File.Delete(Directory.GetCurrentDirectory() + @"\title.txt");
                MessageBox.Show(this, Localization.ObtainedDongleInformationText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

        private void Button_dump_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            switch (isfixed)
            {
                case true:
                    {
                        if (listView_Readcontents.SelectedItems.Count > 0)
                        {
                            toolStripStatusLabel_info.Text = string.Format(Localization.DumpingText, listView_Readcontents.SelectedItems[0].Text);

                            SaveLocation = fixeddir;
                            ListviewName = listView_Readcontents.SelectedItems[0].Text;
                            OpenProgressDlg(2, 1);
                        }
                        toolStripStatusLabel_info.Text = Localization.DumpCompletedText;
                        Generals.IsCompletedShowDirectory(fixeddir, isshowdir);
                    }
                    break;
                case false:
                    {
                        SaveFileDialog sfd = new()
                        {
                            FileName = listView_Readcontents.SelectedItems[0].Text,
                            InitialDirectory = "",
                            Filter = Localization.Filter_AllFiles,
                            RestoreDirectory = true
                        };
                        if (sfd.ShowDialog(this) == DialogResult.OK)
                        {
                            if (listView_Readcontents.SelectedItems.Count > 0)
                            {
                                toolStripStatusLabel_info.Text = string.Format(Localization.DumpingText, listView_Readcontents.SelectedItems[0].Text);

                                SaveLocation = sfd.FileName;
                                ListviewName = listView_Readcontents.SelectedItems[0].Text;
                                OpenProgressDlg(2, 1);
                            }
                            toolStripStatusLabel_info.Text = Localization.DumpCompletedText;
                            Generals.IsCompletedShowDirectory(Path.GetDirectoryName(sfd.FileName), isshowdir);
                        }
                        else { return; } // Cancelled.
                    }
                    break;
            }
        }

        private void Button_dumpall_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            switch (isfixed)
            {
                case true:
                    {
                        toolStripStatusLabel_info.Text = Localization.DumpingAllText;

                        SaveLocation = fixeddir;
                        OpenProgressDlg(0, Donglefilenames.Count());

                        toolStripStatusLabel_info.Text = Localization.DumpCompletedText;
                        Generals.IsCompletedShowDirectory(fixeddir, isshowdir);
                    }
                    break;
                case false:
                    {
                        FolderBrowserDialog fbd = new()
                        {
                            Description = Localization.SpecifyDumpFileCaption,
                            ShowNewFolderButton = true,
                        };
                        if (fbd.ShowDialog(this) == DialogResult.OK)
                        {
                            toolStripStatusLabel_info.Text = Localization.DumpingAllText;

                            SaveLocation = fbd.SelectedPath;
                            OpenProgressDlg(0, Donglefilenames.Count());

                            toolStripStatusLabel_info.Text = Localization.DumpCompletedText;
                            Generals.IsCompletedShowDirectory(fbd.SelectedPath, isshowdir);
                        }
                        else
                        { return; } // Cancelled.
                    }
                    break;
            }
        }

        private void Button_write_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            OpenFileDialog ofd = new()
            {
                FileName = "",
                InitialDirectory = "",
                Filter = Localization.Filter_AllFiles,
                RestoreDirectory = true
            };
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                if (MessageBox.Show(this, Localization.WriteDataConfirmText, Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (MessageBox.Show(this, Localization.WarningUnplugText, Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        toolStripStatusLabel_info.Text = string.Format(Localization.WritingText, ofd.FileName);

                        SaveLocation = ofd.FileName;
                        OpenProgressDlg(3, 1);

                        toolStripStatusLabel_info.Text = Localization.WriteCompleteText;
                    }
                    else { return; } // Cancelled.
                }
                else { return; } // Cancelled.
            }
            else { return; } // Cancelled.
        }

        private void Button_writeall_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            FolderBrowserDialog fbd = new()
            {
                Description = Localization.SpecifyWriteFileCaption,
                ShowNewFolderButton = false,
            };
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                if (MessageBox.Show(this, Localization.WriteDataConfirmText, Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (MessageBox.Show(this, Localization.WarningUnplugText, Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (iskeyautowrite == true)
                        {
                            string ChangedBootPath = CurrentDir + @"\key_changed\" + Path.GetFileName(fbd.SelectedPath) + "_" + Utils.SFDRandomNumber();
                            string KeyBackupPath = CurrentDir + @"\keys";

                            if (!Directory.Exists(ChangedBootPath))
                            {
                                Directory.CreateDirectory(ChangedBootPath);
                            }
                            if (!Directory.Exists(KeyBackupPath))
                            {
                                Directory.CreateDirectory(KeyBackupPath);
                            }

                            Utils.DumpBootFile(ResourcesDir + @"\boot.bin");
                            string[] dummy = new string[2];
                            Utils.GetDongleTitle(dummy);
                            if (File.Exists(ResourcesDir + @"\boot.bin"))
                            {
                                string dmp_path = Utils.DumpOrWriteKeyWithAutoKey(ResourcesDir + @"\boot.bin", 0);
                                File.Delete(ResourcesDir + @"\boot.bin");

                                OpenProgressDlg(6, 1);

                                if (File.Exists(ChangedBootPath + @"\boot.bin"))
                                {
                                    File.Delete(ChangedBootPath + @"\boot.bin");
                                    File.Copy(fbd.SelectedPath + @"\boot.bin", ChangedBootPath + @"\boot.bin");
                                }
                                else
                                {
                                    File.Copy(fbd.SelectedPath + @"\boot.bin", ChangedBootPath + @"\boot.bin");
                                }

                                if (File.Exists(ChangedBootPath + @"\title.txt"))
                                {
                                    File.Delete(ChangedBootPath + @"\title.txt");
                                    File.Copy(CurrentDir + @"\title.txt", ChangedBootPath + @"\title.txt");
                                }
                                else
                                {
                                    File.Copy(CurrentDir + @"\title.txt", ChangedBootPath + @"\title.txt");
                                }

                                if (File.Exists(dmp_path))
                                {
                                    string[] data = new string[2];
                                    Bootbin_Location = ChangedBootPath + @"\boot.bin";
                                    string write_path = Utils.DumpOrWriteKeyWithAutoKey(dmp_path, 1);
                                    if (Utils.KeyVerify(Bootbin_Location, dmp_path, data) == true)
                                    {
                                        MessageBox.Show(this, string.Format(Localization.KeyVerifyedText, data[0], data[1]), Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (File.Exists(fbd.SelectedPath + @"\boot.bin"))
                                        {
                                            File.Move(fbd.SelectedPath + @"\boot.bin", ResourcesDir + @"\origin.bin");
                                            File.Copy(ChangedBootPath + @"\boot.bin", fbd.SelectedPath + @"\boot.bin");
                                        }
                                    }
                                    else // Error
                                    {
                                        MessageBox.Show(this, string.Format(Localization.FailedKeyVerifyText, data[0], data[1]), Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        File.Delete(dmp_path);
                                        File.Delete(write_path);
                                        return;
                                    }
                                }
                                else // Error
                                {
                                    MessageBox.Show(this, Localization.FailedKeyDumpText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else // not exist boot.bin
                            {
                                MessageBox.Show(this, Localization.BootNotExistText, Localization.WarningCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                OpenProgressDlg(6, 1);
                            }
                        }
                        else // option false
                        {
                            OpenProgressDlg(6, 1);
                        }

                        SaveLocation = fbd.SelectedPath;
                        OpenProgressDlg(1, Directory.GetFiles(fbd.SelectedPath, "*", SearchOption.TopDirectoryOnly).Count());

                        if (iskeyautowrite == true)
                        {
                            File.Delete(fbd.SelectedPath + @"\boot.bin");
                            File.Move(ResourcesDir + @"\origin.bin", fbd.SelectedPath + @"\boot.bin");
                        }

                        toolStripStatusLabel_info.Text = Localization.WriteCompleteText;
                    }
                    else
                    { return; } // Cancelled.
                }
                else
                { return; } // Cancelled.
            }
            else
            { return; } // Cancelled.
        }

        private void Button_remove_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            ListviewName = listView_Readcontents.SelectedItems[0].Text;
            if (MessageBox.Show(this, string.Format(Localization.RemoveConfirmText, ListviewName), Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                toolStripStatusLabel_info.Text = string.Format(Localization.RemovingText, ListviewName);

                SaveLocation = ListviewName;
                OpenProgressDlg(5, 1);

                toolStripStatusLabel_info.Text = Localization.RemoveCompletedText;
            }
        }

        private void Button_dumpimg_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            switch (isfixed)
            {
                case true:
                    {
                        SaveLocation = fixeddir;
                        OpenProgressDlg(4, 1);

                        Generals.IsCompletedShowDirectory(Path.GetFullPath(fixeddir), isshowdir);
                    }
                    break;
                case false:
                    {
                        SaveFileDialog sfd = new()
                        {
                            FileName = "dongle.img",
                            InitialDirectory = "",
                            Filter = Localization.Filter_Image,
                            RestoreDirectory = true
                        };
                        if (sfd.ShowDialog(this) == DialogResult.OK)
                        {
                            toolStripStatusLabel_info.Text = string.Format(Localization.DumpingImageText, sfd.FileName);

                            SaveLocation = sfd.FileName;
                            OpenProgressDlg(4, 1);

                            toolStripStatusLabel_info.Text = Localization.DumpImageCompletedText;
                            Generals.IsCompletedShowDirectory(Path.GetFullPath(sfd.FileName), isshowdir);
                        }
                    }
                    break;
            }
        }

        private void Button_keydump_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            switch (isfixed)
            {
                case true:
                    {
                        _ = Utils.DumpOrWriteKey(fixeddir + @"\" + "boot.bin", 0);
                        toolStripStatusLabel_info.Text = Localization.KeyDumpCompletedText;
                        MessageBox.Show(this, Localization.KeyDumpSuccessText, Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Generals.IsCompletedShowDirectory(fixeddir, isshowdir);
                    }
                    break;
                case false:
                    {
                        OpenFileDialog ofd = new()
                        {
                            FileName = "boot.bin",
                            InitialDirectory = "",
                            Filter = Localization.Filter_boot,
                            RestoreDirectory = true
                        };
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string path = Utils.DumpOrWriteKey(ofd.FileName, 0);
                            if (string.IsNullOrWhiteSpace(path))
                            {
                                return;
                            }
                            toolStripStatusLabel_info.Text = Localization.KeyDumpCompletedText;
                            MessageBox.Show(this, string.Format(Localization.KeyDumpSuccessText, Utils.GetKey(path)), Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Generals.IsCompletedShowDirectory(Path.GetDirectoryName(path), isshowdir);
                        }
                        else { return; } // Cancelled.
                    }
                    break;
            }
        }

        private void Button_keywrite_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            switch (isfixed)
            {
                case true: // Path Fixed
                    {
                        string path = Utils.DumpOrWriteKey(fixeddir + @"\key.hex", 1);

                        toolStripStatusLabel_info.Text = Localization.WriteKeyCompletedText;
                        if (MessageBox.Show(this, Localization.WritebootConfirmText, Localization.WritedKeyText, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            SaveLocation = path;
                            OpenProgressDlg(3, 1);

                            Generals.IsCompletedShowDirectory(path, isshowdir);
                        }
                        else
                        {
                            Generals.IsCompletedShowDirectory(path, isshowdir);
                        }
                    }
                    break;
                case false: // Normal
                    {
                        OpenFileDialog ofd = new()
                        {
                            FileName = "key.hex",
                            InitialDirectory = "",
                            Filter = Localization.Filter_Key,
                            RestoreDirectory = true
                        };
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string path = Utils.DumpOrWriteKey(ofd.FileName, 1);
                            if (string.IsNullOrWhiteSpace(path))
                            {
                                return;
                            }

                            toolStripStatusLabel_info.Text = Localization.WriteKeyCompletedText;
                            if (MessageBox.Show(this, Localization.WritebootConfirmText, Localization.WritedKeyText, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                SaveLocation = path;
                                OpenProgressDlg(3, 1);

                                Generals.IsCompletedShowDirectory(path, isshowdir);
                            }
                            else
                            {
                                Generals.IsCompletedShowDirectory(path, isshowdir);
                            }
                        }
                    }
                    break;
            }
        }

        private void Button_format_Click(object sender, EventArgs e)
        {
            if (ErrChk(Utils.ErrorCheck()) == true)
            {
                return;
            }

            if (MessageBox.Show(this, Localization.FormatConfirmText, Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                toolStripStatusLabel_info.Text = Localization.FormattingText;
                OpenProgressDlg(6, 1);

                toolStripStatusLabel_info.Text = Localization.FormatCompletedText;
                MessageBox.Show(this, Localization.CardFormattedText, Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { return; } // Cancelled.
        }

        private void PreferencesPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FormPreferences Form = new();
            Form.ShowDialog();

            ReInitializeConfig();
        }

        private void AboutAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FormAbout Form = new();
            Form.ShowDialog();
        }

        private void ExitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListView_Readcontents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Readcontents.SelectedItems.Count > 0)
            {
                listindex = 0;
                listindex = listView_Readcontents.SelectedItems[0].Index;
                button_dump.Enabled = true;
                button_write.Enabled = true;
                button_remove.Enabled = true;
            }
            else
            {
                button_dump.Enabled = false;
                button_write.Enabled = false;
                button_remove.Enabled = false;
            }

        }

        private bool ErrChk(string item)
        {
            if (item.Contains("(-1)"))
            {
                MessageBox.Show(this, Localization.FailedAttachText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel_info.Text = Localization.ErrorOccuredText;
                ResetAll();
                return true;
            }
            if (item.Contains("(-3)"))
            {
                MessageBox.Show(this, Localization.FormattedText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel_info.Text = Localization.ErrorOccuredText;
                ResetAll();
                return true;
            }
            if (item.Contains("(-11)"))
            {
                MessageBox.Show(this, Localization.NotInsertText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel_info.Text = Localization.ErrorOccuredText;
                ResetAll();
                return true;
            }
            if (item.Contains("(-90)"))
            {
                MessageBox.Show(this, Localization.UnableRecognizeText, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetAll();
                toolStripStatusLabel_info.Text = Localization.ErrorOccuredText;
                return true;
            }
            return false;
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

        private void ResetAll()
        {
            listView_Readcontents.Items.Clear();
            button_getinfo.Enabled = false;
            button_dump.Enabled = false;
            button_dumpall.Enabled = false;
            button_write.Enabled = false;
            button_writeall.Enabled = false;
            button_remove.Enabled = false;
            button_dumpimg.Enabled = false;
            button_keydump.Enabled = false;
            button_keywrite.Enabled = false;
            button_format.Enabled = false;
        }

        private void ReInitializeConfig()
        {
            Config.Load(xmlpath);

            switch (bool.Parse(Config.Entry["SETTINGS_DumpLocationFixed"].Value))
            {
                case true:
                    {
                        isfixed = true;
                    }
                    break;
                case false:
                    {
                        isfixed = false;
                    }
                    break;
            }
            switch (bool.Parse(Config.Entry["SETTINGS_CompleteDirectory"].Value))
            {
                case true:
                    {
                        isshowdir = true;
                    }
                    break;
                case false:
                    {
                        isshowdir = false;
                    }
                    break;
            }
            switch (bool.Parse(Config.Entry["SETTINGS_AutoWriteKey"].Value))
            {
                case true:
                    {
                        iskeyautowrite = true;
                    }
                    break;
                case false:
                    {
                        iskeyautowrite = false;
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(Config.Entry["SETTINGS_DumpLocationDirectory"].Value))
            {
                fixeddir = Config.Entry["SETTINGS_DumpLocationDirectory"].Value;
            }
        }

        private void BackupsBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FormBackups formBackups = new();
            formBackups.ShowDialog();
        }

        private static bool CheckUSBDevice(string[] Infobuffer)
        {
            bool pnpIDs = Utils.CheckAdaptorPnPDevicesID();

            if (!pnpIDs)
            {
                Infobuffer[0] = Localization.DeviceNotConnectedCaption;
                return false;
            }

            var usbDevices = Utils.GetUSBDevices();
            var pnpDevices = Utils.GetPnPDevices();

            foreach (var usbDevice in usbDevices)
            {
                foreach (var pnpDevice in pnpDevices)
                {
                    Debug.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}",
                    usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
                    Debug.WriteLine("Name: {0}, PNP Device ID: {1}, Service: {2}",
                    pnpDevice.Name, pnpDevice.PnpDeviceID, pnpDevice.Service);


                    if (pnpDevice.Service.Contains("libusbK") && pnpDevice.Name.Contains("PS3 MemoryCard Adaptor") && pnpIDs)
                    {
                        return true;
                    }
                    else if (usbDevice.Description.Contains("MemoryCard Adaptor with uusbd Driver (x64)") && pnpIDs)
                    {
                        return true;
                    }
                    else if (usbDevice.Description.Contains("MemoryCard Adaptor with uusbd Driver") && pnpIDs)
                    {
                        Infobuffer[0] = "'" + usbDevice.Description + "' is not the proper driver.";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            if (pnpIDs)
            {
                Infobuffer[0] = Localization.DriverNotInstalledCaption;
                return false;
            }
            Infobuffer[0] = "The application cannot be started because the memory card adapter is not connected or the appropriate driver is not installed.";
            return false;
        }

        private void ListView_Readcontents_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_Readcontents.Columns[e.ColumnIndex].Width;
        }

        private void timer_monitor_Tick(object sender, EventArgs e)
        {
            bool isremoved = false, isconnected = false, flag = false;
            bool pnpIDs = Utils.CheckAdaptorPnPDevicesID();

            if (!pnpIDs)
            {
                isremoved = true;
            }
            if (pnpIDs)
            {
                isconnected = true;
            }

            if (isremoved && !flag)
            {
                MessageBox.Show(this, "The memory card adapter has been removed.", Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isremoved = false;
                flag = true;
            }

            if (isconnected && flag)
            {
                MessageBox.Show(this, "The memory card adapter has been connected.", Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                isconnected = false;
                flag = false;
            }
        }

        private async void CheckForUpdatesUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    string hv = null!;

                    using Stream hcs = await Task.Run(() => Common.Network.GetWebStreamAsync(appUpdatechecker, Common.Network.GetUri("https://raw.githubusercontent.com/XyLe-GBP/mca-coh-gui/master/VERSIONINFO")));
                    using StreamReader hsr = new(hcs);
                    hv = await Task.Run(() => hsr.ReadToEndAsync());
                    Common.GitHubLatestVersion = hv[8..].Replace("\n", "");

                    FileVersionInfo ver = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);

                    if (ver.FileVersion != null)
                    {
                        switch (ver.FileVersion.ToString().CompareTo(hv[8..].Replace("\n", "")))
                        {
                            case -1:
                                DialogResult dr = MessageBox.Show(Localization.LatestCaption + hv[8..].Replace("\n", "") + "\n" + Localization.CurrentCaption + ver.FileVersion + "\n" + Localization.UpdateConfirmCaption, Localization.MSGBoxConfirmCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dr == DialogResult.Yes)
                                {
                                    using FormSelectApplicationType formtype = new();
                                    if (formtype.ShowDialog() == DialogResult.Cancel) return;

                                    Common.ProgressType = 7;
                                    Common.ProgressMax = 100;
                                    using FormProgress form = new();
                                    form.ShowDialog();

                                    if (Common.Result == false)
                                    {
                                        Common.cts.Dispose();
                                        MessageBox.Show(Localization.CancelledCaption, Localization.MSGBoxAbortedCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    string updpath = Directory.GetCurrentDirectory()[..Directory.GetCurrentDirectory().LastIndexOf('\\')];
                                    File.Move(Directory.GetCurrentDirectory() + @"\res\updater.exe", updpath + @"\updater.exe");
                                    string wtext;
                                    switch (Common.ApplicationPortable)
                                    {
                                        case false:
                                            {
                                                wtext = Directory.GetCurrentDirectory() + "\r\nrelease";
                                            }
                                            break;
                                        case true:
                                            {
                                                wtext = Directory.GetCurrentDirectory() + "\r\nportable";
                                            }
                                            break;
                                    }
                                    File.WriteAllText(updpath + @"\updater.txt", wtext);
                                    File.Move(updpath + @"\updater.txt", updpath + @"\updater.dat");
                                    if (File.Exists(Directory.GetCurrentDirectory() + @"\res\mca-coh-gui.zip"))
                                    {
                                        File.Move(Directory.GetCurrentDirectory() + @"\res\mca-coh-gui.zip", updpath + @"\mca-coh-gui.zip");
                                    }

                                    ProcessStartInfo pi = new()
                                    {
                                        FileName = updpath + @"\updater.exe",
                                        Arguments = null,
                                        UseShellExecute = true,
                                        WindowStyle = ProcessWindowStyle.Normal,
                                    };
                                    Process.Start(pi);
                                    Close();
                                    return;
                                }
                                else
                                {
                                    DialogResult dr2 = MessageBox.Show(this, Localization.LatestCaption + hv[8..].Replace("\n", "") + "\n" + Localization.CurrentCaption + ver.FileVersion + "\n" + Localization.SiteOpenCaption, Localization.MSGBoxConfirmCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (dr2 == DialogResult.Yes)
                                    {
                                        Common.Utils.OpenURI("https://github.com/XyLe-GBP/mca-coh-gui/releases");
                                        return;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                            case 0:
                                MessageBox.Show(this, Localization.LatestCaption + hv[8..].Replace("\n", "") + "\n" + Localization.CurrentCaption + ver.FileVersion + "\n" + Localization.UptodateCaption, Localization.DoneCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case 1:
                                throw new Exception(hv[8..].Replace("\n", "").ToString() + " < " + ver.FileVersion.ToString());
                        }
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format(Localization.UnExpectedErrorCaption, ex.ToString()), Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, Localization.NetworkNotConnectedCaption, Localization.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async Task CheckForUpdatesForInit()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    string hv = null!;

                    using Stream hcs = await Task.Run(() => Common.Network.GetWebStreamAsync(appUpdatechecker, Common.Network.GetUri("https://raw.githubusercontent.com/XyLe-GBP/mca-coh-gui/master/VERSIONINFO")));
                    using StreamReader hsr = new(hcs);
                    hv = await Task.Run(() => hsr.ReadToEndAsync());
                    Common.GitHubLatestVersion = hv[8..].Replace("\n", "");

                    FileVersionInfo ver = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);

                    if (ver.FileVersion != null)
                    {
                        switch (ver.FileVersion.ToString().CompareTo(hv[8..].Replace("\n", "")))
                        {
                            case -1:
                                DialogResult dr = MessageBox.Show(Localization.LatestCaption + hv[8..].Replace("\n", "") + "\n" + Localization.CurrentCaption + ver.FileVersion + "\n" + Localization.UpdateConfirmCaption, Localization.MSGBoxConfirmCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dr == DialogResult.Yes)
                                {
                                    using FormSelectApplicationType formtype = new();
                                    if (formtype.ShowDialog() == DialogResult.Cancel) return;

                                    Common.ProgressType = 7;
                                    Common.ProgressMax = 100;
                                    using FormProgress form = new();
                                    form.ShowDialog();

                                    if (Common.Result == false)
                                    {
                                        Common.cts.Dispose();
                                        MessageBox.Show(Localization.CancelledCaption, Localization.MSGBoxAbortedCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    string updpath = Directory.GetCurrentDirectory()[..Directory.GetCurrentDirectory().LastIndexOf('\\')];
                                    File.Move(Directory.GetCurrentDirectory() + @"\res\updater.exe", updpath + @"\updater.exe");
                                    string wtext;
                                    switch (Common.ApplicationPortable)
                                    {
                                        case false:
                                            {
                                                wtext = Directory.GetCurrentDirectory() + "\r\nrelease";
                                            }
                                            break;
                                        case true:
                                            {
                                                wtext = Directory.GetCurrentDirectory() + "\r\nportable";
                                            }
                                            break;
                                    }
                                    File.WriteAllText(updpath + @"\updater.txt", wtext);
                                    File.Move(updpath + @"\updater.txt", updpath + @"\updater.dat");
                                    if (File.Exists(Directory.GetCurrentDirectory() + @"\res\mca-coh-gui.zip"))
                                    {
                                        File.Move(Directory.GetCurrentDirectory() + @"\res\mca-coh-gui.zip", updpath + @"\mca-coh-gui.zip");
                                    }

                                    ProcessStartInfo pi = new()
                                    {
                                        FileName = updpath + @"\updater.exe",
                                        Arguments = null,
                                        UseShellExecute = true,
                                        WindowStyle = ProcessWindowStyle.Normal,
                                    };
                                    Process.Start(pi);
                                    Close();
                                    return;
                                }
                                else
                                {
                                    DialogResult dr2 = MessageBox.Show(Localization.LatestCaption + hv[8..].Replace("\n", "") + "\n" + Localization.CurrentCaption + ver.FileVersion + "\n" + Localization.SiteOpenCaption, Localization.MSGBoxConfirmCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (dr2 == DialogResult.Yes)
                                    {
                                        Common.Utils.OpenURI("https://github.com/XyLe-GBP/mca-coh-gui/releases");
                                        return;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                            case 0:
                                break;
                            case 1:
                                throw new Exception(hv[8..].Replace("\n", "").ToString() + " < " + ver.FileVersion.ToString());
                        }
                        return;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

    }
}