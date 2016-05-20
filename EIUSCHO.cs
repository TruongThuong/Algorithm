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
            var n = NextInt();
            var k = NextInt();
            var t = NextInt();
            var list = new List<Student>();

            var dic = new Dictionary<int, int>();
            var i = 0;

            while (n-- > 0)
            {
                var id = NextInt();
                var sub = NextInt();
                dic.Add(id,i);
                list.Add(new Student(id, sub));
                i++;
            }

            while (t-- > 0)
            {
                var id = NextInt();
                var index = dic[id];
                list[index].addScore(NextInt(), NextDouble());
            }
            list.Sort();
            var count = 0;

            StringBuilder result = new StringBuilder();
            var last = 0;

            for (int j  = 0; j < list.Count-1; j++)
            {
                if (count < k)
                {
                    result.Append(list[j].id + "\n");
                    count++;
                }
                if (list[j + 1].study != list[j].study)
                {
                    count = 0;
                }
            }
            if (count < k)
            {
                result.Append(list[list.Count - 1].id);
            }
            Console.WriteLine(result);
        }

        class Student : IComparable<Student>
        {
            public int id = 0;
            public double score = 0.0;
            public int count = 0;
            public double average = 0.0;
            public int study = 0;


            public Student(int v1, int v2)
            {
                this.id = v1;
                this.study = v2;
            }
            public void addScore(int sub, double score)
            {
                this.score += score;
                this.count++;
                this.average = this.score / count;              
            }
            public int CompareTo(Student that)
            {
                var tmp = this.study.CompareTo(that.study);
                if (tmp == 0)
                {
                    var tmp2 = -this.average.CompareTo(that.average);
                    return tmp2 == 0 ? this.id.CompareTo(that.id) : tmp2;
                }
                else
                {
                    return tmp;
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


