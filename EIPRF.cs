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
        static Vertex root;
        static StringBuilder result = new StringBuilder("");
        static Stack<int> stack = new Stack<int>();
        static int count = 0;
        static int n = 0;

        static void Main(string[] args)
        {

            n = NextInt();
            var m = NextInt();

            var nodes = ReadGraph(n, m);

            for (int i = 0; i < n; i++)
            {
                nodes[i].children.Sort();
            }

            root = nodes[0];

            Console.WriteLine(DFS(root));

        }
        static bool bol = false;
        static StringBuilder DFS(Vertex u)
        { 
            if (bol)
            {
                return result;
            }
            else
            {
                u.IsVisited = true;
                count++;                
                result.Append(u.id + " ");
                

                foreach (var item in u.children)
                {
                    if(item.children.Count == 0)
                    {
                        item.IsVisited = true;
                    }
                    else if (!item.IsVisited)
                    {
                        return DFS(item);
                    }
                    else if (item.id == 0)
                    {
                        bol = true;
                        return result;
                    }
                }                
            }
            if (bol)
            {
                return result;
            }
            return result;
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
                // Directed Graph
                nodes[vi].AddChild(nodes[vj]);
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
