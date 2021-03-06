﻿using System;
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

namespace CSGOCommunityTool.Menu
{
    /// <summary>
    /// Interaction logic for ProfileCSGOStats.xaml
    /// </summary>
    public partial class ProfileCSGOStats : UserControl
    {
        public int i = 0;
        public int location = 0;
        public string playerFriendUrl = "http://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key=14A21E6B2EC8A4B857AA20CF416B38DE&steamid=";
        public string playerDetailUrl = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=14A21E6B2EC8A4B857AA20CF416B38DE&steamids=";
        public static string LoggedInUser = "";
        public static string steamAPIey = "14A21E6B2EC8A4B857AA20CF416B38DE";
        public static string UserId = "";
        public static List<List<string>> friendlist = new List<List<string>>();
        public ProfileCSGOStats()
        {
            InitializeComponent();
            friendlist.Clear();
            UserId = functions.ProfileSaver_ProfileReader.checkForProfile();
            FriendList();
            lb_friendnumber.Content = friendlist.Count().ToString();
            string steamID = ProfileSaver_ProfileReader.checkForProfile();
            if (steamID != "NoProfileFound" && steamID != "NoProfileFile")
            {
                var profileInfo = functions.JSONReader.ReadJSON(playerDetailUrl + UserId, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // gets all information about profile
                string avatarImageLink = profileInfo[13].Insert(6, ":");
                BitmapImage bitmapImage = new BitmapImage(new Uri(avatarImageLink));
                steamNameBox2.Text = profileInfo[3];
                avatarBox2.Source = bitmapImage;
                ButtonLoginLogout.Content = "Logout";
            }

            foreach (var friend in friendlist)
            {
                Label lb = new Label();
                lb.Height = 28;
                lb.Width = 100;
                lb.HorizontalAlignment = HorizontalAlignment.Left;
                lb.VerticalAlignment = VerticalAlignment.Top;
                lb.Content = friendlist[i][3];
                i++;
                lb.Margin = new Thickness(0, location, 0, 0);
                location += 20;
                friendlistgrid.Children.Add(lb);
            }

        }
        public async void FriendList()
        {
            if (UserId == "NoProfileFound")
            {
                MessageBox.Show("You Need to log in first");
            }
            else
            {

                var profileFriends = functions.JSONReader.ReadJSON(playerFriendUrl + UserId, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // get all friends from profile
                foreach (var friend in profileFriends)
                {
                    var friends = functions.JSONReader.ReadJSON(playerDetailUrl + friend, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // gets all information about profile
                    friendlist.Add(friends);
                }
            }
            lb_friendnumber.Content = friendlist.Count().ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonLoginLogout.Content == "Logout")
            {
                ProfileSaver_ProfileReader.logoutProfile();
                steamNameBox2.Text = "";
                avatarBox2.Source = null;
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
                        steamNameBox2.Text = profileInfo[3];
                        avatarBox2.Source = bitmapImage;
                        LoggedInUser = activeSteamProfile;
                        ButtonLoginLogout.Content = "Logout";
                    }
                }
            }
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
