using CSGOCommunityTool.displays.loginScreen;
using CSGOCommunityTool.functions;
using CSGOCommunityTool.public_properties;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CSGOCommunityTool.Menu
{
    /// <summary>
    /// Interaction logic for CSGOStats.xaml
    /// </summary>
    public partial class CSGOStats : UserControl
    {

        public static string LoggedInUser = "";
        public string playerDetailUrl = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=14A21E6B2EC8A4B857AA20CF416B38DE&steamids=";
        public string userFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CSGOCommunityTool" + "\\" + "userdetails.txt";
        public static string steamAPIey = "14A21E6B2EC8A4B857AA20CF416B38DE";
        public CSGOStats()
        {
            InitializeComponent();
            string profile = ProfileSaver_ProfileReader.checkForProfile(); //check if there is anybody logged in
            if (File.Exists(userFilePath))
            {
                string steamID = ProfileSaver_ProfileReader.checkForProfile();
                if (steamID != "NoProfileFound" && steamID != "NoProfileFile")
                {
                    var profileInfo = functions.JSONReader.ReadJSON(playerDetailUrl + profile, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // gets all information about profile
                    string avatarImageLink = profileInfo[13].Insert(6, ":");
                    BitmapImage bitmapImage = new BitmapImage(new Uri(avatarImageLink));
                    steamNameBox.Text = profileInfo[3];
                    avatarBox.Source = bitmapImage;
                    ButtonLoginLogout.Content = "Logout";
                    LoggedInUser = steamID; // start getting csgo stats
                    string csgoStatsLink = "http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/?appid=730&key=14A21E6B2EC8A4B857AA20CF416B38DE&steamid=" + LoggedInUser;
                    Console.WriteLine("");
                }
            }
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
                    if (activeSteamProfile != "NoProfileFound" && activeSteamProfile != "NoProfileFile")
                    {
                        var profileInfo = functions.JSONReader.ReadJSON(playerDetailUrl + activeSteamProfile, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // gets all information about profile
                        string avatarImageLink = profileInfo[13].Insert(6, ":");
                        BitmapImage bitmapImage = new BitmapImage(new Uri(avatarImageLink));
                        steamNameBox.Text = profileInfo[3];
                        avatarBox.Source = bitmapImage;
                        LoggedInUser = activeSteamProfile;
                        getAllCSGOStats();
                        ButtonLoginLogout.Content = "Logout";
                    }
                }
            }
        }
        private void getAllCSGOStats()
        {
            if (LoggedInUser != "NoProfileFound" && LoggedInUser != "NoProfileFile" && LoggedInUser != "")
            {
                string CSGODataURL = "http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/?appid=730&key=14A21E6B2EC8A4B857AA20CF416B38DE&steamid=" + LoggedInUser;
                Console.WriteLine("");
            }
        }





























        private void MenuItem_Profile_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ProfileCSGOStats());
        }

        private void MenuItem_Statistics_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CSGOStats());
        }

        private void MenuItem_Home_click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new LoginNewsPage());
        }

        private void sideBarTriggerArea_MouseEnter(object sender, MouseEventArgs e)
        {
            SideBarMenu.Visibility = Visibility.Visible;
        }

        private void SideBarMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            SideBarMenu.Visibility = Visibility.Collapsed;
        }

    }
}
