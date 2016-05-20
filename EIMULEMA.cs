using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BFS
{
    class Program
    {
        static List<int>[] graph; static Boolean[] check; static Queue<int> qList;
        static void Main(string[] args)
        {
            int n = NextInt(); int m = NextInt(); graph = new List<int>[n]; check = new Boolean[n];
            qList = new Queue<int>(); for (int i = 0; i < n; i++) { graph[i] = new List<int>(); }
            for (int i = 0; i < m; i++)
            {
                int u = NextInt();
                int v = NextInt(); graph[u].Add(v);
            }
            for (int i = 0; i < n; i++)
            {
                if (graph[i] != null)
                {
                    graph[i].Sort();
                }
            }
            for (int i = 0; i < n; i++) { if (graph[i] != null) { BreakFirstSearch(i); } }
        }
        static void BreakFirstSearch(int s)
        {
            qList.Enqueue(s);
            while (qList.Count != 0)
            {
                var tmp = qList.Dequeue();
                if (check[tmp] == false)
                {
                    Console.Write(tmp + " ");
                    check[tmp] = true;
                }
                for (int i = 0; i < graph[tmp].Count;
                    i++)
                {
                    var t = graph[tmp][i];
                    if (check[t] == false)
                    {
                        check[tmp] = true; qList.Enqueue(t)
       ;
                    }
                }
            }
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
        private static long NextLong() { return Int64.Parse(Next()); }
    }
}