using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimBac
{
    class EIUDeg
    {
        static void Main(string[] args)
        {
            var n = NextInt();
            var m = NextInt();

            var array = new int[n + 1];

            for (int i = 0; i < m; i++)
            {
                array[NextInt()]++;
                array[NextInt()]++;
            }

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                result.Append(array[i] + " ");
            }
            Console.Write(result);
            Console.ReadLine();
        }

        static int s_index = 0; static List<string> s_tokens;
        private static string Next()
        {
            while (s_tokens == null || s_index == s_tokens.Count)
            {
                s_tokens = Console.ReadLine().Split(' ').ToList();
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

