using System;
using System.Linq;
namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gemeenten = { "Brussel", "Antwerpen", "Brugge", "Gent", "Kortrijk" };

            var paren =
                          from t1 in gemeenten
                          from t2 in gemeenten
                          select new { T1 = t1, T2 = t2 };

            foreach (var gemeentePaar in paren)
            {
                Console.WriteLine("({0}, {1})",
                   gemeentePaar.T1, gemeentePaar.T2);
            }

        }
    }
}
