using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSGOCommunityTool.functions;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CSGOCommunityTool.functions
{
    class JSONReader
    {
        public static object HttpUtility { get; private set; }

        public static List<string> ReadJSON (string jsonURL, List<string> stringList,string endString)
        {
            var statsList = new List<string>();
            var allStatList = new List<int>();
            using (WebClient webClient = new WebClient())
            {
                int count = 0;
                int StartIndex, EndIndex;
                string urlData = webClient.DownloadString(jsonURL);
                urlData = Regex.Replace(urlData, @"\t|\n|\r", "");
                urlData = HTMLParse.removeEscapeCharacters(urlData);
                foreach (var item in stringList)
                {
                    foreach (Match match in Regex.Matches(urlData,item))
                    {
                        allStatList.Add(match.Index);
                        StartIndex = match.Index + match.Value.Length;
                        EndIndex = urlData.IndexOf(endString, StartIndex);
                        if (EndIndex == -1)
                        {
                            EndIndex = urlData.IndexOf("\"", StartIndex);
                        }

                        string stat = urlData.Substring(StartIndex, EndIndex - StartIndex);
                        if (stat.Contains(":") || stat.Contains("\\")|| stat.Contains("\""))
                        {
                            stat = stat.Replace(":", "");
                            stat = stat.Replace("\\", "");
                            stat = stat.Replace("\"", "");
                        }
                        statsList.Add(stat);
                    }
                }
            }
            return statsList;
        }
    }
}
