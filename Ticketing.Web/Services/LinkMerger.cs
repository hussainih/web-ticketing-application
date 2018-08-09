using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketing.Services
{
    public class LinkMerger
    {
        public static string MergeLink(string LinkAddress, string BodyMessage)
        {
          
            var result = BodyMessage.Replace("[LINK]", "<a href=\"" + LinkAddress + "\">here</a>");
            return result;
        }
    }
}