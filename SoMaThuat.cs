using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoMaThuat
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"144|14|1");

            string str = Console.ReadLine().Trim();
            string kw = "";

            foreach (Match match in regex.Matches(str))
            {
                kw += match.Value;
            }

            if (kw.Equals(str))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
