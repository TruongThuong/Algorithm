using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VALUEMAIL
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string email = Console.ReadLine().Trim();
            Regex teacher = new Regex(@"^\w+.\w+@eiu.edu.vn");
            Regex student = new Regex(@"^\w+.\w+.[a-z0-9]+@eiu.edu.vn");
            if (teacher.IsMatch(email))
            {
                result = Regex.Replace(email, teacher, "emty");
            }
            else if(student.IsMatch(email))
            {
                result.Append(email+" Student"+"\n");
            }
            else
            {
                result.Append("INVALID"+"\n");
            }
            Console.Write(result);
        }
    }
}
