using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EILAPTOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = NextInt();
            var big = false;
            var small = false;
            while (t-- > 0)
            {
                var tmp = NextInt() - NextInt();
                if (tmp>0)
                {
                    big = true;
                }
                if (tmp<0)
                {
                    small = true;
                }
            }

            Console.WriteLine(big == true && small == true ? "Happy Beo" : "Poor Beo");
        }

        static int s_index = 0;
        static List<string> s_tokens;

        private static string Next()
        {
            while (s_tokens == null || s_index == s_tokens.Count())
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
    }   
}
