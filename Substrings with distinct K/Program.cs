using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrings_with_distinct_K
{
    class Program
    {
        /***
         * 
         * Given a string s and an int k, return all unique substrings of s of size k with k distinct characters.

Examples
Example 1:
Input: s = awaglknagawunagwkwagl,k = 4
Output: ["wagl", "aglk", "glkn", "lkna", "knag", "gawu", "awun", "wuna", "unag", "nagw", "agwk", "kwag"]
Explanation:
Substrings in order are: wagl, aglk, glkn, lkna, kna", gawu, awun, wuna, unag, nagw, agwk, kwag, wagl wagl is repeated twice, but is included in the output once.

Example 2:
Input: s = abcabc,k = 3
Output: ["abc", "bca", "cab"]
Example 3:
Input: abacab = abcabc,k = 3
Output: ["bac", "cab"]
Constraints:
The input string consists of only lowercase English letters [a-z] 0 ≤ k ≤ 26****/
        static void Main(string[] args)
        {
            string s = "awaglknagawunagwkwagl";
            Solution S = new Solution();
           List<string> result= S.substring(s, 4);
        }
        class Solution
        {
            public List<string> substring(string s, int k)
            {
                HashSet<char> input_s = new HashSet<char>();
                char[] input_array = s.ToCharArray();
                StringBuilder sb = new StringBuilder();
                int i = 0, j = 0;
                List<string> output = new List<string>();
                while(i<input_array.Length-k && j<input_array.Length)
                {


                    while(!input_s.Contains(input_array[j]) && j<input_array.Length && j-i<k)
                    {
                        input_s.Add(input_array[j]);
                        sb.Append(input_array[j]);
                        j++;
                    }
                    while (input_s.Contains(input_array[j]) && i < input_array.Length - k && j-i<k)
                    {
                        input_s.Remove(input_array[i]);
                        sb.Remove(0, 1);
                        i++;
                    }
                    if (j-i==k)
                    {
                        output.Add(sb.ToString());
                        input_s.Remove(input_array[i]);
                        sb.Remove(0, 1);
                        i++;                           
                    }
                }
                return output;

            }
        }
    }
}
