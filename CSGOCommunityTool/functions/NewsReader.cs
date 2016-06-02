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
using System.Net;
using CSGOCommunityTool.functions;

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
                                title = HTMLParse.stringcorrector(titleHTML);
                                break;
                            case "link":
                                string linkHTML = reader.ReadString();
                                link = HTMLParse.stringcorrector(link);
                                break;
                            case "pubDate":
                                string pubDateHTML = reader.ReadString();
                                pubDate = HTMLParse.stringcorrector(pubDateHTML);
                                break;
                            case "description":
                                string descriptionHTML = reader.ReadString();
                                description = HTMLParse.stringcorrector(descriptionHTML);
                                break;
                            case "content:encoded":
                                string contentHTML = reader.ReadString();
                                content = HTMLParse.stringcorrector(contentHTML);
                                allItems.Add(new List<string> {title,link,pubDate,description,content});
                                break;
                        }
                    }
                }
            }
        }
    }
}