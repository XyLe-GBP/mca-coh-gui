using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace mca_coh_gui.src
{
    public class Common
    {
        internal static readonly string CurrentDir = Directory.GetCurrentDirectory();
        internal static readonly string ResourcesDir = Directory.GetCurrentDirectory() + @"\res";
        internal static readonly string mcaApplicationPath = Directory.GetCurrentDirectory() + @"\res\mca-coh.exe";
        internal static readonly string xmlpath = CurrentDir + @"\app.config";
        internal static string[]? Donglefilenames;
        internal static string? ListviewName;
        internal static string? SaveLocation;
        internal static string? Bootbin_Location;

        internal static CancellationTokenSource? cancel;
        internal static int ProgressType = 0;　// 処理タイプ
        internal static int ProcessFlag = -1;
        internal static int ProgressMax;
        internal static int Count;
        internal static string? ReadLogtext;
        internal static string? WriteLogtext;
        internal static bool Result = false;
        internal static bool IsGetInfo = false;

        internal static bool Locationisfixed = false;

        public class Generals
        {
            internal static void InitConfig()
            {
                if (Config.Entry["SETTINGS_DumpLocationFixed"].Value == null)
                {
                    Config.Entry["SETTINGS_DumpLocationFixed"].Value = "false";
                }
                if (Config.Entry["SETTINGS_DumpLocationDirectory"].Value == null)
                {
                    Config.Entry["SETTINGS_DumpLocationDirectory"].Value = "";
                }
                if (Config.Entry["SETTINGS_AutoWriteKey"].Value == null)
                {
                    Config.Entry["SETTINGS_AutoWriteKey"].Value = "true";
                }
                if (Config.Entry["SETTINGS_CompleteDirectory"].Value == null)
                {
                    Config.Entry["SETTINGS_CompleteDirectory"].Value = "true";
                }
                Config.Save(xmlpath);
            }

            /// <summary>
            /// 完了後に保存先のフォルダを開く
            /// </summary>
            /// <param name="path">フォルダのフルパス</param>
            /// <param name="flag">フラグ</param>
            internal static void IsCompletedShowDirectory(string path, bool flag)
            {
                switch (flag)
                {
                    case true:
                        {
                            Process.Start("EXPLORER.EXE", @"/select,""" + path + @"""");
                        }
                        break;
                    case false:
                        {
                        }
                        break;
                }
            }
        }

        public class Utils
        {
            /// <summary>
            /// Process.Start: Open URI for .NET
            /// </summary>
            /// <param name="URI">http://~ または https://~ から始まるウェブサイトのURL</param>
            public static void OpenURI(string URI)
            {
                try
                {
                    Process.Start(URI);
                }
                catch
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        //Windowsのとき  
                        URI = URI.Replace("&", "^&");
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {URI}") { CreateNoWindow = true });
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        //Linuxのとき  
                        Process.Start("xdg-open", URI);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        //Macのとき  
                        Process.Start("open", URI);
                    }
                    else
                    {
                        throw;
                    }
                }

                return;
            }

            /// <summary>
            /// 現在の時刻を取得する
            /// </summary>
            /// <returns>YYYY-MM-DD-HH-MM-SS (例：2000-01-01-00-00-00)</returns>
            public static string SFDRandomNumber()
            {
                DateTime dt = DateTime.Now;
                return dt.Year + "-" + dt.Month + "-" + dt.Day + "-" + dt.Hour + "-" + dt.Minute + "-" + dt.Second;
            }

            /// <summary>
            /// 読み込みログを取得
            /// </summary>
            /// <param name="logs">標準出力のバッファ</param>
            /// <returns></returns>
            public static string MCALogSplitRead(string logs)
            {
                logs = logs.Replace(Environment.NewLine, "\r");
                logs = logs.Trim('\r');
                string[] list = logs.Split('\r');
                foreach (var item in list)
                {
                    if (!item.Contains("PS3") && item.Contains("Reading"))
                    {
                        return item;
                    }
                    if (!item.Contains("PS3") && item.Contains("Error"))
                    {
                        return item;
                    }
                }
                return "";
            }

            /// <summary>
            /// 書き込みログを取得
            /// </summary>
            /// <param name="logs">標準出力のバッファ</param>
            /// <returns></returns>
            public static string MCALogSplitWrite(string logs)
            {
                logs = logs.Replace(Environment.NewLine, "\r");
                logs = logs.Trim('\r');
                string[] list = logs.Split('\r');
                foreach (var item in list)
                {
                    if (!item.Contains("PS3") && item.Contains("Writing"))
                    {
                        return item;
                    }
                }
                return "";
            }

            /// <summary>
            /// boot.binをダンプ
            /// </summary>
            /// <param name="path">保存先のフルパス</param>
            public static void DumpBootFile(string path)
            {
                ProcessStartInfo? psi = new()
                {
                    FileName = ResourcesDir + @"\mca-coh.exe",
                    Arguments = "-x boot.bin \"" + path + "\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                };
                Process? ps = Process.Start(psi);
                ps.WaitForExit();
                return;
            }

            public static void FormatDongle()
            {
                ProcessStartInfo? psi = new()
                {
                    FileName = ResourcesDir + @"\mca-coh.exe",
                    Arguments = "--mc-format",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                };
                Process? ps = Process.Start(psi);
                ps.WaitForExit();
                return;
            }

            /// <summary>
            /// boot.binからキーをダンプ、書き込み
            /// </summary>
            /// <param name="file">ファイルのフルパス</param>
            /// <param name="flag">処理フラグ, 0=ダンプ, 1=書き込み</param>
            /// <returns></returns>
            public static string DumpOrWriteKey(string file, int flag)
            {
                switch (flag)
                {
                    case 0: // Dump boot.bin 28-47 bytes.
                        {
                            using var fs = new FileStream(file, FileMode.Open);
                            using var br = new BinaryReader(fs);
                            int len = 100;
                            byte[] r_data = new byte[len];
                            br.Read(r_data, 0, len);

                            // 読み込み済みバイト配列の表示
                            Debug.Write("r_keydata: ");
                            int ct = 0;
                            byte[] key = new byte[38];
                            List<byte> bt = new();
                            foreach (var item in r_data)
                            {
                                if (ct == 72)
                                {
                                    key = bt.ToArray();
                                    break;
                                }
                                if (ct >= 40)
                                {
                                    bt.Add(item);
                                }
                                ct++;
                            }
                            SaveFileDialog sfd = new()
                            {
                                FileName = "key.hex",
                                InitialDirectory = "",
                                Filter = Localizations.Localization.Filter_Key,
                                RestoreDirectory = true
                            };
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                using var fswrite = new FileStream(sfd.FileName, FileMode.Create);
                                using var bw = new BinaryWriter(fswrite);
                                bw.Write(key);
                            }
                            else
                            {
                                return string.Empty;
                            }
                            return sfd.FileName;
                        }
                    case 1: // Write keyfile boot.bin 28-47 bytes.
                        {
                            using var fs = new FileStream(file, FileMode.Open);
                            using var br = new BinaryReader(fs);
                            int len = 32;
                            byte[] r_data = new byte[len];
                            br.Read(r_data, 0, len);

                            OpenFileDialog ofd = new()
                            {
                                FileName = "boot.bin",
                                InitialDirectory = "",
                                Filter = Localizations.Localization.Filter_boot,
                                RestoreDirectory = true
                            };
                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                using var fswrite = new FileStream(ofd.FileName, FileMode.Open);
                                using var bw = new BinaryWriter(fswrite);
                                bw.Seek(40, SeekOrigin.Begin);
                                bw.Write(r_data);
                            }
                            else
                            {
                                return string.Empty;
                            }
                            return ofd.FileName;
                        }
                    default:
                        {
                            return "";
                        }
                }

            }

            /// <summary>
            /// boot.binからキーをダンプ、書き込み (自動版)
            /// </summary>
            /// <param name="file">ファイルのフルパス</param>
            /// <param name="flag">処理フラグ, 0=ダンプ, 1=書き込み</param>
            /// <returns></returns>
            public static string DumpOrWriteKeyWithAutoKey(string file, int flag)
            {
                switch (flag)
                {
                    case 0: // Dump boot.bin 28-47 bytes.
                        {
                            using var fs = new FileStream(file, FileMode.Open);
                            using var br = new BinaryReader(fs);
                            int len = 100;
                            byte[] r_data = new byte[len];
                            br.Read(r_data, 0, len);

                            // 読み込み済みバイト配列の表示
                            Debug.Write("r_keydata: " + CheckRWByte(r_data));
                            int ct = 0;
                            byte[] key = new byte[38];
                            List<byte> bt = new();
                            foreach (var item in r_data)
                            {
                                if (ct == 72)
                                {
                                    key = bt.ToArray();
                                    break;
                                }
                                if (ct >= 40)
                                {
                                    bt.Add(item);
                                }
                                ct++;
                            }
                            string name = string.Empty;
                            if (!IsGetInfo)
                            {
                                name = CurrentDir + @"\keys\key_" + SFDRandomNumber() + ".hex";
                            }
                            else
                            {
                                name = CurrentDir + @"\key_" + SFDRandomNumber() + ".hex";
                            }

                            using var fswrite = new FileStream(name, FileMode.Create);
                            using var bw = new BinaryWriter(fswrite);
                            bw.Write(key);

                            return name;
                        }
                    case 1: // Write keyfile boot.bin 28-47 bytes.
                        {
                            using var fs = new FileStream(file, FileMode.Open);
                            using var br = new BinaryReader(fs);
                            int len = 32;
                            byte[] r_data = new byte[len];
                            br.Read(r_data, 0, len);

                            Debug.Write("r_keydata: " + CheckRWByte(r_data));

                            using var fswrite = new FileStream(Bootbin_Location, FileMode.Open);
                            using var bw = new BinaryWriter(fswrite);
                            bw.Seek(40, SeekOrigin.Begin);
                            bw.Write(r_data);

                            Debug.Write("w_keydata: " + CheckRWByte(r_data));

                            return Bootbin_Location;
                        }
                    default:
                        {
                            return "";
                        }
                }

            }

            /// <summary>
            /// キーが書き込まれているかどうかの検証
            /// </summary>
            /// <param name="file">boot.binファイル</param>
            /// <param name="keyfile">キーファイル</param>
            /// <param name="verifydata">検証結果の戻り値</param>
            /// <returns></returns>
            public static bool KeyVerify(string file, string keyfile, string[] verifydata)
            {
                using var fs1 = new FileStream(file, FileMode.Open);
                using var fs2 = new FileStream(keyfile, FileMode.Open);
                using var br1 = new BinaryReader(fs1);
                using var br2 = new BinaryReader(fs2);
                int len = 100, len2 = 32;
                byte[] r_data = new byte[len], r_data2 = new byte[len2];
                br1.Read(r_data, 0, len);
                br2.Read(r_data2, 0, len2);

                // 読み込み済みバイト配列の表示
                Debug.Write("r_bindata: " + CheckRWByte(r_data) + "\r\n");
                Debug.Write("r_keydata: " + CheckRWByte(r_data2) + "\r\n");
                int ct = 0;
                byte[] key = new byte[38];
                List<byte> bt = new();
                foreach (var item in r_data)
                {
                    if (ct == 72)
                    {
                        key = bt.ToArray();
                        break;
                    }
                    if (ct >= 40)
                    {
                        bt.Add(item);
                    }
                    ct++;
                }

                if (ByteArrayCompare(key, r_data2))
                {
                    verifydata[0] = string.Format("{0:X2}", CheckRWByte(key));
                    verifydata[1] = string.Format("{0:X2}", CheckRWByte(r_data2));
                    return true;
                }
                else
                {
                    verifydata[0] = string.Format("{0:X2}", CheckRWByte(key));
                    verifydata[1] = string.Format("{0:X2}", CheckRWByte(r_data2));
                    return false;
                }
            }

            /// <summary>
            /// キーファイルからキー配列を取得
            /// </summary>
            /// <param name="file">キーファイルのフルパス</param>
            /// <returns></returns>
            public static string GetKey(string file)
            {
                using var fs = new FileStream(file, FileMode.Open);
                using var br = new BinaryReader(fs);
                int len = 32;
                byte[] r_data = new byte[len];
                br.Read(r_data, 0, len);

                return CheckRWByte(r_data);
            }

            /// <summary>
            /// キーファイルから読み込んだバイト配列から文字列に変換
            /// </summary>
            /// <param name="bytes">バイト配列</param>
            /// <returns></returns>
            public static string CheckRWByte(byte[] bytes)
            {
                string outp = string.Empty;
                foreach (var item in bytes)
                {
                    outp += string.Format("{0:X2}", item);
                }
                return outp;
            }

            /// <summary>
            /// ドングルのtitle.txtから情報を取得
            /// </summary>
            /// <param name="buffers">戻り値を格納するstring配列</param>
            public static void GetDongleTitle(string[] buffers)
            {
                ProcessStartInfo? psi = new()
                {
                    FileName = ResourcesDir + @"\mca-coh.exe",
                    Arguments = "-x title.txt \"" + Directory.GetCurrentDirectory() + @"\title.txt" + "\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                };
                Process? p = Process.Start(psi);
                if (p is not null)
                {
                    p.WaitForExit();
                    using StreamReader sr = new(Directory.GetCurrentDirectory() + @"\title.txt");
                    string readtitle = sr.ReadToEnd();
                    sr.Close();
                    readtitle = readtitle.Replace("\n", "\r");
                    readtitle = readtitle.Trim('\r');
                    string[] readtitlelist = readtitle.Split('\r');
                    foreach (var item in readtitlelist)
                    {
                        if (item.Contains("MAKER:"))
                        {
                            buffers[0] = item.Replace("MAKER:", "");
                        }
                        if (item.Contains("TITLE:NM"))
                        {
                            buffers[1] = item.Replace("TITLE:NM", "NM");
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            /// <summary>
            /// ドングルのタイトル番号からゲーム名を取得
            /// </summary>
            /// <param name="titlestring">タイトル番号 (NM*****)</param>
            /// <returns></returns>
            public static string GetGameName(string titlestring)
            {
                if (!string.IsNullOrEmpty(titlestring))
                {
                    if (titlestring == "NM00010")
                    {
                        return "Battle Gear 3 (バトルギア3)";
                    }
                    if (titlestring == "NM00015")
                    {
                        return "Battle Gear 3: Tuned (バトルギア3 Tuned)";
                    }
                    if (titlestring == "NM00002")
                    {
                        return "Bloody Roar 3 (ブラッディロア3)";
                    }
                    if (titlestring == "NM00018")
                    {
                        return "Capcom Fighting Jam (カプコン ファイティング ジャム)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Capcom Fighting All Stars (カプコン ファイティング オールスターズ)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Cobra: The Arcade (コブラ・ザ・アーケード)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Dragon Chronicle: Legend of the Master Ark (ドラゴンクロニクル 伝説のマスターアーク)";
                    }
                    if (titlestring == "NM00020")
                    {
                        return "Dragon Chronicle: Online (ドラゴンクロニクル オンライン)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Dragon Chronicle II (ドラゴンクロニクル2)";
                    }
                    if (titlestring == "NM00028")
                    {
                        return "Druaga Online: The Story of Aon (ドルアーガオンライン The Story of Aon)";
                    }
                    if (titlestring == "NM00048")
                    {
                        return "Fate/Unlimited Codes (フェイト/アンリミテッドコード)";
                    }
                    if (titlestring == "NM00022")
                    {
                        return "The iDOLM@STER (アイドルマスター)";
                    }
                    if (titlestring == "NM00029")
                    {
                        return "Kinnikuman: Muscle Grand Prix (キン肉マン マッスルグランプリ)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Kinnikuman: Muscle Grand Prix 2 (キン肉マン マッスルグランプリ2)";
                    }
                    if (titlestring == "NM00043")
                    {
                        return "Mobile Suit Gundam: Gundam vs. Gundam (機動戦士ガンダム ガンダムVS.ガンダム)";
                    }
                    if (titlestring == "NM00052")
                    {
                        return "Mobile Suit Gundam: Gundam vs. Gundam Next (機動戦士ガンダム ガンダム vs. ガンダム NEXT)";
                    }
                    if (titlestring == "NM00024")
                    {
                        return "Mobile Suit Gundam Seed: Rengou vs. ZAFT (機動戦士ガンダムSEED 連合 vs. Z.A.F.T.)";
                    }
                    if (titlestring == "NM00034")
                    {
                        return "Mobile Suit Gundam Seed Destiny: Rengou vs. ZAFT II (機動戦士ガンダムSEED Destiny 連合 vs. Z.A.F.T. II)";
                    }
                    if (titlestring == "NM00013")
                    {
                        return "Mobile Suit Z Gundam: AEUG vs. Titans (機動戦士Ζガンダム エゥーゴ vs. ティターンズ)";
                    }
                    if (titlestring == "NM00017")
                    {
                        return "Mobile Suit Z Gundam: AEUG vs. Titans DX (機動戦士Ζガンダム エゥーゴ vs. ティターンズ DX)";
                    }
                    if (titlestring == "NM00036")
                    {
                        return "Minna de Kitaeru Zenno Training (みんなで鍛える全脳トレーニング)";
                    }
                    if (titlestring == "NM00009")
                    {
                        return "Netchuu Pro Yakyuu 2002 (熱チュー！プロ野球2002)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Pride GP 2003";
                    }
                    if (titlestring == "NM00030")
                    {
                        return "Quiz Kidou Senshi Gundam: Tou Senshi (クイズ機動戦士ガンダム 問・戦士)";
                    }
                    if (titlestring == "NM00001")
                    {
                        return "Ridge Racer V: Arcade Battle (リッジレーサーV アーケードバトル)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Rockman EXE: Battle Chip Stadium (ロックマンエグゼ バトルチップスタジアム)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Samurai Surf X (波侍 サムライサーフX)";
                    }
                    if (titlestring == "NM00042")
                    {
                        return "Sengoku Basara X (戦国バサラX)";
                    }
                    if (titlestring == "NM00006")
                    {
                        return "Smash Court Pro Tournament (スマッシュコート プロトーナメント)";
                    }
                    if (titlestring == "NM00007")
                    {
                        return "Soul Calibur II (ソウルキャリバーII)";
                    }
                    if (titlestring == "NM00031")
                    {
                        return "Soul Calibur III: Arcade Edition (ソウルキャリバーIII)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Starblade: Operation Blue Planet (スターブレード オペレーションブループラネット)";
                    }
                    if (titlestring == "NM00037")
                    {
                        return "Quiz & Variety SukuSuku Inufuku 2: More SukuSuku (クイズ＆バラエテイすくすく犬福２: もつとすくすく)";
                    }
                    if (titlestring == "NM00027")
                    {
                        return "Super Dragon Ball Z (超ドラゴンボールZ)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Taiko Drum Master 7 / Taiko no Tatsujin 7 (太鼓の達人7)";
                    }
                    if (titlestring == "NM00033")
                    {
                        return "Taiko Drum Master 8 / Taiko no Tatsujin 8 (太鼓の達人8)";
                    }
                    if (titlestring == "NM00038")
                    {
                        return "Taiko Drum Master 9 / Taiko no Tatsujin 9 (太鼓の達人9)";
                    }
                    if (titlestring == "NM00041")
                    {
                        return "Taiko Drum Master 10 / Taiko no Tatsujin 10 (太鼓の達人10)";
                    }
                    if (titlestring == "NM00044")
                    {
                        return "Taiko Drum Master 11 / Taiko no Tatsujin 11 (太鼓の達人11)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Taiko Drum Master 11 Asian Version / Taiko no Tatsujin 11 A (太鼓の達人11 亚洲版)";
                    }
                    if (titlestring == "NM00051")
                    {
                        return "Taiko Drum Master 12 / Taiko no Tatsujin 12 (太鼓の達人12)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Taiko Drum Master 12 Asian Version / Taiko no Tatsujin 12 A (太鼓の達人12 亚洲版)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Taiko Drum Master 13 / Taiko no Tatsujin 13 (太鼓の達人13)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Taiko Drum Master 14 / Taiko no Tatsujin 14 (太鼓の達人14)";
                    }
                    if (titlestring == "NM00003")
                    {
                        return "Technic Beat (テクニクビート)";
                    }
                    if (titlestring == "NM00004")
                    {
                        return "Tekken 4 (鉄拳4)";
                    }
                    if (titlestring == "NM00019")
                    {
                        return "Tekken 5 (鉄拳5)";
                    }
                    if (titlestring == "NM00026")
                    {
                        return "Tekken 5: Dark Resurrection (鉄拳5 Dark Resurrection)";
                    }
                    if (titlestring == "NM00035")
                    {
                        return "The Battle of Yu Yu Hakusho: Dark Tournament (The Battle of幽遊白書 死闘! 暗黒武術会)";
                    }
                    if (titlestring == "NM00012")
                    {
                        return "Time Crisis 3 (タイムクライシス3)";
                    }
                    if (titlestring == "NM00032")
                    {
                        return "Time Crisis 4　(タイムクライシス4)";
                    }
                    if (titlestring == "NM00003")
                    {
                        return "Vampire Night (ヴァンパイアナイト)";
                    }
                    if (titlestring == "NM00008")
                    {
                        return "Wangan Midnight (湾岸ミッドナイト)";
                    }
                    if (titlestring == "NM000**")
                    {
                        return "Wangan Midnight (湾岸ミッドナイトR)";
                    }
                    if (titlestring == "NM00016")
                    {
                        return "Zoids Infinity (ゾイドインフィニティ)";
                    }
                    if (titlestring == "NM00025")
                    {
                        return "Zoids Infinity Ex (ゾイドインフィニティ EX)";
                    }
                    return "Unknown Game";
                }
                else
                {
                    return "Unknown Game";
                }
            }

            public static string ErrorCheck()
            {
                string read;
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
                    List<string> list = new();
                    read = p.StandardOutput.ReadToEnd();
                    read = read.Replace(Environment.NewLine, "\r");
                    read = read.Trim('\r');
                    string[] readlist = read.Split('\r');


                    foreach (var item in readlist)
                    {
                        if (item.Contains("(-1)"))
                        {
                            return "(-1)";
                        }
                        if (item.Contains("(-3)"))
                        {
                            return "(-3)";
                        }
                        if (item.Contains("(-11)"))
                        {
                            return "(-11)";
                        }
                        if (item.Contains("(-90)"))
                        {
                            return "(-90)";
                        }
                    };
                    return string.Empty;
                }
                else
                {
                    return "(-99)";
                }
            }

            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int memcmp(byte[] b1, byte[] b2, UIntPtr count);

            public static bool ByteArrayCompare(byte[] a, byte[] b)
            {
                if (ReferenceEquals(a, b))
                {
                    return true;
                }
                if (a == null || b == null || a.Length != b.Length)
                {
                    return false;
                }

                return memcmp(a, b, new UIntPtr((uint)a.Length)) == 0;
            }
        }

        public class Config
        {
            /// <summary>
            /// ルートエントリ
            /// </summary>
            public static ConfigEntry Entry = new() { Key = "ConfigRoot" };
            public static void Load(string filename)
            {
                if (!File.Exists(filename))
                    return;
                var xmlSerializer = new XmlSerializer(typeof(ConfigEntry));
                using var streamReader = new StreamReader(filename, Encoding.UTF8);
                using var xmlReader = XmlReader.Create(streamReader, new XmlReaderSettings() { CheckCharacters = false });
                Entry = (ConfigEntry)xmlSerializer.Deserialize(xmlReader)!; // （3）
            }
            public static void Save(string filename)
            {
                var serializer = new XmlSerializer(typeof(ConfigEntry));
                using var streamWriter = new StreamWriter(filename, false, Encoding.UTF8);
                serializer.Serialize(streamWriter, Entry);
            }
        }

        /// <summary>
        /// ConfigEntryクラス。設定の1レコード
        /// </summary>
        public class ConfigEntry
        {
            /// <summary>
            /// 設定レコードののキー
            /// </summary>
            public string Key { get; set; }
            /// <summary>
            /// 設定レコードの値
            /// </summary>
            public string Value { get; set; }
            /// <summary>
            /// 子アイテム
            /// </summary>
            public List<ConfigEntry>? Children { get; set; }
            /// <summary>
            /// キーを指定して子アイテムからConfigEntryを取得します。
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public ConfigEntry Get(string key)
            {
                var entry = Children?.FirstOrDefault(rec => rec.Key == key);
                if (entry == null)
                {
                    if (Children == null)
                        Children = new List<ConfigEntry>();
                    entry = new ConfigEntry() { Key = key };
                    Children.Add(entry);
                }
                return entry;
            }
            /// <summary>
            /// 子アイテムにConfigEntryを追加します。
            /// </summary>
            /// <param name="key">キー</param>
            /// <param name="o">設定値</param>
            public void Add(string key, string? o)
            {
                ConfigEntry? entry = Children?.FirstOrDefault(rec => rec.Key == key);
                if (entry != null)
                    entry.Value = o;
                else
                {
                    if (Children == null)
                        Children = new List<ConfigEntry>();
                    entry = new ConfigEntry() { Key = key, Value = o };
                    Children.Add(entry);
                }
            }
            /// <summary>
            /// 子アイテムからConfigEntryを取得します。存在しなければ新しいConfigEntryが作成されます。
            /// </summary>
            /// <param name="key">キー</param>
            /// <returns></returns>
            public ConfigEntry this[string key]
            {
                set => Add(key, null);
                get => Get(key);
            }
            /// <summary>
            /// 子アイテムからConfigEntryを取得します。存在しなければ新しいConfigEntryが作成されます。
            /// </summary>
            /// <param name="keys">キー、カンマで区切って階層指定します</param>
            /// <returns></returns>
            public ConfigEntry this[params string[] keys]
            {
                set
                {
                    ConfigEntry entry = this;
                    for (int i = 0; i < keys.Length; i++)
                    {
                        entry = entry[keys[i]];
                    }
                }
                get
                {
                    ConfigEntry entry = this;
                    for (int i = 0; i < keys.Length; i++)
                    {
                        entry = entry[keys[i]];
                    }
                    return entry;
                }
            }

            /// <summary>
            /// 指定したキーが子アイテムに存在するか調べます。再帰的調査はされません。
            /// </summary>
            /// <param name="key">キー</param>
            /// <returns>キーが存在すればTrue</returns>
            public bool Exists(string key) => Children?.Any(c => c.Key == key) ?? false;
            /// <summary>
            /// 指定したキーが子アイテムに存在するか調べます。階層をまたいだ指定をします。
            /// </summary>
            /// <param name="keys">キー、カンマで区切って階層指定します。</param>
            /// <returns>キーが存在すればTrue</returns>
            public bool Exists(params string[] keys)
            {
                ConfigEntry entry = this;
                for (int i = 0; i < keys.Length; i++)
                {
                    if (entry.Exists(keys[i]) == false)
                        return false;
                    entry = entry[keys[i]];
                }
                return true;
            }
        }
    }
}
