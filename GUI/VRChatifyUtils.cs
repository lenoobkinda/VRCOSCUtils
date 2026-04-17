using System;
using Console = Colorful.Console;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Management;
using System.Linq;

namespace VRChatify
{
    public static class VRChatifyUtils
    {
        public static void Error(string Message)
        {
            Console.Write("[");
            Console.Write($"{DateTime.Now}", System.Drawing.Color.Red);
            Console.Write("] ");

            Console.Write("[");
            Console.Write("Error", System.Drawing.Color.Red);
            Console.Write("] ");
            Console.Write(Message);
            Console.WriteLine();
        }
        public static void Log(string Message)
        {
            Console.Write("[");
            Console.Write($"{DateTime.Now}", System.Drawing.Color.Green);
            Console.Write("] ");
            Console.Write("[");
            Console.Write("VRChatify", System.Drawing.Color.Green);
            Console.Write("] ");
            Console.Write(Message);
            Console.WriteLine();
        }
        public static void DebugLog(string Message)
        {
            if (VRChatify.debugging)
            {
                Console.Write("[");
                Console.Write($"{DateTime.Now}", System.Drawing.Color.Yellow);
                Console.Write("] ");

                Console.Write("[");
                Console.Write("Debug", System.Drawing.Color.Yellow);
                Console.Write("] ");
                Console.Write(Message);
                Console.WriteLine();
            }
        }
        public static void Logo()
        {

            Console.WriteLine("██    ██ ██████   ██████ ██   ██  █████  ████████ ██ ███████ ██    ██", System.Drawing.Color.Green);
            Console.WriteLine("██    ██ ██   ██ ██      ██   ██ ██   ██    ██    ██ ██       ██  ██ ", System.Drawing.Color.Green);
            Console.WriteLine("██    ██ ██████  ██      ███████ ███████    ██    ██ █████     ████  ", System.Drawing.Color.Green);
            Console.WriteLine(" ██  ██  ██   ██ ██      ██   ██ ██   ██    ██    ██ ██         ██   ", System.Drawing.Color.Green);
            Console.WriteLine("  ████   ██   ██  ██████ ██   ██ ██   ██    ██    ██ ██         ██   ", System.Drawing.Color.Green);
        }
        public static void Clear()
        {
            Console.Clear();
            Console.WriteLine("██    ██ ██████   ██████ ██   ██  █████  ████████ ██ ███████ ██    ██", System.Drawing.Color.Green);
            Console.WriteLine("██    ██ ██   ██ ██      ██   ██ ██   ██    ██    ██ ██       ██  ██ ", System.Drawing.Color.Green);
            Console.WriteLine("██    ██ ██████  ██      ███████ ███████    ██    ██ █████     ████  ", System.Drawing.Color.Green);
            Console.WriteLine(" ██  ██  ██   ██ ██      ██   ██ ██   ██    ██    ██ ██         ██   ", System.Drawing.Color.Green);
            Console.WriteLine("  ████   ██   ██  ██████ ██   ██ ██   ██    ██    ██ ██         ██   ", System.Drawing.Color.Green);

        }
        public static float GetCpuUsage()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            return cpuCounter.NextValue();
        }
        public static float GetGPUUsage()
        {
            try
            {
                var category = new PerformanceCounterCategory("GPU Engine");
                var counterNames = category.GetInstanceNames();
                var gpuCounters = new List<PerformanceCounter>();
                var result = 0f;

                foreach (string counterName in counterNames)
                {
                    if (counterName.EndsWith("engtype_3D"))
                    {
                        foreach (PerformanceCounter counter in category.GetCounters(counterName))
                        {
                            if (counter.CounterName == "Utilization Percentage")
                            {
                                gpuCounters.Add(counter);
                            }
                        }
                    }
                }

                gpuCounters.ForEach(x =>
                {
                    _ = x.NextValue();
                });

                Thread.Sleep(1000);

                gpuCounters.ForEach(x =>
                {
                    result += x.NextValue();
                });

                return result;
            }
            catch(Exception e)
            {
                Error("Grabbing gpu usage");
                Error(e.Message);
                return 0f;
            }
        }
        public static string GetRamAvailable()
        {
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            double available = 0, capacity = 0;
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();


            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();
            return $"{available}Gb";

        }
        public static string GetRamCapacity()
        {
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            double available = 0, capacity = 0;
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();


            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();
            return $"{capacity}Gb";

        }
        public static double GetRamUsage()
        {
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            double available = 0, capacity = 0;
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();


            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();
            return Math.Round((capacity - available) / capacity * 100, 0);
        }
        public static string GetSpotifySong()
        {
            //https://stackoverflow.com/questions/37854194/get-current-song-name-for-a-local-application
            var SpotifyProcess = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
            if (SpotifyProcess == null)
            {
                return "Spotify Closed";
            }
            VRChatify.CurrentSong = SpotifyProcess.MainWindowTitle;
            if (VRChatify.CurrentSong == "Spotify Free" || VRChatify.CurrentSong == "Spotify Premium")
            {
                return "Idling on Spotify";
            }
            if (VRChatify.CurrentSong == "Spotify" || VRChatify.CurrentSong == "Advertisement")
            {
                return "Listening to a add";

            }
            return SpotifyProcess.MainWindowTitle;
        }
        public static List<string> ClanTagText(string tag)
        {
            List<string> strings = new List<string>();
            List<string> strings2 = new List<string>();
            string word = "";
            foreach (char s in tag)
            {
                word += s;
                strings.Add(word);
                strings2.Add(word);
            }
            strings2.RemoveAt(strings2.Count - 1);
            strings2.Reverse();
            strings.AddRange(strings2);
            return strings;
        }
        public static string GetActiveWindowTitle()
        {
            try
            {
                IntPtr hwnd = GetForegroundWindow();
                GetWindowThreadProcessId(hwnd, out uint pid);
                Process p = Process.GetProcessById((int)pid);
                string title = p.MainWindowTitle;
                if (string.IsNullOrWhiteSpace(title))
                    title = p.ProcessName;
                return title;
            }
            catch (Exception)
            {
                return "???";
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static string GetComputerName()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            string info = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                info = (string)mo["Name"];
            }
            return info;
        }
    }
}
