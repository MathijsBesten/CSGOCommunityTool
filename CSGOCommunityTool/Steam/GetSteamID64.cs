using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOCommunityTool.functions
{
    class GetSteamID64
    {
        public static string grabSteamID64(string defaultSteamID)
        {
            string url = "https://steamid.io/lookup/";
            string fullWebpage = functions.HTMLDownloader.downloadWebpage(url + defaultSteamID);
            string startSteamID64 = "steamID64</dt>\n                <dd class=\"value short\">";
            int startIndex = fullWebpage.IndexOf(startSteamID64) + startSteamID64.Length;
            string steamID64 = fullWebpage.Substring(startIndex, 17);
            return steamID64;
        }
    }
}
