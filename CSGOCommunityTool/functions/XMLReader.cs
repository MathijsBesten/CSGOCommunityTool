using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSGOCommunityTool.functions
{
    class XMLReader
    {
        public static void generalXMLReader(string url)
        {
            WebClient client = new WebClient();
            XmlDocument xmlDoc = new XmlDocument();
            string xmlData = client.DownloadString(url);
            xmlData = HTMLParse.removeEscapeCharacters(xmlData);
            xmlDoc.LoadXml(xmlData);

            string xpath = xmlData;
            var nodes = xmlDoc.SelectNodes(xpath);

            foreach (XmlNode childrenNode in nodes)
            {
                Console.WriteLine(childrenNode);
            }
        }
    }
}
