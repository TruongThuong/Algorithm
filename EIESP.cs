using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIESP
{
    class Program
    {
        static bool[] visited;
        static Queue<int> queue;
        static bool[] flag;

        static void Main(string[] args)
        {
            int test = NextInt();
            while (test-- > 0)
            {
                int n = NextInt();
                int m = NextInt();

                List<int>[] list = new List<int>[n];
                visited = new bool[n];
                queue = new Queue<int>();
                flag = new bool[n];

                for (var i = 0; i < n; i++)
                {
                    list[i] = new List<int>();
                }
                for (var i = 0; i < m; i++)
                {
                    var a = NextInt();
                    var b = NextInt();
                    list[a].Add(b);
                    list[b].Add(a);
                }
                
                flag[0] = true;
                bool check = true;
                visited[0] = true;
                queue.Enqueue(0);
                while (queue.Count != 0)
                {
                    if (!check)
                    {
                        break;
                    }
                    var a = queue.Dequeue();
                    foreach (var ea in list[a])
                    {
                        if (!visited[ea])
                        {
                            visited[ea] = true;
                            flag[ea] = !flag[a];
                            queue.Enqueue(ea);
                        }
                        else if (flag[ea] == flag[a])
                        {
                            check = false;
                            break;
                        }
                    }
                }
                if (check)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
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
            return int.Parse(Next());
        }
    }
}
