using System;
using System.Collections.Generic;
using CoreOSC;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Microsoft.Diagnostics.Tracing.Session;
using Windows.ApplicationModel.Store;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Timers;
using System.IO;

namespace VRChatify
{
    public class TimestampCollection
    {
        const int MAXNUM = 1000;

        public string Name { get; set; }

        List<long> timestamps = new List<long>(MAXNUM + 1);
        object sync = new object();

        //add value to the collection
        public void Add(long timestamp)
        {
            lock (sync)
            {
                timestamps.Add(timestamp);
                if (timestamps.Count > MAXNUM) timestamps.RemoveAt(0);
            }
        }

        //get the number of timestamps withing interval
        public int QueryCount(long from, long to)
        {
            int c = 0;

            lock (sync)
            {
                foreach (var ts in timestamps)
                {
                    if (ts >= from && ts <= to) c++;
                }
            }
            return c;
        }
    }


    public static class VRChatify
    {

        public static bool debugging = false;
        public static string Version = "1.0.5";
        public static UDPSender oscSender;
        public static UDPListener oscReceiver;
        private static MainWindow mainWindow;
        public static VMediaManager mediaManager;

        public static string CurrentSongCheck = null;

        public static string CurrentSong = null;

        public static string CurrentSound = null;

        public static string ClanTag = "";
        public static List<string> ClanTagStrings;
        public static int ClanTagIndex = 0;
        public static List<string> AnimStr = new List<string>();
        public static int AnimIndex = 0;
        public const int EventID_D3D9PresentStart = 1;
        public const int EventID_DxgiPresentStart = 42;

        //ETW provider codes
        public static readonly Guid DXGI_provider = Guid.Parse("{CA11C036-0102-4A2D-A6AD-F03CFED5D3C9}");
        public static readonly Guid D3D9_provider = Guid.Parse("{783ACA0A-790E-4D7F-8451-AA850511C6B9}");

        static TraceEventSession m_EtwSession;
        public static Dictionary<int, TimestampCollection> frames = new Dictionary<int, TimestampCollection>();
       public static Stopwatch watch = null;
        static object sync = new object();
        private static string lastlog = "";
        private static int time = 0;
        public static IEnumerable<string> SplitToLines(this string input)
        {
            if (input == null)
            {
                yield break;
            }

            using (System.IO.StringReader reader = new System.IO.StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        public static void Custom()
        {
            long t1, t2;
            long dt = 2000;
            lock (sync)
            {
                if (MainWindow.rpc == true)
                {
                    PresenceManager.UpdateDetails(MainWindow.currentdetails);
                }
                t2 = VRChatify.watch.ElapsedMilliseconds;
                t1 = t2 - dt;

                int count = MainWindow.vrcproc.QueryCount(t1, t2);
                MainWindow.AppendToSB(mainWindow.richTextBox1.Text);
                (mainWindow.richTextBox1.Text.Contains("{LYRICS}") == true ? new Action(() => MainWindow.oscMsg.Replace("{LYRICS}", $"{VRChatify.mediaManager.GetLyrics().Result}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{SPOTIFY}") == true ? new Action(() => MainWindow.oscMsg.Replace("{SPOTIFY}", $"{VRChatify.mediaManager.GetSongArtist()} - {VRChatify.mediaManager.GetSongName()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{TIMESTAMP}") == true ? new Action(() => MainWindow.oscMsg.Replace("{TIMESTAMP}", $"{VMediaManager.currentSession.ControlSession.GetTimelineProperties().Position.ToString(@"mm\:ss")}/{VMediaManager.currentSession.ControlSession.GetTimelineProperties().EndTime.ToString(@"mm\:ss")}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{TABBED}") == true ? new Action(() => MainWindow.oscMsg.Replace("{TABBED}", $"{MainWindow.GetFocused()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{ANIMATED}") == true ? new Action(() => MainWindow.oscMsg.Replace("{ANIMATED}", $"{MainWindow.currentanimstr}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{FPS}") == true ? new Action(() => MainWindow.oscMsg.Replace("{FPS}", $"{Math.Round((double)count / dt * 1000.0)}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{GPU}") == true ? new Action(() => MainWindow.oscMsg.Replace("{GPU}", $"{VRChatifyUtils.GetGPUUsage()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{CPU}") == true ? new Action(() => MainWindow.oscMsg.Replace("{CPU}", $"{Math.Round(VRChatifyUtils.GetCpuUsage()).ToString()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{RAM}") == true ? new Action(() => MainWindow.oscMsg.Replace("{RAM}", $"{VRChatifyUtils.GetRamUsage()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{RAM-CAPACITY}") == true ? new Action(() => MainWindow.oscMsg.Replace("{RAM-CAPACITY}", $"{VRChatifyUtils.GetRamCapacity()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{RAM-AVAILABLE}") == true ? new Action(() => MainWindow.oscMsg.Replace("{RAM-AVAILABLE}", $"{VRChatifyUtils.GetRamAvailable()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{CLANTAG}") == true ? new Action(() => MainWindow.oscMsg.Replace("{CLANTAG}", $"{VRChatify.ClanTagStrings[VRChatify.ClanTagIndex]}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{TIME}") == true ? new Action(() => MainWindow.oscMsg.Replace("{TIME}", $"{DateTime.Now.ToString("h:mm:ss tt")}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{TABBEDV2}") == true ? new Action(() => MainWindow.oscMsg.Replace("{TABBEDV2}", $"{MainWindow.GetActiveWindow()}")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{CLEARBOX}") == true ? new Action(() => MainWindow.oscMsg.Replace("{CLEARBOX}", $"\u0003\u001f")) : new Action(MainWindow.joemethod))();
                (mainWindow.richTextBox1.Text.Contains("{ALBUM}") == true ? new Action(() => MainWindow.oscMsg.Replace("{ALBUM}", $"{VRChatify.mediaManager.GetAlbumTitle()}")) : new Action(MainWindow.joemethod))();

                VRChatify.SendChatMessage(MainWindow.oscMsg.ToString());

                MainWindow.oscMsg.Clear();


            }
        }
        static bool cooldown = false;
        public static void SendChatMessage(string message)
        {
            if (cooldown == false)
            {
                if (MainWindow.InvisibleBox == true)
                {
                    oscSender.Send(new OscMessage("/chatbox/input", message, true, false));

                }
                else
                {
                    oscSender.Send(new OscMessage("/chatbox/input", message, true, false));
                }
                VRChatifyUtils.DebugLog($"Sent:\n{message}\n");
                if (time > 9)
                {
                    lastlog = "";
                    time = 0;
                }
                mainWindow.label2.Text = lastlog + $"\n[Debug] {message}";
                lastlog = mainWindow.label2.Text;
                time += 1;
                CurrentSongCheck = CurrentSong;
                cooldown = true;
                System.Timers.Timer tim = new System.Timers.Timer();
                tim.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                tim.Interval = 2000;
                tim.Enabled = true;
            }
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            cooldown = false;
        }
        static void EtwThreadProc()
        {
            //start tracing
            m_EtwSession.Source.Process();
        }

        static void Main()
        {
            oscSender = new UDPSender("127.0.0.1", 9000);

            //var s = "\0";
          //  VRChatify.SendChatMessage("");
            //Console.ReadLine();
#if !DEBUG
            oscSender = new UDPSender("127.0.0.1", 9000);
           
            oscReceiver = new UDPListener(9001, OnOscPacket);
            mediaManager = new VMediaManager();
            mediaManager.Init();
            VRChatifyUtils.Logo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_EtwSession = new TraceEventSession("mysess");
            m_EtwSession.StopOnDispose = true;
            m_EtwSession.EnableProvider("Microsoft-Windows-D3D9");
            m_EtwSession.EnableProvider("Microsoft-Windows-DXGI");

            m_EtwSession.Source.AllEvents += data =>
            {
                if (((int)data.ID == EventID_D3D9PresentStart && data.ProviderGuid == D3D9_provider) ||
                ((int)data.ID == EventID_DxgiPresentStart && data.ProviderGuid == DXGI_provider))
                {
                    int pid = data.ProcessID;
                    long t;

                    lock (sync)
                    {
                        t = watch.ElapsedMilliseconds;

                        if (!frames.ContainsKey(pid))
                        {
                            frames[pid] = new TimestampCollection();

                            string name = "";
                            var proc = Process.GetProcessById(pid);
                            if (proc != null)
                            {
                                using (proc)
                                {
                                    name = proc.ProcessName;
                                }
                            }
                            else name = pid.ToString();

                            frames[pid].Name = name;
                        }

                        frames[pid].Add(t);
                    }
                }
            };

            watch = new Stopwatch();
            watch.Start();

            Thread thETW = new Thread(EtwThreadProc);
            thETW.IsBackground = true;
            thETW.Start();
            Thread thETW1 = new Thread(ThreadFPS);
            thETW1.IsBackground = true;
            thETW1.Start();

            mainWindow = new MainWindow();
            Application.Run(mainWindow);
#endif

        }
        public static string currentfps = null;
        private  static void joes(string j)
        {
            currentfps = j;
        }
        public static void ThreadFPS()
        {
            long t1, t2;
            long dt = 2000;

            lock (sync)
            {
                t2 = watch.ElapsedMilliseconds;
                t1 = t2 - dt;

                foreach (var x in frames.Values)
                {
                    if (x.Name == "VRChat")
                    {
                        //Console.Write("VRChat: ");
                        //get the number of frames
                        int count = x.QueryCount(t1, t2);

                        //calculate FPS
                        //  Console.WriteLine("{0} FPS", (double)count / dt * 1000.0);
                        joes( $"{Math.Round((double)count / dt * 1000.0)}");
                      //  Program.oscSender.Send(new OscMessage("/chatbox/input", $"{SpotifyInfo()} || FPS: {currentfps}", true, true));
                       // LogUtils.Log("Sent!");
                        //  Console.WriteLine(currentfps);
                    }


                }
            }

        }
        public static List<Button> GenerateSessionButtons()
        {
            List<Button> buttons = new List<Button>();
            int BaseLocX = 3;
            int BaseLocY = 15;
            foreach (var session in mediaManager.GetMediaManager().CurrentMediaSessions)
            {
                VRChatifyUtils.DebugLog("Generating Button");
                Button button = new Button
                {
                    ForeColor = System.Drawing.SystemColors.ControlText,
                    Location = new System.Drawing.Point(BaseLocX, BaseLocY),
                    Name = session.Key,
                    Size = new System.Drawing.Size(178, 23),
                    TabIndex = 2,
                    Text = session.Value.Id,
                    UseVisualStyleBackColor = true
                };
                button.Click += new EventHandler(DynamicButton_Click);
                BaseLocY += 25;
                buttons.Add(button);
            }
            return buttons;
        }

        private static void DynamicButton_Click(object sender, EventArgs e)
        {
            VMediaManager.spotify = false;
            Button btn = (Button)sender;
            mediaManager.setCurrentSession(mediaManager.GetMediaManager().CurrentMediaSessions[btn.Name]);
            VRChatifyUtils.DebugLog($"Current session set to: {btn.Name}");
        }

        private static void OnOscPacket(OscPacket packet)
        {
            if (!(packet is OscMessage message)
                || message.Address == null
                || message.Arguments == null
                || message.Arguments.Count == 0)
            {
                return;
            }
            var value = message.Arguments[0];
            if (value == null || !(value is bool boolean) || !boolean)
            {
                return;
            }

            Task.Run(async () => {
                var address = message.Address;
                if (address == "/avatar/parameters/back")
                {
                    VRChatifyUtils.DebugLog("Back");
                    await mediaManager.GetCurrentSession()?.ControlSession.TrySkipPreviousAsync();
                }
                else if (address == "/avatar/parameters/skip")
                {
                    VRChatifyUtils.DebugLog("Skip");
                    await mediaManager.GetCurrentSession()?.ControlSession.TrySkipNextAsync();
                }
                else if (address == "/avatar/parameters/paused")
                {
                    VRChatifyUtils.DebugLog("paused");
                    await mediaManager.GetCurrentSession()?.ControlSession.TryTogglePlayPauseAsync();
                }
                return Task.CompletedTask;
            });
        }

        public static MainWindow GetMainWindow()
        {
            return mainWindow;
        }
        

    }
}