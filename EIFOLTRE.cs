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
        static int n;
        static void Main(string[] args)
        {
            n = NextInt();


            var nodes = ReadGraph(n, n - 1);

            DFS(nodes[0]);

            Console.Write(max);
            Console.ReadKey();
        }
        class VertexLength : IComparable<VertexLength>
        {
            public Vertex vertex;
            public int length;
            public VertexLength(Vertex vertex, int length)
            {
                this.vertex = vertex;
                this.length = length;
            }
            public int CompareTo(VertexLength other)
            {
                return other.length - length;
            }


        }
        static int max = 0;
        static StringBuilder buffer = new StringBuilder();
        static void DFS(Vertex node)
        {
            node.isVisited = true;
            node.children.Sort();
            foreach (var v in node.children)
            {
                if (!v.vertex.isVisited)
                {
                    var a = v.vertex.vlength += v.length + node.vlength;
                    if (max < a)
                    {
                        max = a;
                    }
                    DFS(v.vertex);

                }
            }

        }
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
                var length = NextInt();
                // Directed Graph

                nodes[vi].Add(new VertexLength(nodes[vj], length));
                // Undirected Graph
                nodes[vj].Add(new VertexLength(nodes[vi], length));
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
            public List<VertexLength> children = new List<VertexLength>();

            public int vlength = 0;

            internal bool isVisited;

            public int Count { get { return children.Count; } }

            public Vertex(int id)
            {
                this.id = id;
            }
            public int CompareTo(Vertex other)
            {
                return id - other.id;
            }

            internal void Add(VertexLength vertexLength)
            {
                children.Add(vertexLength);
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