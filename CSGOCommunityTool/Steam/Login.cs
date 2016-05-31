using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGOCommunityTool;
using System.IO;
using System.Net;
using SteamWebAPI;
using CSGOCommunityTool;

namespace CSGOCommunityTool.Steam
{
    class login
    {
        public static void steamLogin(string username, string password)
        {
            SteamAPISession session = new SteamAPISession();
            var serverinfo = session.GetServerInfo();

            SteamAPISession.LoginStatus status = session.Authenticate(username, password);
            if (status == SteamAPISession.LoginStatus.SteamGuard)
            {
                Console.Write("SteamGuard code: ");
                Windows.SteamGuard.GetSteamGuardCode(username,password);

                //status = session.Authenticate(username, password, code);
            }

            if (status == SteamAPISession.LoginStatus.LoginSuccessful)
            {
                List<SteamAPISession.Friend> friends = session.GetFriends();
                int blockedFriends = friends.Count(f => f.blocked == true);
                Console.WriteLine("You have " + (friends.Count - blockedFriends) + " friends and " + blockedFriends + " fiends!");
            }
            else
            {
                Console.WriteLine("Failed to log in!");
            }
        }
    }

    
}
