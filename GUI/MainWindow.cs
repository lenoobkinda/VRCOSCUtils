using System;
using System.Windows.Forms;
using System.Timers;
using AutoUpdaterDotNET;
using System.Text;
using System.Runtime.Remoting.Messaging;
using CoreOSC;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using WindowsMediaController;
using System.Windows;

namespace VRChatify
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, uint processId);

        [DllImport("psapi.dll")]
        private static extern uint GetModuleBaseNameA(IntPtr hWnd, IntPtr hModule, StringBuilder lpBaseName, uint nSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private const uint PROCESS_QUERY_INFORMATION = 0x0400;
        private const uint PROCESS_VM_READ = 0x0010;
        private const uint MAX_PATH = 260;
        public static string GetActiveWindow()
        {
            const int nChars = 256;
            IntPtr handle;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            else if (GetWindowText(handle, Buff, nChars) == 0)
            {
                return "VRChat";
            }
            return "";
        }
        public static string GetFocused()
        {
            IntPtr foregroundWindow = GetForegroundWindow();

            GetWindowThreadProcessId(foregroundWindow, out uint processId);

            IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, false, processId);

            StringBuilder processName = new StringBuilder((int)MAX_PATH);
            if (GetModuleBaseNameA(processHandle, IntPtr.Zero, processName, MAX_PATH) == 0)
            {
                CloseHandle(processHandle);
                return "VRChat";
            }

            CloseHandle(processHandle);

            return processName.ToString();
        }

        private static System.Timers.Timer OSCTimer;
        private static string oscText = Config.GetConfig("oscText") ?? "{SONG} - {ARTIST} | CPU: {CPU}% | RAM: {RAM}% | GPU: {GPU}% | Time: {TIME} | {CLANTAG}";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"VRCOSCUtils";
            ClanTag.Text = Config.GetConfig("clantag") ?? "VRChatify";
            VRChatify.ClanTagStrings = VRChatifyUtils.ClanTagText(ClanTag.Text);
            UpdateSessionList();
            if (File.Exists(Environment.CurrentDirectory + "\\customconfig.txt"))
            {
                richTextBox1.Text = File.ReadAllText(Environment.CurrentDirectory + "\\customconfig.txt");
            }
            try
            {
                VRChatify.mediaManager.setCurrentSession(VRChatify.mediaManager.GetMediaManager().CurrentMediaSessions["Spotify.exe"]);
                Console.WriteLine("Set session to spotify");

            }
            catch
            {

            }
            var cfg = UserConfig.LoadOrCreateDefault();

            if (cfg == null)
            {
                cfg = new UserConfig.Settings
                {
                    Spotify = false,
                    Stats = false,
                    FPS = false,
                    Clant = false,
                    LocalTime = false,
                    Tabbed = false,
                    InvisibleBox = false,
                    Animated = false,
                    Lyrics = false,
                    IsCustom = false,
                    Debugging = false,
                    Rpc = false,
                    ClanTag = Config.GetConfig("clantag") ?? string.Empty
                };
            }

            checkBox1.Checked = cfg.Spotify;
            checkBox2.Checked = cfg.Stats;
            checkBox3.Checked = cfg.FPS;
            checkBox4.Checked = cfg.Clant;
            checkBox5.Checked = cfg.LocalTime;
            checkBox7.Checked = cfg.Tabbed;
            checkBox9.Checked = cfg.Animated;
            checkBox8.Checked = cfg.Lyrics;
            checkBox6.Checked = cfg.IsCustom;
            checkBox11.Checked = cfg.InvisibleBox;
            DebugLogging.Checked = cfg.Debugging;
            presenceToggle.Checked = cfg.Rpc;

            if (!string.IsNullOrWhiteSpace(cfg.ClanTag))
            {
                ClanTag.Text = cfg.ClanTag;
                VRChatify.ClanTagStrings = VRChatifyUtils.ClanTagText(ClanTag.Text);
                VRChatify.ClanTagIndex = 0;
            }

            MainWindow.Spotify = cfg.Spotify;
            MainWindow.Stats = cfg.Stats;
            MainWindow.Clant = cfg.Clant;
            MainWindow.FPS = cfg.FPS;
            MainWindow.LocalTime = cfg.LocalTime;
            MainWindow.Tabbed = cfg.Tabbed;
            MainWindow.InvisibleBox = cfg.InvisibleBox;
            MainWindow.Animated = cfg.Animated;
            MainWindow.Lyrics = cfg.Lyrics;
            MainWindow.IsCustom = cfg.IsCustom;
            VRChatify.debugging = cfg.Debugging;
            MainWindow.rpc = cfg.Rpc;

            UserConfig.Save();
        }

        private void PresenceToggle_CheckedChanged(object sender, EventArgs e)
        {
            rpc = presenceToggle.Checked;
            if (presenceToggle.Checked)
            {

                PresenceManager.InitRPC();
            }
            else
            {
                PresenceManager.KillRPC();
            }

            UserConfig.Save();
        }
        public static StringBuilder oscMsg = new StringBuilder();
        public static void AppendToSB(string par)
        {
            if (!oscMsg.ToString().Contains(par))
            {
                oscMsg.Append(par);

            }
        }
        public static void joemethod()
        {

        }
        private void OSCToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (OSCToggle.Checked)
            {
                IsSend = OSCToggle.Checked;
                foreach (var x in VRChatify.frames.Values)
                {
                    if (x.Name == "VRChat")
                    {
                        vrcproc = x;
                    }
                }
                
                (Spotify == true ? new Action(() => AppendToSB($"{VRChatify.mediaManager.GetSongArtist()} - {VRChatify.mediaManager.GetSongName()} || {VMediaManager.currentSession.ControlSession.GetTimelineProperties().Position.ToString(@"mm\:ss")}/{VMediaManager.currentSession.ControlSession.GetTimelineProperties().EndTime.ToString(@"mm\:ss")}")) : new Action(joemethod))();
                (FPS == true ? new Action(() => AppendToSB($" || FPS: {VRChatify.currentfps}")) : new Action(joemethod))();
                (Tabbed == true ? new Action(() => AppendToSB($" || Focused In: {GetFocused()}")) : new Action(joemethod))();

                (Stats == true ? new Action(() => AppendToSB($" || CPU: {Math.Round(VRChatifyUtils.GetCpuUsage()).ToString()}% || RAM: {VRChatifyUtils.GetRamUsage()}% || GPU: {VRChatifyUtils.GetGPUUsage()}")) : new Action(joemethod))();
                (Animated == true ? new Action(() => AppendToSB($" || {currentanimstr}")) : new Action(joemethod))();

                (Clant == true ? new Action(() => AppendToSB($" || {VRChatify.ClanTagStrings[VRChatify.ClanTagIndex]}")) : new Action(joemethod))();
                (LocalTime == true ? new Action(() => AppendToSB($" || My Time: {DateTime.Now.ToString("h:mm:ss tt")}")) : new Action(joemethod))();
                (InvisibleBox == true ? new Action(() => AppendToSB($"\u0003\u001f")) : new Action(joemethod))();
                // .Replace("{SONG}", VRChatify.mediaManager.GetSongName())
                // .Replace("{ARTIST}", VRChatify.mediaManager.GetSongArtist())
                // .Replace("{SPOTIFY}", VRChatifyUtils.GetSpotifySong())
                // .Replace("{CPU}", Math.Round(VRChatifyUtils.GetCpuUsage()).ToString())
                // .Replace("{GPU}", Math.Round(VRChatifyUtils.GetGPUUsage()).ToString())
                // //.Replace("{RAM-AVAILABLE}", VRChatifyUtils.GetRamAvailable().ToString())
                //// .Replace("{RAM-CAPACITY}", VRChatifyUtils.GetRamUsage().ToString())
                //// .Replace("{RAM-USED}", VRChatifyUtils.GetRamUsed().ToString())
                // .Replace("{RAM}", VRChatifyUtils.GetRamUsage().ToString())
                // .Replace("{TIME}", DateTime.Now.ToString("h:mm:ss tt"))
                // .Replace("{MTIME}", DateTime.Now.ToString("HH:mm"))
                // .Replace("{WINDOW}", VRChatifyUtils.GetActiveWindowTitle())
                // .Replace("{DURATION}", VRChatify.mediaManager.GetSongDuration().ToString(@"mm\:ss"))
                // .Replace("{POSITION}", VRChatify.mediaManager.GetCurrentSongTime().ToString(@"mm\:ss"))
                // .Replace("{CLANTAG}", VRChatify.ClanTagStrings[VRChatify.ClanTagIndex]);

                VRChatify.SendChatMessage(oscMsg.ToString());
                oscMsg.Clear();
                
                SetTimer();
                Task.Run(UpdateFrames);
            }
            else
            {
                OSCTimer.Stop();
                OSCTimer.Dispose();
                oscMsg.Clear();
                
            }
            UserConfig.Save();
        }
        public static string currentlyrics = "";
        public static bool rpc = false;


        private static void SetTimer()
        {
            OSCTimer = new System.Timers.Timer(2500);
            OSCTimer.Elapsed += OnTimedEvent;
            OSCTimer.AutoReset = true;
            OSCTimer.Enabled = true;
        }
        static object sync = new object();
        public static bool IsCustom = false;
        public static bool IsSend = false;

        public static bool Lyrics = false;
        public static TimestampCollection vrcproc;
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            long t1, t2;
            long dt = 2000;
            lock (sync)
            {
                
                t2 = VRChatify.watch.ElapsedMilliseconds;
                t1 = t2 - dt;
                int count = vrcproc.QueryCount(t1, t2);
                if (IsCustom == false)
                {

                    if (MainWindow.rpc == true)
                    {
                        PresenceManager.UpdateDetails(MainWindow.currentdetails);
                    }
                    (Spotify == true ? new Action(() => AppendToSB($"{VRChatify.mediaManager.GetSongArtist()} - {VRChatify.mediaManager.GetSongName()} || {VMediaManager.currentSession.ControlSession.GetTimelineProperties().Position.ToString(@"mm\:ss")}/{VMediaManager.currentSession.ControlSession.GetTimelineProperties().EndTime.ToString(@"mm\:ss")}")) : new Action(joemethod))();
                    (Lyrics == true ? new Action(() => AppendToSB($" || {VRChatify.mediaManager.GetLyrics().Result}")) : new Action(joemethod))();

                    (FPS == true ? new Action(() => AppendToSB($" || FPS: {Math.Round((double)count / dt * 1000.0)}")) : new Action(joemethod))();
                    (Stats == true ? new Action(() => AppendToSB($" || CPU: {Math.Round(VRChatifyUtils.GetCpuUsage()).ToString()}% || RAM: {VRChatifyUtils.GetRamUsage()}% || GPU: {VRChatifyUtils.GetGPUUsage()}")) : new Action(joemethod))();
                    (Animated == true ? new Action(() => AppendToSB($" || {currentanimstr}")) : new Action(joemethod))();

                    (Clant == true ? new Action(() => AppendToSB($" || {VRChatify.ClanTagStrings[VRChatify.ClanTagIndex]}")) : new Action(joemethod))();
                    (LocalTime == true ? new Action(() => AppendToSB($" || My Time: {DateTime.Now.ToString("h:mm:ss tt")}")) : new Action(joemethod))();


                    VRChatify.SendChatMessage(oscMsg.ToString());
                    oscMsg.Clear();

                    if (VRChatify.ClanTagIndex >= VRChatify.ClanTagStrings.Count - 1)
                    {
                        VRChatify.ClanTagIndex = 0;
                    }
                    else
                    {
                        VRChatify.ClanTagIndex += 1;
                    }
                }
                else if (IsCustom == true)
                {
                    VRChatify.Custom();
                    if (VRChatify.AnimIndex >= VRChatify.AnimStr.Count - 1)
                    {
                        VRChatify.AnimIndex = 0;

                    }
                    else
                    {
                        VRChatify.AnimIndex = 0;
                    }
                    currentanimstr = VRChatify.AnimStr[VRChatify.AnimIndex];
                    if (VRChatify.ClanTagIndex >= VRChatify.ClanTagStrings.Count - 1)
                    {
                        VRChatify.ClanTagIndex = 0;
                    }
                    else
                    {
                        VRChatify.ClanTagIndex += 1;
                    }
                }
           //     PresenceManager.Update();

            }

        }

        private void OSCMessage_TextChanged(object sender, EventArgs e)
        {
            Config.SetConfig("oscText", oscMessage.Text);
            oscText = oscMessage.Text;
        }

        private void PresenceUpdateButton_Click(object sender, EventArgs e)
        {
        }

        private void ForceUpdateSessions_Click(object sender, EventArgs e) => UpdateSessionList();

        public void UpdateSessionList()
        {
            SessionHolder.Invoke(new MethodInvoker(delegate { SessionHolder.Controls.Clear(); }));
            foreach (var item in VRChatify.GenerateSessionButtons())
            {
                VRChatifyUtils.DebugLog($"Adding Buton {item.Text}");
                SessionHolder.Invoke(new MethodInvoker(delegate { SessionHolder.Controls.Add(item); }));
                VRChatifyUtils.DebugLog($"Added Buton {item.Text}");

            }
        }
        public static bool Spotify = false;
        public static bool Stats = false;
        public static bool Clant = false;
        public static bool FPS = false;
        public static bool LocalTime = false;
        public static bool Tabbed = false;
        public static bool InvisibleBox = false;
        public static bool Animated = false;
        //\u0003\u001f

        private void DebugLogging_CheckedChanged(object sender, EventArgs e)
        {
            VRChatify.debugging = DebugLogging.Checked;
            UserConfig.Save();
        }

        private void ClanTag_TextChanged(object sender, EventArgs e)
        {
            Config.SetConfig("clantag", ClanTag.Text);
            if (ClanTag.Text == "")
            {
                ClanTag.Text = " ";
            }
            VRChatify.ClanTagStrings = VRChatifyUtils.ClanTagText(ClanTag.Text);
            VRChatify.ClanTagIndex = 0;
            UserConfig.Save();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //LOCAL TIME TOGGLE
            LocalTime = checkBox5.Checked;
            UserConfig.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // SPOTIFY TOGGLE
            Spotify = checkBox1.Checked;
            UserConfig.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // STATS TOGGLE
            Stats = checkBox2.Checked;
            UserConfig.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            // FPS TOGGLE
            FPS = checkBox3.Checked;
            UserConfig.Save();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            // CLANTAG TOGGLE
            Clant = checkBox4.Checked;
            UserConfig.Save();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            IsCustom = checkBox6.Checked;
            UserConfig.Save();
        }
        public static string test = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = $"{Environment.CurrentDirectory}",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                test = File.ReadAllText(openFileDialog1.FileName);
                if (!string.IsNullOrEmpty(test))
                {
                    richTextBox1.Text = test;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = string.Format("{0}Text files (*.txt)|*.txt|All files (*.*)|*.*", "ARG0"),
                RestoreDirectory = true,
                ShowHelp = true,
                CheckFileExists = false
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);



        }

        private void listView1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Tabbed = checkBox7.Checked;
            UserConfig.Save();
        }
      

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Console_Enter(object sender, EventArgs e)
        {

        }
        static int lastnumval = 0;
      
     

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        static List<string> list = new List<string>();
        private void button3_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = string.Format("{0}Text files (*.txt)|*.txt|All files (*.*)|*.*", "ARG0"),
                RestoreDirectory = true,
                ShowHelp = true,
                CheckFileExists = false
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, fastColoredTextBox3.Text);

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void ClanTagLabel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            Animated = checkBox9.Checked;
            UserConfig.Save();
        }

        private void Sessions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PlaceHolder_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void presenceDetails_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void SessionHolder_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void oscMessageLabel_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = $"{Environment.CurrentDirectory}",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                test = File.ReadAllText(openFileDialog1.FileName);
                if (!string.IsNullOrEmpty(test))
                {
                    fastColoredTextBox3.Text = test;
                }
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        private Task UpdateFrames()
        {
            while (true)
            {
                if (OSCToggle.Enabled == true && Animated == true)
                {
                    for (int i = 0; i < VRChatify.AnimStr.Count; i++)
                    {
                        currentanimstr = VRChatify.AnimStr[i];
                        Task.Delay(500);
                    }

                }
            }
            return Task.CompletedTask;
        }
       
        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }
        public static string currentanimstr = "";

        private void fastColoredTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (fastColoredTextBox3.Text != null)
            {
                foreach (var s in fastColoredTextBox3.Text.SplitToLines())
                {
                    VRChatify.AnimStr.Add(s);
                }
                

            }

        }
        public static string currentdetails;
        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox5_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            Animated = true;
        }

        private void fastColoredTextBox2_Load(object sender, EventArgs e)
        {

        }

        private void S(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (fastColoredTextBox3.Text != null)
            {
                VRChatify.AnimStr.Clear();
                foreach (var s in fastColoredTextBox3.Text.SplitToLines())
                {
                    VRChatify.AnimStr.Add(s);
                }
            }
        }

        private void fastColoredTextBox3_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = $"{Environment.CurrentDirectory}",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,
                 
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                test = File.ReadAllText(openFileDialog1.FileName);
                if (!string.IsNullOrEmpty(test))
                {
                    fastColoredTextBox3.Text = test;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = string.Format("{0}Text files (*.txt)|*.txt|All files (*.*)|*.*", "ARG0"),
                RestoreDirectory = true,
                ShowHelp = true,
                CheckFileExists = false
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, fastColoredTextBox3.Text);
        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            Lyrics = checkBox8.Checked;
            UserConfig.Save();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            InvisibleBox = checkBox11.Checked;
            UserConfig.Save();
        }
    }
}