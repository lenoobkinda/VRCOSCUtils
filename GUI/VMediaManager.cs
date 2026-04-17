using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage.Streams;
using Windows.Storage;
using WindowsMediaController;
using System.Windows.Navigation;
using System.IO;
using Windows.Storage.Pickers;
using System.Windows.Media.Imaging;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using System.Net;

namespace VRChatify
{
    public class VMediaManager  
    {

        private static readonly MediaManager mediaManager = new MediaManager();
        public static MediaManager.MediaSession currentSession = null;
      

        public void Init()
        {
            mediaManager.Start();
            mediaManager.OnAnySessionOpened += MediaManager_OnAnySessionOpened;
            mediaManager.OnAnySessionClosed += MediaManager_OnAnySessionClosed;

            try
            {
                var sessions = mediaManager.CurrentMediaSessions;
                if (sessions != null && sessions.Count > 0)
                {
                    var spotifyKey = sessions.Keys.FirstOrDefault(k => k != null && k.IndexOf("spotify", StringComparison.OrdinalIgnoreCase) >= 0);
                    if (spotifyKey != null)
                    {
                        currentSession = sessions[spotifyKey];
                        VRChatifyUtils.DebugLog($"Default session set to Spotify ({spotifyKey})");
                        spotify = true;
                    }
                }
            }
            catch (Exception ex)
            {
                VRChatifyUtils.DebugLog("Setting default Spotify session failed: " + ex.Message);
            }
        }

        private void MediaManager_OnAnySessionOpened(MediaManager.MediaSession mediaSession)
        {
            VRChatifyUtils.DebugLog($"Session Opened: {mediaSession.Id}");
            VRChatify.GetMainWindow().UpdateSessionList();

            try
            {
                if (currentSession == null)
                {
                    var sessions = mediaManager.CurrentMediaSessions;
                    var spotifyKey = sessions.Keys.FirstOrDefault(k => k != null && k.IndexOf("spotify", StringComparison.OrdinalIgnoreCase) >= 0);
                    if (spotifyKey != null)
                    {
                        currentSession = sessions[spotifyKey];
                        VRChatifyUtils.DebugLog($"Default session set to Spotify on session opened ({spotifyKey})");
                        spotify = true;
                    }
                }
            }
            catch (Exception ex)
            {
                VRChatifyUtils.DebugLog("Selecting Spotify on session open failed: " + ex.Message);
            }
        }

        private void MediaManager_OnAnySessionClosed(MediaManager.MediaSession mediaSession)
        {
            VRChatifyUtils.DebugLog($"Session Closed: {mediaSession.Id}");
            VRChatify.GetMainWindow().UpdateSessionList();

            try
            {
                if (currentSession != null && mediaSession != null && mediaSession.Id == currentSession.Id)
                {
                    currentSession = null;
                    VRChatifyUtils.DebugLog("Current session closed, clearing currentSession.");
                }
            }
            catch (Exception ex)
            {
                VRChatifyUtils.DebugLog("Handling session closed failed: " + ex.Message);
            }
        }
        public static bool spotify = true;
       
        public MediaManager.MediaSession GetCurrentSession()
        {
            if (currentSession == null)
            {
                try
                {
                 //   MessageBox.Show($"{Process.GetProcesses("spotify").First().ProcessName}");
                    if (spotify == true && Process.GetProcesses("spotify").First() != null)
                    {
                        return currentSession = mediaManager.CurrentMediaSessions["Spotify.exe"];
                    }
                    return currentSession = mediaManager.CurrentMediaSessions.First().Value;
                }
                catch (InvalidOperationException)
                {
                    VRChatifyUtils.DebugLog("No session found");
                    return null;
                }
            }
            return currentSession;
        }

        HttpClient client = new HttpClient();
        public string GetSongName()
        {

            var songInfo = GetCurrentSession().ControlSession.TryGetMediaPropertiesAsync().GetAwaiter().GetResult();
            if (songInfo != null)
            {
              
                return songInfo.Title;
            }
            return "Unable to get Lyrics";
        }
      
       public static Dictionary<TimeSpan, string> dic = new Dictionary<TimeSpan, string>();
        static string syncedlyrics = "";
        static string ConvertJsonToString(string json)
        {
            try
            {
                JObject jsonObject = JObject.Parse(json);

                string trackName = jsonObject["trackName"].ToString();
                string artistName = jsonObject["artistName"].ToString();
                string albumName = jsonObject["albumName"].ToString();
                int duration = jsonObject["duration"].Value<int>();
                bool instrumental = jsonObject["instrumental"].Value<bool>();
                string plainLyrics = jsonObject["plainLyrics"].ToString();
                syncedlyrics = jsonObject["syncedLyrics"].ToString();

                // Construct the final string
                string result = $"Track: {trackName}\nArtist: {artistName}\nAlbum: {albumName}\nDuration: {duration} seconds\nInstrumental: {(instrumental ? "Yes" : "No")}";
                return result;
            }
            catch (Exception ex)
            {
                return $"Error converting JSON: {ex.Message}";
            }
        }
        public static TimeSpan convertthing(string timespan)
        {
            try
            {
                string s = timespan;
                if (s.Contains('.'))
                {
                    // VRChatifyUtils.DebugLog(s.IndexOf('.').ToString());
                    s = s.Substring(0, s.IndexOf("."));
                    //    VRChatifyUtils.DebugLog(s);
                }
                string[] val = s.Split(':');
                //   VRChatifyUtils.DebugLog(int.Parse(val[0]) + "\n" + int.Parse(val[1]));

                TimeSpan ts = new TimeSpan(00, int.Parse(val[0]), int.Parse(val[1]));
               // VRChatifyUtils.DebugLog("sorting things");

                return ts;

            }
            catch (Exception e)
            {
                VRChatifyUtils.DebugLog(e.Message);
                return TimeSpan.Zero; 
            }



        }
        public static string currentsong = "";
        public static HttpResponseMessage lastresponse = null;
        public static int retrycount = 0;
        public async Task<string> GetLyrics()
        {
            var songInfo = GetCurrentSession().ControlSession.TryGetMediaPropertiesAsync().GetAwaiter().GetResult();
            if (songInfo != null)
            {
                dic.Clear();
                HttpResponseMessage ly = null;
                if (lastresponse != null && lastresponse.StatusCode == HttpStatusCode.NotFound)
                {
                    lastresponse = await client.GetAsync($"https://lrclib.net/api/get?artist_name={songInfo.Artist.Replace(' ', '+')}&track_name={songInfo.Title.Replace(' ', '+')}&album_name={songInfo.AlbumTitle.Replace(' ', '+')}&duration={GetSongDuration().TotalSeconds}");

                }
                if (currentsong != null && songInfo.Title == currentsong)
                {
                    ly = lastresponse;

                }
                else
                {
                     ly = await client.GetAsync($"https://lrclib.net/api/get?artist_name={songInfo.Artist.Replace(' ', '+')}&track_name={songInfo.Title.Replace(' ', '+')}&album_name={songInfo.AlbumTitle.Replace(' ', '+')}&duration={GetSongDuration().TotalSeconds}");
                    lastresponse = ly;
                    currentsong = songInfo.Title;
                }
                // Task.Delay(1000);

                VRChatifyUtils.DebugLog(ly.ReasonPhrase);
                if (ly.IsSuccessStatusCode)
                {
                    
                    var s = await ly.Content.ReadAsStringAsync();
                    VRChatifyUtils.DebugLog(s);

                    ConvertJsonToString(s);
                    if (s.Contains(""))
                    {
                        
                    }
                   // Console.WriteLine(s);
                    if (s.Contains("["))
                    {
                      // VRChatifyUtils.DebugLog("TimeStamps Exists");

                        s.Replace("\n\n", "\n");
                        foreach (var idk in syncedlyrics.Split('\n'))
                        {
                           // VRChatifyUtils.DebugLog("getting the timestamps of lyrics");
                            try
                            {
                                var start = idk.IndexOf("[") + 1;
                                var length = idk.IndexOf("]") - start;
                                var subidk = idk.Substring(start, length);
                                var ts = convertthing(subidk);
                                dic.Add(ts, idk.Split(']')[1]);
                               // VRChatifyUtils.DebugLog("done");

                            }
                            catch (Exception ex)
                            {
                                VRChatifyUtils.DebugLog(ex.Message);

                            }



                        }
                        try
                        {
                            var dif = dic.OrderBy(comp => Math.Abs(comp.Key.TotalSeconds - GetCurrentSongTime().TotalSeconds)).FirstOrDefault();
                            var outstr = "";
                            dic.TryGetValue(dif.Key, out outstr);
                            VRChatifyUtils.DebugLog(outstr);

                            return outstr;
                        }
                        catch (Exception ex) {
                            VRChatifyUtils.DebugLog(ex.Message);
                            return "Unable To Get Lyrics";
                        
                        }
                    }
                }
            }
            return "Unable To Get Lyrics";

        }
         
        public string PlaybackState()
        {
            switch (GetCurrentSession()?.ControlSession.GetPlaybackInfo().PlaybackStatus)
            {
                case Windows.Media.Control.GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing:
                    return "";
                case Windows.Media.Control.GlobalSystemMediaTransportControlsSessionPlaybackStatus.Paused:
                    return "Paused";
                case Windows.Media.Control.GlobalSystemMediaTransportControlsSessionPlaybackStatus.Stopped:
                    return "Stopped";
            };
                 
           
            return "";
        }
        public string GetSongArtist()
        {
            var songInfo = GetCurrentSession()?.ControlSession.TryGetMediaPropertiesAsync().GetAwaiter().GetResult();
            if (songInfo != null)
            {
                return songInfo.Artist;
            }
            return "Unable to get Author";
        }
        public static async Task<BitmapImage> GetThumbnail(IRandomAccessStreamReference Thumbnail, bool convertToPng = true)
        {
            if (Thumbnail == null)
                return null;

            var thumbnailStream = await Thumbnail.OpenReadAsync();
            byte[] thumbnailBytes = new byte[thumbnailStream.Size];
            using (DataReader reader = new DataReader(thumbnailStream))
            {
                await reader.LoadAsync((uint)thumbnailStream.Size);
                reader.ReadBytes(thumbnailBytes);
            }

            byte[] imageBytes = thumbnailBytes;

            if (convertToPng)
            {
                 var fileMemoryStream = new System.IO.MemoryStream(thumbnailBytes);
                Bitmap thumbnailBitmap = (Bitmap)Bitmap.FromStream(fileMemoryStream);

                if (!thumbnailBitmap.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                {
                     var pngMemoryStream = new System.IO.MemoryStream();
                    thumbnailBitmap.Save(pngMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    imageBytes = pngMemoryStream.ToArray();
                }
            }

            var image = new BitmapImage();
            using (var ms = new System.IO.MemoryStream(imageBytes))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
            }

            return image;
        }
        public string GetAlbumTitle()
        {
            var songInfo = GetCurrentSession()?.ControlSession.TryGetMediaPropertiesAsync().GetAwaiter().GetResult();
            if (songInfo != null)
            {
                return songInfo.AlbumTitle;
            }
            return "Unable to get Author";
        }

        public TimeSpan GetSongDuration()
        {
            var timeline = GetCurrentSession()?.ControlSession.GetTimelineProperties();
            if(timeline != null)
            {
                return timeline.EndTime;
            }
            return new TimeSpan();
        }

        public TimeSpan GetCurrentSongTime()
        {
            var timeline = GetCurrentSession()?.ControlSession.GetTimelineProperties();
            if (timeline != null)
            {
                return timeline.Position;
            }
            return new TimeSpan();
        }

        public string GetAlbumTrackCount()
        {
            var songInfo = GetCurrentSession()?.ControlSession.TryGetMediaPropertiesAsync().GetAwaiter().GetResult();
            if (songInfo != null)
            {
                return songInfo.AlbumTrackCount.ToString();
            }
            return "Unable to get Author";
        }

        public MediaManager GetMediaManager()
        {
            return mediaManager;
        }

        public void setCurrentSession(MediaManager.MediaSession session)
        {
            currentSession = session;
        }
    }
}