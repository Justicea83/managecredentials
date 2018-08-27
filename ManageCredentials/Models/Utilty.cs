using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Models
{
    public static class Utilty
    {
        public static string SummarizeText(string text,int maxLength = 40)
        {
            if (text.Length <= maxLength)
                return text;

            var words = text.Split(' ');
            var summaryWords = new List<string>();
            int totalItem = 0;
            foreach(var item in words)
            {
                summaryWords.Add(item);
                totalItem += item.Length + 1;
                if (totalItem > maxLength)
                    break;
            }
            var summary = string.Join(" ", summaryWords) + "...";
            return summary;

        }
    }
}
