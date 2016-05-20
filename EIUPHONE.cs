using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EIUPHONE
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[0-9]+");

            var str = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            foreach (Match match in regex.Matches(str))
            {
                if (match.Value.Length == 10 || match.Value.Length == 11)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
