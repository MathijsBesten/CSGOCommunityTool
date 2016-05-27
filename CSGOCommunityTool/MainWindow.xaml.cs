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
        }
    }
}
