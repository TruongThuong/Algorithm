using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTIT_ChonCho
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = NextInt();
            int i = n;

            var a = new bool[3001];
            while (i-->0)
            {
                a[NextInt()] = true;
            }

            var check = false;
            for (int j = 1; j < a.Length; j++)
            {
                if (!a[j])
                {
                    Console.WriteLine(j);
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                Console.WriteLine(n + 1);
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
