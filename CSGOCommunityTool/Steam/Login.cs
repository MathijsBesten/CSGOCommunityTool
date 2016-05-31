using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGOCommunityTool;
using System.IO;
using System.Net;
using SteamWebAPI;


namespace CSGOCommunityTool.Steam
{
    class login
    {
        static void steamLogin()
        {
            SteamAPISession session = new SteamAPISession();

            Console.Write("Username: ");
            String username = Console.ReadLine();
            Console.Write("Password: ");
            String password = Console.ReadLine();

            SteamAPISession.LoginStatus status = session.Authenticate(username, password);
            if (status == SteamAPISession.LoginStatus.SteamGuard)
            {
                Console.Write("SteamGuard code: ");
                String code = Console.ReadLine();

                status = session.Authenticate(username, password, code);
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
