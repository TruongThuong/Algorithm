using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_Undirected

{
    class Program
    {
        static List<int>[] graph;

        static void Main(string[] args)
        {
            int n = NextInt();
            int m = NextInt();

            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < m; i++)
            {
                int u = NextInt();
                int v = NextInt();

                graph[u].Add(v);
                graph[v].Add(u);
            }

            for (int i = 0; i < n; i++)
            {
                graph[i].Sort();
            }
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                result.Append(i +" " +graph[i].Count+" ");
                foreach (var node in graph[i])
                {
                    result.Append(node+" ");                   
                }
                result.Append("\n");
            }
            Console.WriteLine(result);
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

