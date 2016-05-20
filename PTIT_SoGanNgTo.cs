using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTIT_SoGanNgTo
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = NextInt();

            var a = new List<long>();
            var number = new int [1000001];

            for (int i = 2; i < 1000001; i++)
            {
                if (number[i] == 0)
                {
                    a.Add(i);
                    getNonePrime(i, number);
                    a.Add(i * i);
                }
            }            
            
            StringBuilder result = new StringBuilder();
            while (n-- > 0)
            {
                var tmp = NextInt();

                result.Append(a.Contains(tmp)? "YES\n" : "NO\n");
            }

            Console.WriteLine(result);
        }

        private static void getNonePrime(int i, int [] number)
        {
            for (int j = 2; j * i < 1000001; j++)
            {
                number[i * j] = 1;
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
