using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscreteMath2
{
    class EICONP
    {
        static void Main(string[] args)
        {
            var T = NextInt();
            for (int i = 0; i < T; i++)
            {
                var n = NextInt();
                var m = NextInt();
                var count = 0;

                var nodes = ReadGraph(n, m);

                foreach (var u in nodes)
                {
                    if (!u.IsVisited)
                    {
                        count++;
                        DFS(u);
                    }

                }
                if (count == 1 && m == n - 1)
                {

                    Console.Write("YES");
                }
                else
                {
                    Console.Write("NO");
                }
            }
            Console.ReadLine();

        }
        static void DFS(Vertex u)
        {
            u.IsVisited = true;
            foreach (var v in u.children)
            {
                if (!v.IsVisited)
                {
                    DFS(v);
                }
            }
        }

        static StringBuilder buffer = new StringBuilder();

        static Vertex[] ReadGraph(int nVertices, int nEdges)
        {
            Vertex[] nodes = new Vertex[nVertices];
            for (var i = 0; i < nVertices; i++)
            {
                nodes[i] = new Vertex(i);
            }

            for (var i = 0; i < nEdges; i++)
            {
                var vi = NextInt();
                var vj = NextInt();
                // Directed Graph
                nodes[vi].AddChild(nodes[vj]);
                // Undirected Graph
                nodes[vj].AddChild(nodes[vi]);
            }

            foreach (var node in nodes)
            {
                node.children.Sort();
            }
            return nodes;
        }

        class Vertex : IComparable<Vertex>
        {
            public int id = -1;
            public List<Vertex> children = new List<Vertex>();
            public bool IsVisited;

            public int Count { get { return children.Count; } }

            public Vertex(int id)
            {
                this.id = id;
            }

            public void AddChild(Vertex child)
            {
                children.Add(child);
            }

            public int CompareTo(Vertex other)
            {
                return id - other.id;
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
    }
}