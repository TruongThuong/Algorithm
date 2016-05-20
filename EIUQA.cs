using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIUQA
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = NextInt();
            var dic = new Dictionary<int, List<int>>();
            var list = new List<int>();
            StringBuilder result = new StringBuilder();
            while (n-- > 0)
            {
                var t = NextInt();
                if (t == 1)
                {
                    var key = NextInt();
                    list.Add(key);
                    if (dic.ContainsKey(key))
                    {
                        dic[key].Add(NextInt());
                    }
                    else
                    {
                        dic.Add(key, new List<int>());
                        dic[key].Add(NextInt());
                    }
                }

                if (t == 2)
                {
                    var k = NextInt();
                    if (dic.ContainsKey(k))
                    {
                        result.Append(dic[k].Count + "\n");
                    }
                    else { result.Append(0 + "\n"); }
                }
                if (t == 3)
                {
                    var tmp = 0;
                    var k = NextInt();
                    var numberOf = NextInt();
                    for (int i = list.Count - 1; i >= 0 && numberOf > 0; i--)
                    {
                        if (list[i] == k)
                        {
                            tmp++;
                        }
                        numberOf--;
                    }
                    result.Append(tmp + "\n");
                }

                if (t == 4)
                {
                    var k = NextInt();
                    var numberOf = NextInt();
                    if (dic.ContainsKey(k))
                    {
                        for (int i = dic[k].Count - 1; i >= 0 && numberOf > 0; i--)
                        {
                            result.Append(dic[k][i] + "\n");
                        }
                    }
                    //else { result.Append(0 + "\n"); }
                }
            }
            Console.Write(result);
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
