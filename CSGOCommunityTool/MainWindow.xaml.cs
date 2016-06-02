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
using CSGOCommunityTool.Steam;
using System.Net;

namespace CSGOCommunityTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int count = 0;
            string steamAPIey = "14A21E6B2EC8A4B857AA20CF416B38DE";
            string testAccount = "76561197988627193"; //OLOFMEISTER BOOSTMEISTER
            string derpysAccount = "76561198035130499"; // Sir derpy
            string playerDetailUrl = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=14A21E6B2EC8A4B857AA20CF416B38DE&steamids=";


            Funtions.NewsReader.newsReader();
            foreach (var item in Funtions.NewsReader.allItems)
            {
                foreach (var stringObject in item)
                {
                    if (count == 0)
                    {
                        newsSpot1.Text = stringObject;
                    }
                    else if (count == 1)
                    {
                        newsSpot2.Text = stringObject;
                    }
                    else if (count == 2)
                    {
                        newsSpot3.Text = stringObject;
                    }
                    else if (count == 3)
                    {
                        newsSpot4.Text = stringObject;
                    }
                    else if (count == 4)
                    {
                        newsSpot5.Text = stringObject;
                    }
                    else if (count == 5)
                    {
                        newsSpot6.Text = stringObject;
                    }
                }
                count++;
            }

            //loading picture from account
            var profileInfo = functions.JSONReader.ReadJSON(playerDetailUrl + derpysAccount, public_properties.SteamProfile.playerStats, public_properties.SteamProfile.playerStatsEnd); // gets all information about profile
            string avatarImageLink = profileInfo[13].Insert(6,":"); 
            BitmapImage bitmapImage = new BitmapImage(new Uri(avatarImageLink));
            avatarBox.Source = bitmapImage;

            //loading username into steamNameBox
            steamNameBox.Text = profileInfo[3];

            Console.WriteLine();
        }
    }
}
