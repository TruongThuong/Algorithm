using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscreteMath2
{
    class EIUDFS1
    {
        static Vertex[] graph;
        static int max = 0;
        static List<int>[] result;
        static void Main(string[] args)
        {

            var n = NextInt();
            var m = NextInt();
            result = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = new List<int>();
            }
            graph = ReadGraph(n, m);

            var u = NextInt();
            BFS(graph[u]);

            var q = NextInt();
            foreach (var item in result)
            {
                item.Sort();
            }
            for (int i = 0; i < q; i++)
            {
                var qi = NextInt();
                if (qi > max)
                {
                    buffer.Append("-1\n");
                }
                else
                {
                    foreach (var item in result[qi])
                    {
                        buffer.Append(item + " ");
                    }
                    buffer.Append("\n");
                }
            }

            Console.Write(buffer);
        }
        private static void BFS(Vertex u)
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(u);

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                u.IsVisited = true;

                var level = v.level + 1;
                foreach (var item in v.children)
                {
                    if (!item.IsVisited)
                    {
                        item.level = level;
                        result[level].Add(item.id);
                        queue.Enqueue(item);

                        if (max < level)
                        {
                            max = level;
                        }

                        item.IsVisited = true;
                    }
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

            //foreach (var node in nodes)
            //{
            //    node.children.Sort();
            //}
            return nodes;
        }

        class Vertex : IComparable<Vertex>
        {
            public int level = 0;
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
