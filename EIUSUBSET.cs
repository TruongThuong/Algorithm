using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIUSUBSET
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = NextInt();
            var arr = new List<int>();
            var newArray = new List<string>();
            while (t-- > 0)
            {
                arr.Add(NextInt());
            }
            for (int i = arr.Count-1; i >=0; i--)
            {
                string tmp = "";
                for (int j = i; j < arr.Count; j++)
                {
                    tmp += arr[j] + " ";
                    newArray.Add(tmp);                    
                }
            }
            StringBuilder result = new StringBuilder();
            result.Append(newArray.Count + "\n");
            for (int i = 0; i <newArray.Count; i++)
            {
                result.Append(newArray[i] +"\n");
            }
            Console.Write(result);
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
