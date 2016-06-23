using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CSGOCommunityTool.functions
{
    class XMLReader
    {
        public static void generalXMLReader(string url)
        {
            List<string> variables = new List<string>();
            string webPageURL = url;
            XmlTextReader reader = new XmlTextReader(webPageURL);

            while (reader.Read())
            {
                if (reader.Value.Contains("\n") || reader.Value.Contains("\t"))
                {

                }
                else if (reader.Value == "")
                {

                }
                else
                {
                    variables.Add(reader.Value);
                }
            }
            Console.WriteLine("");
        }
    }
}
