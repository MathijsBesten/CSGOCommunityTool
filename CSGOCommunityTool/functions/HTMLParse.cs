using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSGOCommunityTool.functions
{
    class HTMLParse
    {
        public static string stringcorrector(string notCorrectedString)
        {
            if (notCorrectedString != null)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(notCorrectedString);
                string betterSting = htmlDoc.DocumentNode.InnerText;
                betterSting = WebUtility.HtmlDecode(betterSting);
                return betterSting;
            }
            else
            {
                return notCorrectedString;
            }
        }
    }
}
