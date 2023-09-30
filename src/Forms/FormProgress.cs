using System.Diagnostics;
using static mca_coh_gui.src.Common;
using mca_coh_gui.Localizations;
using System.ComponentModel;

namespace mca_coh_gui
{
    public partial class FormProgress : Form
    {
        public FormProgress()
        {
            InitializeComponent();
        }

        private int DownloadProgress = 0;
        private string DownloadStatus = "";

        private void FormProgress_Load(object sender, EventArgs e)
        {
            Text = Localization.ProcessingText;
            label_log1.Text = Localization.InitializingText;
            label_log2.Text = string.Empty;
            label_log3.Text = string.Empty;
            timer_interval.Interval = 3000;
            progressBar_MainProgress.Value = 0;
            progressBar_MainProgress.Minimum = 0;
            progressBar_MainProgress.Maximum = ProgressMax;

            RunTask();
        }

        private async void RunTask()
        {
            switch (ProgressType)
            {
                case 0: // Dump
                    {
                        label_Progress.Text = Localization.DumpingDataText;
                        cancel = new CancellationTokenSource();
                        var cT = cancel.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => Dump_DoWork(p, cT));
                    }
                    break;
                case 1: // Write
                    {
                        label_Progress.Text = Localization.WritingDataText;
                        cancel = new CancellationTokenSource();
                        var cT = cancel.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => Write_DoWork(p, cT));
                    }
                    break;
                case 2: // Dump Single File
                    {
                        label_Progress.Text = Localization.DumpingDataText;
                        cancel = new CancellationTokenSource();
                        var cT = cancel.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => DumpSingle_DoWork(p, cT));
                    }
                    break;
                case 3: // Write Single File
                    {
                        label_Progress.Text = Localization.WritingDataText;
                        cancel = new CancellationTokenSource();
                        var cT = cancel.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => WriteSingle_DoWork(p, cT));
                    }
                    break;
                case 4: // Dump Image
                    {
                        label_Progress.Text = Localization.DumpingImgText;
                        cancel = new CancellationTokenSource();
                        var cT = cancel.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => DumpImage_DoWork(p, cT));
                    }
                    break;
                case 5: // Remove
                    {
                        label_Progress.Text = Localization.RemovingDataText;
                        cancel = new CancellationTokenSource();
                        var cT = cancel.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => Remove_DoWork(p, cT));
                    }
                    break;
                case 6: // Format
                    {
                        label_Progress.Text = Localization.FormatProgressText;
                        cancel = new CancellationTokenSource();
                        var cT = cancel.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => Format_DoWork(p, cT));
                    }
                    break;
                case 7: // Update
                    {
                        label_Progress.Text = Localization.ProcessingText;
                        cts = new CancellationTokenSource();
                        var cT = cts.Token;
                        var p = new Progress<int>(UpdateProgress);

                        Result = await Task.Run(() => Download_DoWork(p, cT));
                    }
                    break;
                default:
                    {
                        label_Progress.Text = Localization.ProcessUnknownText;
                    }
                    break;
            }
            timer_interval.Enabled = true;
        }

        private static bool Dump_DoWork(IProgress<int> p, CancellationToken cT)
        {
            Config.Load(xmlpath);
            switch (bool.Parse(Config.Entry["SETTINGS_DumpLocationFixed"].Value))
            {
                case true:
                    {
                        int lp = 0;
                        foreach (var item in Donglefilenames)
                        {
                            ProcessStartInfo? psi = new()
                            {
                                FileName = ResourcesDir + @"\mca-coh.exe",
                                Arguments = "-x " + item + " \"" + Config.Entry["SETTINGS_DumpLocationDirectory"].Value + @"\" + item + "\"",
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                            };
                            Process? ps = Process.Start(psi);
                            if (ps is not null)
                            {
                                string log = ps.StandardOutput.ReadToEnd();
                                ReadLogtext = Utils.MCALogSplitRead(log);
                                WriteLogtext = Utils.MCALogSplitWrite(log);
                                lp++;
                                p.Report(lp);
                            }
                        }
                        return true;
                    }
                case false:
                    {
                        int lp = 0;
                        foreach (var item in Donglefilenames)
                        {
                            ProcessStartInfo? psi = new()
                            {
                                FileName = ResourcesDir + @"\mca-coh.exe",
                                Arguments = "-x " + item + " \"" + SaveLocation + @"\" + item + "\"",
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                            };
                            Process? ps = Process.Start(psi);
                            if (ps is not null)
                            {
                                string log = ps.StandardOutput.ReadToEnd();
                                ReadLogtext = Utils.MCALogSplitRead(log);
                                WriteLogtext = Utils.MCALogSplitWrite(log);
                                lp++;
                                p.Report(lp);
                            }
                        }
                        return true;
                    }
            }
        }

        private static bool DumpSingle_DoWork(IProgress<int> p, CancellationToken cT)
        {
            Config.Load(xmlpath);
            switch (bool.Parse(Config.Entry["SETTINGS_DumpLocationFixed"].Value))
            {
                case true:
                    {
                        int lp = 0;
                        ProcessStartInfo? psi = new()
                        {
                            FileName = ResourcesDir + @"\mca-coh.exe",
                            Arguments = "-x " + ListviewName + " \"" + SaveLocation + @"\" + ListviewName + "\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                        };
                        Process? ps = Process.Start(psi);
                        if (ps is not null)
                        {
                            string log = ps.StandardOutput.ReadToEnd();
                            ReadLogtext = Utils.MCALogSplitRead(log);
                            WriteLogtext = Utils.MCALogSplitWrite(log);
                            lp++;
                            p.Report(lp);
                        }
                        return true;
                    }
                case false:
                    {
                        int lp = 0;
                        ProcessStartInfo? psi = new()
                        {
                            FileName = ResourcesDir + @"\mca-coh.exe",
                            Arguments = "-x " + ListviewName + " \"" + SaveLocation + "\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                        };
                        Process? ps = Process.Start(psi);
                        if (ps is not null)
                        {
                            string log = ps.StandardOutput.ReadToEnd();
                            ReadLogtext = Utils.MCALogSplitRead(log);
                            WriteLogtext = Utils.MCALogSplitWrite(log);
                            lp++;
                            p.Report(lp);
                        }
                        return true;
                    }
            }
        }

        private static bool DumpImage_DoWork(IProgress<int> p, CancellationToken cT)
        {
            Config.Load(xmlpath);
            switch (bool.Parse(Config.Entry["SETTINGS_DumpLocationFixed"].Value))
            {
                case true:
                    {
                        int lp = 0;
                        ProcessStartInfo? psi = new()
                        {
                            FileName = ResourcesDir + @"\mca-coh.exe",
                            Arguments = "-img \"" + SaveLocation + @"\dongle.img" + "\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                        };
                        Process? ps = Process.Start(psi);
                        if (ps is not null)
                        {
                            string log = ps.StandardOutput.ReadToEnd();
                            ReadLogtext = Utils.MCALogSplitRead(log);
                            WriteLogtext = Utils.MCALogSplitWrite(log);
                            lp++;
                            p.Report(lp);
                        }
                        return true;
                    }
                case false:
                    {
                        int lp = 0;
                        ProcessStartInfo? psi = new()
                        {
                            FileName = ResourcesDir + @"\mca-coh.exe",
                            Arguments = "-img \"" + SaveLocation + "\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                        };
                        Process? ps = Process.Start(psi);
                        if (ps is not null)
                        {
                            string log = ps.StandardOutput.ReadToEnd();
                            ReadLogtext = Utils.MCALogSplitRead(log);
                            WriteLogtext = Utils.MCALogSplitWrite(log);
                            lp++;
                            p.Report(lp);
                        }
                        return true;
                    }
            }
        }

        private static bool Write_DoWork(IProgress<int> p, CancellationToken cT)
        {
            int lp = 0;
            foreach (var item in Directory.GetFiles(SaveLocation, "*", SearchOption.TopDirectoryOnly))
            {
                ProcessStartInfo? psi2 = new()
                {
                    FileName = ResourcesDir + @"\mca-coh.exe",
                    Arguments = "-in \"" + item + "\" " + Path.GetFileName(item),
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                };
                Process? ps = Process.Start(psi2);
                if (ps is not null)
                {
                    string log = ps.StandardOutput.ReadToEnd();
                    ReadLogtext = Utils.MCALogSplitRead(log);
                    WriteLogtext = Utils.MCALogSplitWrite(log);
                    lp++;
                    p.Report(lp);
                }
            }
            return true;
        }

        private static bool WriteSingle_DoWork(IProgress<int> p, CancellationToken cT)
        {
            int lp = 0;
            ProcessStartInfo psi = new()
            {
                FileName = ResourcesDir + @"\mca-coh.exe",
                Arguments = "-in \"" + SaveLocation + "\" " + Path.GetFileName(SaveLocation),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            Process? ps = Process.Start(psi);
            if (ps is not null)
            {
                string log = ps.StandardOutput.ReadToEnd();
                ReadLogtext = Utils.MCALogSplitRead(log);
                WriteLogtext = Utils.MCALogSplitWrite(log);
                lp++;
                p.Report(lp);
            }
            return true;
        }

        private static bool Remove_DoWork(IProgress<int> p, CancellationToken cT)
        {
            int lp = 0;
            ProcessStartInfo psi = new()
            {
                FileName = ResourcesDir + @"\mca-coh.exe",
                Arguments = "-rm " + SaveLocation,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            Process? ps = Process.Start(psi);
            if (ps is not null)
            {
                string log = ps.StandardOutput.ReadToEnd();
                ReadLogtext = Utils.MCALogSplitRead(log);
                WriteLogtext = Utils.MCALogSplitWrite(log);
                lp++;
                p.Report(lp);
            }
            return true;
        }

        private static bool Format_DoWork(IProgress<int> p, CancellationToken cT)
        {
            int lp = 0;
            ProcessStartInfo psi = new()
            {
                FileName = ResourcesDir + @"\mca-coh.exe",
                Arguments = "--mc-format",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            Process? ps = Process.Start(psi);
            if (ps is not null)
            {
                string log = ps.StandardOutput.ReadToEnd();
                ReadLogtext = Utils.MCALogSplitRead(log);
                WriteLogtext = Utils.MCALogSplitWrite(log);
                lp++;
                p.Report(lp);
            }
            return true;
        }

        private bool Download_DoWork(IProgress<int> p, CancellationToken cToken)
        {
            if (downloadClient == null)
            {
#pragma warning disable SYSLIB0014 // 型またはメンバーが旧型式です
                downloadClient = new System.Net.WebClient();
#pragma warning restore SYSLIB0014 // 型またはメンバーが旧型式です
                downloadClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DownloadClient_DownloadProgressChanged);
                downloadClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadClient_DownloadFileCompleted);
            }

            Invoke(new Action(() => Text = Localization.FormDownloadingCaption));
            var task = Download(cToken);

            while (task.IsCompleted != true)
            {
                if (task.Result == false)
                {
                    return false;
                }
            }
            if (cToken.IsCancellationRequested == true)
            {
                return false;
            }
            else
            {
                Invoke(new Action(() => Text = Localization.ProcessingText));
                Invoke(new Action(() => label_Progress.Text = Localization.ProcessingText));
                Invoke(new Action(() => button_Abort.Enabled = false));
            }

            return true;
        }

        private async Task<bool> Download(CancellationToken cToken)
        {
            Uri uri;

            switch (ApplicationPortable)
            {
                case false:
                    {
                        uri = new("https://github.com/XyLe-GBP/mca-coh-gui/releases/download/v" + GitHubLatestVersion + "/mca-coh-gui-release.zip");
                    }
                    break;
                case true:
                    {
                        uri = new("https://github.com/XyLe-GBP/mca-coh-gui/releases/download/v" + GitHubLatestVersion + "/mca-coh-gui-portable.zip");
                    }
                    break;
            }

            switch (ApplicationPortable)
            {
                case false: // release
                    {
                        downloadClient.DownloadFileAsync(uri, Directory.GetCurrentDirectory() + @"\res\mca-coh-gui.zip");
                    }
                    break;
                case true: // portable
                    {
                        downloadClient.DownloadFileAsync(uri, Directory.GetCurrentDirectory() + @"\res\mca-coh-gui.zip");
                    }
                    break;
            }
            IsDownloading = true;

            while (downloadClient.IsBusy)
            {
                if (cToken.IsCancellationRequested == true)
                {
                    return await Task.FromResult(false);
                }
                Invoke(new Action(() => progressBar_MainProgress.Value = DownloadProgress));
                Invoke(new Action(() => label_log1.Text = DownloadStatus));
            }
            return await Task.FromResult(true);
        }

        private void DownloadClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            if (IsDownloading == true)
            {
                progressBar_MainProgress.Maximum = 100;
                IsDownloading = false;
            }
            DownloadProgress = e.ProgressPercentage;
            DownloadStatus = string.Format(Localization.DownloadingCaption, e.ProgressPercentage, e.TotalBytesToReceive / 1024, e.BytesReceived / 1024);
        }

        private void DownloadClient_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled) // Cancelled
            {
                downloadClient!.Dispose();
            }
            else if (e.Error != null) // Error
            {
                downloadClient!.Dispose();
            }
            else
            {
                downloadClient!.Dispose();
            }
        }

        private void UpdateProgress(int p)
        {
            switch (ProgressType)
            {
                case 6:
                    {
                        progressBar_MainProgress.Value = p;
                        label_log1.Text = string.Format(Localization.FormatCompleteProgressText, p, Count);
                        label_log2.Text = string.Format("{0}", ReadLogtext);
                        label_log3.Text = string.Format("{0}", WriteLogtext);
                        break;
                    }
                default:
                    progressBar_MainProgress.Value = p;
                    label_log1.Text = string.Format(Localization.ProgressText, p, Count);
                    label_log2.Text = string.Format("{0}", ReadLogtext);
                    label_log3.Text = string.Format("{0}", WriteLogtext);
                    break;
            }
        }

        private void Timer_interval_Tick(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
            Close();
        }

        private void button_Abort_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                if (downloadClient.IsBusy)
                {
                    DialogResult dr = MessageBox.Show(Localization.DownloadAbortConfirmCaption, Localization.WarningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        cts.Cancel();
                        downloadClient.CancelAsync();
                        Close();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    cancel.Cancel();
                    Close();
                }
            }
        }
    }
}
