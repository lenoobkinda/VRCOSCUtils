using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using MetaBrainz.MusicBrainz.CoverArt;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
namespace VRChatify
{
    class PresenceManager
    {
        private static RichPresence presence = new RichPresence()
        {
            Details = "",
            State = "",
            Timestamps = Timestamps.Now,
            Assets = new Assets()
            {
                LargeImageKey = $"",
                LargeImageText = $"",
                SmallImageKey = "https://raw.githubusercontent.com/lenoobwastaken/VRCOSCUtils/refs/heads/main/GUI/VRCOSCUtils-9.png",
                SmallImageText = "By lenoob"
            },
            Buttons = new Button[]
                {
                    new Button()
                    {
                        Label = "Github",
                        Url = "https://github.com/lenoobwastaken/VRCOSCUtils"
                    }
                }
        };

        private static DiscordRpcClient client;

        public static void InitRPC()
        {

            client = new DiscordRpcClient("1251266166631170068")
            {
                Logger = new ConsoleLogger() { Level = LogLevel.Warning }
            };

            client.OnReady += (sender, e) =>
            {
                VRChatifyUtils.Log($"Received Ready from user {e.User.Username}");
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                VRChatifyUtils.Log($"Received Update! {e.Presence}");
            };

            client.Initialize();

            client.SetPresence(presence);
        }
        public static void KillRPC()
        {
            client.Dispose();
        }
        public class CollectionInfo
        {
            [JsonPropertyName("artistName")]
            public string ArtistName { get; set; }

            [JsonPropertyName("collectionName")]
            public string CollectionName { get; set; }

            [JsonPropertyName("artworkUrl100")]
            public string ArtworkUrl100 { get; set; }
        }

        public class ApiResponse
        {
            [JsonPropertyName("resultCount")]
            public int ResultCount { get; set; }

            [JsonPropertyName("results")]
            public List<CollectionInfo> Results { get; set; }
        }

        public static async void Update()
        {
           

        }
        public static string GetCover()
        {
            var web = new WebClient();
            var thing = web.DownloadString($"https://itunes.apple.com/search?term={VRChatify.mediaManager.GetAlbumTitle().Replace(' ', '+')}&country=us&entity=album&limit=15");

            string json = thing;

            ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(json);

            if (apiResponse != null && apiResponse.Results != null)
            {

                foreach (var collectionInfo in apiResponse.Results)
                {
                    if (collectionInfo.ArtistName == VRChatify.mediaManager.GetSongArtist() && collectionInfo.CollectionName == VRChatify.mediaManager.GetAlbumTitle())
                    {
                        Console.WriteLine("Artwork URL: " + collectionInfo.ArtworkUrl100);
                        return collectionInfo.ArtworkUrl100.Replace("100x100bb.jpg", "600x600bb.jpg");
                    }
                    else
                    {
                        Console.WriteLine("Artist or collection name does not match for: " + collectionInfo.ArtistName + " - " + collectionInfo.CollectionName);
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed to deserialize JSON.");
            }
            return "";
        }
        public static string lastartist = "";
        public static string laststate = "";
        public static string lastcover = "";
        public static string lastinfo = "";

        public static async void UpdateDetails(string details)
        {

            if (VRChatify.mediaManager.PlaybackState() == "Paused" && VRChatify.mediaManager.PlaybackState() != laststate && lastartist == VRChatify.mediaManager.GetSongArtist())
            {
                presence.Details = "▶️";
                laststate = "Paused";
                presence.Assets.LargeImageKey = lastcover;
                presence.Assets.LargeImageText = lastinfo;
                client.SetPresence(presence);

            }
            else if (VRChatify.mediaManager.PlaybackState() == "" && VRChatify.mediaManager.PlaybackState() != laststate && lastartist == VRChatify.mediaManager.GetSongArtist())
            {
                presence.Details = "🎶";
                laststate = "";
                presence.Assets.LargeImageKey = lastcover;
                presence.Assets.LargeImageText = lastinfo;
                client.SetPresence(presence);

            }
            if (lastartist != VRChatify.mediaManager.GetSongArtist() && VRChatify.mediaManager.PlaybackState() != "Paused")
            {
                client.UpdateLargeAsset(GetCover(), $"{VRChatify.mediaManager.GetSongArtist()} - {VRChatify.mediaManager.GetSongName()}");
                presence.Assets.LargeImageKey = GetCover();
                presence.Assets.LargeImageText = $"{VRChatify.mediaManager.GetSongArtist()} - {VRChatify.mediaManager.GetSongName()}";
                lastartist = VRChatify.mediaManager.GetSongArtist();
                lastcover = GetCover();
                lastinfo = $"{VRChatify.mediaManager.GetSongArtist()} - {VRChatify.mediaManager.GetSongName()}";
                client.SetPresence(presence);
            }
           

          
        }
    }
}
