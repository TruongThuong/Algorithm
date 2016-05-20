using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = NextLong();
            var b = NextLong();
            var v = NextLong();

            double kw = (double)(v - b) / (a - b);
            Console.WriteLine(Math.Ceiling(kw));

        }

        static int s_index = 0;
        static List<string> s_tokens;

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
            return long.Parse(Next());
        }
    }
}
