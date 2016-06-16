using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

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

        public static string removeEscapeCharacters(string stringWithEscape)
        {
            string betterString = stringWithEscape;
            string sReplace = "";
            betterString = betterString.Replace("\a", sReplace); 
            betterString = betterString.Replace("\b", sReplace); 
            betterString = betterString.Replace("\f", sReplace);
            betterString = betterString.Replace("\n", sReplace);
            betterString = betterString.Replace("\r", sReplace);
            betterString = betterString.Replace("\t", sReplace);
            betterString = betterString.Replace("\v", sReplace);
            betterString = betterString.Replace("\'", sReplace);
            betterString = betterString.Replace("\"", sReplace);
            betterString = betterString.Replace("\\", sReplace);
            return betterString;
        }
    }
}
