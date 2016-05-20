using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EISCORING
{
    public class Program
    {
        public static int p = 0;
        public static void Main(string[] args)
        {
            var n = NextInt();
            var m = NextInt();
            p = NextInt();

            var list = new Student[n];
            for (int i = 0; i < n; i++)
            {
                list[i] = new Student(i+1);
                list[i].score = new int[p];
            }

            while (m-- > 0)
            {
                var id = NextInt()-1;
                list[id].addScore(NextInt()-1, NextInt());
            }
            Array.Sort(list);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var stu = list[i];
                result.Append(stu.id + " " + stu.total);
                foreach (var item in stu.score)
                {
                    result.Append(" "+item);
                }
                result.Append("\n");
            }

            Console.Write(result);
        }

        class Student : IComparable<Student>
        {
            public int id = 0;
            public int[] score;
            public int total = 0;

            public Student(int id)
            {
                this.id = id;
            }
            public void addScore(int index, int value)
            {
                var tmp = value - score[index];
                score[index] = score[index] < value ? value : score[index];                
                total += tmp > 0 ? tmp : 0;
            }

            public int CompareTo(Student other)
            {
                var tmp = other.total - this.total;
                return tmp == 0?this.id.CompareTo(other.id):tmp ;
            }
        }

        static int s_index = 0;
        static List<string> s_tokens;

        private static string Next()
        {
            while (s_tokens == null || s_index == s_tokens.Count())
            {
                s_tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                s_index = 0;
            }
            return s_tokens[s_index++];
        }
        private static int NextInt()
        {
            return Int32.Parse(Next());
        }
    }
}
