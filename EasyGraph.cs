using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIUBFS1
{
    class Program
    {
        private static bool[] visited;
        private static List<int>[] adjacencyMatrix;
        static StringBuilder res = new StringBuilder();
        static void Main(string[] args)
        {
            int n = NextInt();
            int m = NextInt();
            visited = new bool[n];
            adjacencyMatrix = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjacencyMatrix[i] = new List<int>();
            }
            for (int i = 0; i < m; i++)
            {
                int u = NextInt();
                int v = NextInt();
                adjacencyMatrix[u].Add(v);
            }
            for (int i = 0; i < n; i++)
            {
                adjacencyMatrix[i].Sort();
            }
            for (int i = 0; i < n; i++)
            {
                if (visited[i] != true)
                {
                    bfs(adjacencyMatrix, i);
                }
            }
            Console.WriteLine(res);
        }

        private static void bfs(List<int>[] adj, int v)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < adj.Length; i++)
            {
                if (visited[i] == false)
                {
                    queue.Enqueue(i);

                    while (queue.Count > 0)
                    {
                        int p = queue.Dequeue();
                        res.Append(p + " ");
                        visited[p] = true;

                        foreach (var item in adj[p])
                        {
                            if (visited[item] == false)
                            {
                                queue.Enqueue(item);
                                visited[item] = true;
                            }
                        }
                    }
                }

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

        private static long NextLong()
        {
            return Int64.Parse(Next());
        }

        /*
        static int s_index = 0;
        static string[] s_tokens;
        static EIHCON2()
        {
            s_tokens = (new StreamReader(Console.OpenStandardInput())).ReadToEnd().Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }
        private static string Next()
        {
            return s_tokens[s_index++];
        }
        private static bool HasNext()
        {
            return s_index < s_tokens.Length;
        }
        private static int NextInt()
        {
            return Int32.Parse(Next());
        }
        private static long NextLong()
        {
            return Int64.Parse(Next());
        }
         */
    }
}