using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimDuongVer2
{
    class EICON
    {
        static void Main(string[] args)
        {
            var n = NextInt();
            var m = NextInt();
            var q = NextInt();

            var array = new List<int>[n + 1];

            for (int i = 0; i < m; i++)
            {
                var u = NextInt();
                var v = NextInt();

                if (array[v] == null)
                {
                    array[v] = new List<int>();
                }
                array[v].Add(u);
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < q; i++)
            {
                var u = NextInt();
                var v = NextInt();

                if (array[u] != null && array[u].Contains(v))
                {
                    result.Append("Y\n");
                }
                else
                {
                    if (array[u]!=null)
                    {
                        var check = 0;
                        foreach (var each in array[u])
                        {
                            if (array[each] != null && array[each].Contains(v))
                            {
                                result.Append("Y\n");
                                check = 1;
                                break;
                            }
                        }
                        if (check == 0)
                        {
                            result.Append("N\n");
                        }                        
                    }
                    else
                    {
                        result.Append("N\n");
                    }
                }
            }
            Console.Write(result);
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


