using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOCommunityTool.public_properties
{
    class SteamProfile
    {
        private static List<string> playerstats = new List<string> { "steamid", "communityvisibilitystate", "profilestate", "personaname", "lastlogoff", "commentpermission", "profileurl", "avatar", "avatarmedium", "avatarfull", "personastate", "primaryclanid", "timecreated", "personastateflags" };
        private static string playerstatsend = ",";

        public static List<string> playerStats { get { return playerstats;} }
        public static string playerStatsEnd { get { return playerstatsend; } }

    }
}
