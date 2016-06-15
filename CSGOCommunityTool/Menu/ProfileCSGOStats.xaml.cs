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

namespace CSGOCommunityTool.Menu
{
    /// <summary>
    /// Interaction logic for ProfileCSGOStats.xaml
    /// </summary>
    public partial class ProfileCSGOStats : UserControl
    {
        public string playerFriendUrl = "http://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key=14A21E6B2EC8A4B857AA20CF416B38DE&steamid=";
        public static string steamAPIey = "14A21E6B2EC8A4B857AA20CF416B38DE";
        public static string UserId = "";
        public ProfileCSGOStats()
        {

            InitializeComponent();
            //var UserId = CSGOCommunityTool.functions.ProfileSaver_ProfileReader.checkForProfile();
            var UserId = "76561198009299347";
            if (UserId == "NoProfileFound")
            {
                MessageBox.Show("You Need to log in first");
            }
            else
            {
                var profileFriends = functions.JSONReader.ReadJSON(playerFriendUrl + UserId, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // get all friends from profile
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
