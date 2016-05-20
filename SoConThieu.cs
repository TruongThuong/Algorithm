using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoConThieu
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^(-??[0-9]*\?+[0-9]*|-??[0-9]+)|(\W)");
            int t = NextInt();
            while (t-- > 0)
            {
                string str = Console.ReadLine().Trim();
                foreach (Match match in regex.Matches(str))
                {

                }
            }

        }

        static int s_index = 0; static List<string> s_tokens;
        private static string Next()
        {
            while (s_tokens == null || s_index == s_tokens.Count)
            {
                s_tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                s_index = 0;
            }
            return s_tokens[s_index++];
        }
        private static int NextInt()
        {
            return Int32.Parse(Next());
        }
        private static long NextLong()
        {
            return Int64.Parse(Next());
        }
    }
}
