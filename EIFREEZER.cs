using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIFREEZER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = NextInt();

            int a = 0;
            int b = 0;
            int c = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= Math.Sqrt(n/i); j++)
                {
                    if (n % (i * j) == 0)
                    {
                        var k = n / (i * j);
                        a = i; b = j; c = k;
                    }
                }
            }
            Console.WriteLine(c + " " + b + " " + a);
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
