using System;
using System.Linq;

namespace Demo16
{
    class Program
    {
        static void Main(string[] args)
        {
            //var getallen = Enumerable.Repeat(7, 10);

            //foreach (var g in getallen)
            //{
            //    Console.WriteLine(g);
            //}
            var getallen = (from n in Enumerable.Range(100, 50) 
                         select new {   Getal= n, 
                                        EvenOneven= (n % 2 == 1 ? "oneven" : "even")}
                                        );

            foreach (var n in getallen)
            {
                Console.WriteLine("Het getal {0} is {1}.", n.Getal, n.EvenOneven);
            }

        }
    }
}
