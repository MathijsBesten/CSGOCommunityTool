using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSGOCommunityTool.functions
{
    class HTMLDownloader
    {
        public static string downloadWebpage(string url)
        {
            string stringHTML = "";
            using (WebClient webClient = new WebClient())
            {
                stringHTML = webClient.DownloadString(url);
            }
            return stringHTML;
        }
    }
}
