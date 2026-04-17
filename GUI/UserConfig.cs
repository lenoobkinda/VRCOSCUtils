using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace VRChatify
{
    public static class UserConfig
    {
        [Serializable]
        public class Settings
        {
            public bool Spotify;
            public bool Stats;
            public bool Clant;
            public bool FPS;
            public bool LocalTime;
            public bool Tabbed;
            public bool InvisibleBox;
            public bool Animated;
            public bool Lyrics;
            public bool IsCustom;
            public bool Debugging;
            public bool Rpc;
            public string ClanTag;
        }

        private static readonly string ConfigDirectory = Path.Combine(
            Environment.CurrentDirectory,
            "Config");
        private static readonly string FilePath = Path.Combine(Environment.CurrentDirectory, "\\userconfig.xml");
        private static readonly string LogPath = Path.Combine(Environment.CurrentDirectory, "\\userconfig.log");

   
        public static Settings LoadOrCreateDefault()
        {
            try
            {
                Directory.CreateDirectory(ConfigDirectory);

                if (!File.Exists(FilePath))
                {
                    var defaults = CreateDefault();
                    if (!Save(defaults))
                    {
                        ApplyToMainWindow(defaults);
                        return defaults;
                    }

                    ApplyToMainWindow(defaults);
                    return defaults;
                }
                

                var serializer = new XmlSerializer(typeof(Settings));
                using (var fs = File.OpenRead(FilePath))
                {
                    var settings = (Settings)serializer.Deserialize(fs);
                    ApplyToMainWindow(settings);
                    return settings;
                }
            }
            catch (Exception ex)
            {
                Log("LoadOrCreateDefault failed: " + ex);
                try
                {
                    var fallback = CreateDefault();
                    ApplyToMainWindow(fallback);
                    return fallback;
                }
                catch (Exception e2)
                {
                    Log("Applying fallback failed: " + e2);
                    return null;
                }
            }
            
        }

      
        public static bool Save()
        {
            return Save(null);
        }

  
        public static bool Save(Settings settings = null)
        {
            try
            {
                Directory.CreateDirectory(ConfigDirectory);
                if (settings == null)
                    settings = CreateFromMainWindow();

                var serializer = new XmlSerializer(typeof(Settings));
                using (var fs = File.Create(FilePath))
                {
                    serializer.Serialize(fs, settings);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log("Save failed: " + ex);
                return false;
            }
        }

        private static Settings CreateFromMainWindow()
        {
            return new Settings
            {
                Spotify = MainWindow.Spotify,
                Stats = MainWindow.Stats,
                Clant = MainWindow.Clant,
                FPS = MainWindow.FPS,
                LocalTime = MainWindow.LocalTime,
                Tabbed = MainWindow.Tabbed,
                InvisibleBox = MainWindow.InvisibleBox,
                Animated = MainWindow.Animated,
                Lyrics = MainWindow.Lyrics,
                IsCustom = MainWindow.IsCustom,
                Debugging = VRChatify.debugging,
                Rpc = MainWindow.rpc,
                ClanTag = Config.GetConfig("clantag") ?? string.Empty
            };
        }

        private static Settings CreateDefault()
        {
            return new Settings
            {
                Spotify = false,
                Stats = false,
                Clant = false,
                FPS = false,
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

        private static void ApplyToMainWindow(Settings s)
        {
            if (s == null) return;

            MainWindow.Spotify = s.Spotify;
            MainWindow.Stats = s.Stats;
            MainWindow.Clant = s.Clant;
            MainWindow.FPS = s.FPS;
            MainWindow.LocalTime = s.LocalTime;
            MainWindow.Tabbed = s.Tabbed;
            MainWindow.InvisibleBox = s.InvisibleBox;
            MainWindow.Animated = s.Animated;
            MainWindow.Lyrics = s.Lyrics;
            MainWindow.IsCustom = s.IsCustom;
            VRChatify.debugging = s.Debugging;
            MainWindow.rpc = s.Rpc;

            if (!string.IsNullOrEmpty(s.ClanTag))
            {
                Config.SetConfig("clantag", s.ClanTag);
            }
        }

        private static void Log(string message)
        {
            try
            {
                Directory.CreateDirectory(ConfigDirectory);
                File.AppendAllText(LogPath, DateTime.UtcNow.ToString("s") + " - " + message + Environment.NewLine);
                Console.WriteLine("UserConfig: " + message);
            }
            catch
            {
            }
        }
    }
}