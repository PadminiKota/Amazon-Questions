using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_K_Frequently_Mentioned
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> keywords = new List<string>();
            keywords.Add("gatsby");
            keywords.Add("american");
            keywords.Add("novel");
            List<string> reviews = new List<string>();
            reviews.Add("Classic. Yes. The great American novel. Hmph, so I heard.");
            reviews.Add("Most American high school students are assigned to read this novel.");
            reviews.Add("The Great Gatsby is often described as a paean to the Great American Dream");
            var output = topMentioned(2, keywords, reviews);
        }
        public static List<String> topMentioned(int k, List<String> keywords, List<String> reviews)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for(int i=0;i<keywords.Count;i++)
                dict.Add(keywords[i].ToLower(), 0);
            foreach(var str in reviews)
            {
                string[] vals = str.Split(' ');
                for(int j=0;j<vals.Length;j++)
                {
                    if (dict.ContainsKey(vals[j].ToLower()))
                        dict[vals[j].ToLower()]++;
                }
            }
            return dict.OrderByDescending(x => x.Value).Select(y => y.Key).Take(k).ToList();
        }
    }
}
