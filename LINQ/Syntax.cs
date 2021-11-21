using System;
using System.Linq;

namespace LINQ
{
    class Syntax
    {
        static void Main(string[] args)
        {
            string[] niveles = { "Basic", "Middle", "Advanced" };
            var nc = niveles.Count();
            int max = 6;
            //Count and Where extension methods with Lambda
            var ns = niveles.Where(n => n.Length > max).OrderBy(no => no);
            foreach (var n in ns)
            {
                Console.WriteLine(n);
            }
            //LINQ Syntax Consult Expression
            var qn =
                from nivel in niveles //sequence
                where nivel.Length > max
                orderby nivel ascending //Add orde
                select nivel;
            Console.WriteLine(qn);
        }
    }
}
