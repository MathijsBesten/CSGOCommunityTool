using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSGOCommunityTool.functions;
using CSGOCommunityTool.displays.loginScreen;
using System.IO;

namespace CSGOCommunityTool.Menu
{
    public partial class LoginNewsPage : UserControl, ISwitchable
    {
        public static string LoggedInUser = "";
        public string playerDetailUrl = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=14A21E6B2EC8A4B857AA20CF416B38DE&steamids=";
        public string userFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CSGOCommunityTool" + "\\" + "userdetails.txt";
        public static string steamAPIey = "14A21E6B2EC8A4B857AA20CF416B38DE";

        public LoginNewsPage()
        {
            InitializeComponent();
            int count = 0;
            string testAccount = "76561197988627193"; //OLOFMEISTER BOOSTMEISTER        
            string profile = ProfileSaver_ProfileReader.checkForProfile(); //check if there is anybody logged in

            //Funtions.NewsReader.newsReader();
            //foreach (var item in Funtions.NewsReader.allItems)
            //{
            //    foreach (var stringObject in item)
            //    {
            //        if (count == 0)
            //        {
            //            newsSpot1.Text = stringObject;
            //        }
            //        else if (count == 1)
            //        {
            //            newsSpot2.Text = stringObject;
            //        }
            //        else if (count == 2)
            //        {
            //            newsSpot3.Text = stringObject;
            //        }
            //        else if (count == 3)
            //        {
            //            newsSpot4.Text = stringObject;
            //        }
            //        else if (count == 4)
            //        {
            //            newsSpot5.Text = stringObject;
            //        }
            //        else if (count == 5)
            //        {
            //            newsSpot6.Text = stringObject;
            //        }
            //    }
            //    count++;
            //}


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonLoginLogout.Content == "Logout")
            {
                ProfileSaver_ProfileReader.logoutProfile();
                steamNameBox.Text = "";
                avatarBox.Source = null;
                ButtonLoginLogout.Content = "Login";
            }
            else
            {
                steamLogin loginWindow = new steamLogin();
                loginWindow.ShowDialog();
                if (loginWindow.DialogResult == true)
                {
                    string userId = loginWindow.enteredSteamID;
                    var writeToFile = ProfileSaver_ProfileReader.checkForSteamIDInFile(userId);
                    var activeSteamProfile = ProfileSaver_ProfileReader.checkForProfile();
                    if (activeSteamProfile != "NoProfileFound" || activeSteamProfile != "NoProfileFile")
                {
                        var profileInfo = functions.JSONReader.ReadJSON(playerDetailUrl + activeSteamProfile, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // gets all information about profile
                    string avatarImageLink = profileInfo[13].Insert(6, ":");
                    BitmapImage bitmapImage = new BitmapImage(new Uri(avatarImageLink));
                    steamNameBox.Text = profileInfo[3];
                    avatarBox.Source = bitmapImage;
                    ButtonLoginLogout.Content = "Logout";
                    Switcher.Switch(new ProfileCSGOStats());
                }
                }
            }
        }

        void ISwitchable.UtilizeState(object state)
        {
            //
        }   

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(); ;
            Switcher.Switch(new ProfileCSGOStats());
        }
    }
}
