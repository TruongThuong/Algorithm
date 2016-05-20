using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO_STR
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Next().ToArray();
            var listConvert = new List<Convert>();
            var getNumber = "";
            var j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var tmp = (int)a[i]-48;
                if (tmp>=0 && tmp<=9)
                {
                    getNumber += a[i];
                    a[i] = '0';
                    for (j = i+1; j < a.Length; j++)
                    {
                        var tmp2 = (int)a[j] - 48;
                        if (tmp2<0 || tmp2>9)
                        {
                            break;
                        }
                        getNumber += a[j];
                        i = j;
                        a[j] = '0';
                    }

                    listConvert.Add(new Convert(getNumber,int.Parse(getNumber)));
                    getNumber = "";
                }
            }
            listConvert.Sort();

            var result = new StringBuilder();
            j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i]!='0') {
                    result.Append(a[i]);
                }
                else
                {
                    for (int k = i + 1; k < a.Length; k++)
                    {
                        if (a[k]!='0')
                        {
                            break;
                        }
                        i = k;
                    }
                    result.Append(listConvert[j].number);
                    j++;
                }
            }
            Console.WriteLine(result);
        }
        class Convert:IComparable<Convert>
        {
            public string number;
            public int v;

            public Convert(string number, int v)
            {
                this.number = number;
                this.v = v;
            }

            public int CompareTo(Convert that)
            {
                return this.v - that.v;
            }
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

        private static bool HasNext()
        {
            while (s_tokens == null || s_index == s_tokens.Count)
            {
                s_tokens = null;
                s_index = 0;
                var nextLine = Console.ReadLine();
                if (nextLine != null)
                {
                    s_tokens = nextLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else
                {
                    return false;
                }

            }
            return s_tokens.Count > 0;
        }

        private static int NextInt()
        {
            return Int32.Parse(Next());
        }

        private static double NextDouble()
        {
            return double.Parse(Next());
        }

        private static long NextLong()
        {
            return Int64.Parse(Next());
        }
    }
}
