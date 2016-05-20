using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MAKEFRIEND
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine().Trim().ToArray();
            var check = "konichiwa".ToArray();
            int i = 0;
            int number = 1;
            for (int j = 0; j < a.Length; j++)
            {
                if (number == 10)
                {
                    break;
                }
                if (check[i]==a[j])
                {
                    i++;
                    number++;
                }
            }
            if (number >9)
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
