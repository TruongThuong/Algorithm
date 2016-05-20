using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EIUGRADE
{
    class EIUGRADE
    {
        static void Main(string[] args)
        {
            var t = NextInt();
            var check = new Dictionary<int, Student>();
            var i = 0;
            while (t-- > 0)
            {
                var id = NextInt();
                var sub = NextInt();
                if (!check.ContainsKey(id))
                {
                    check.Add(id, new Student(NextDouble()));
                }
                else
                {
                    check[id].add(NextDouble());
                }
            }


            foreach (var item in check)
            {
                item.Value.callAvarege();
            }
            // tu sort
            foreach (var item in check)
            {
                    Console.WriteLine(item.Key + " " + item.Value.average);
            }

        }

        class Student:IComparable<Student>
        {
            public int id = 0;
            public double score = 0.0;
            public int count = 0;
            public double average = 0.0;
            public Student( double nextDouble)
            {
                this.score += nextDouble;
                this.count=1;
                this.average = this.score / this.count;
            }

            public void add(double v)
            {
                score += v;
                count++;
            }
            public void callAvarege()
            {
                average = this.score / this.count;
            }

            public int CompareTo(Student that)
            {
                var tmp = this.average.CompareTo(that.average);
                if (tmp == 0)
                {
                    return this.id.CompareTo(that.id);
                }
                else
                {
                   return -this.average.CompareTo(that.average);
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


