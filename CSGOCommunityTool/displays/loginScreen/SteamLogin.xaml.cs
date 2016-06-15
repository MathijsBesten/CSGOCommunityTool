using System.Windows;

namespace CSGOCommunityTool.displays.loginScreen
{
    /// <summary>
    /// Interaction logic for SteamGuard.xaml
    /// </summary>
    public partial class steamLogin : Window
    {
        public steamLogin()
        {
            InitializeComponent();

        }
        public string enteredSteamID {get { return SteamID.Text; } }

        private void SteamGuardLogin_Click(object sender, RoutedEventArgs e)
        {
            if (SteamID.Text != "")
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("You have not entered your steam ID");
            }
        }

        private void linkToProfileButton_click(object sender, RoutedEventArgs e)
        {
            string linkToProfile = "http://steamcommunity.com/my/profile";
            System.Diagnostics.Process.Start(linkToProfile);
        }
    }
}
