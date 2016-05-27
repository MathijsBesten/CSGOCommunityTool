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
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace CSGOCommunityTool.Funtions
{
    class NewsReader
    {
        public static List<List<string>> allItems = new List<List<string>>();
        public static void newsReader()
        {
            using (XmlReader reader = XmlReader.Create("http://blog.counter-strike.net/index.php/feed/"))
            {
                string title = null;
                string link = null;
                string pubDate = null;
                string description = null;
                string content = null;
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "title":
                                string titleHTML = reader.ReadString();
                                title = stringcorrector(titleHTML);
                                break;
                            case "link":
                                string linkHTML = reader.ReadString();
                                link = stringcorrector(link);
                                break;
                            case "pubDate":
                                string pubDateHTML = reader.ReadString();
                                pubDate = stringcorrector(pubDateHTML);
                                break;
                            case "description":
                                string descriptionHTML = reader.ReadString();
                                description = stringcorrector(descriptionHTML);
                                break;
                            case "content:encoded":
                                string contentHTML = reader.ReadString();
                                content = stringcorrector(contentHTML);
                                allItems.Add(new List<string> {title,link,pubDate,description,content});
                                break;
                        }
                    }
                }
            }
        }
        public static string stringcorrector(string notCorrectedString)
        {
            if (notCorrectedString != null)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(notCorrectedString);
                string betterSting = htmlDoc.DocumentNode.InnerHtml;
                return betterSting;
            }
            else
            {
                return notCorrectedString;
            }
        }
    }
}