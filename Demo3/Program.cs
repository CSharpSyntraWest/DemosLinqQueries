using System;
using System.Linq;
namespace Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vruchten = { "kers", "appel", "bosbes", "banaan" };

            //LINQ Query Expression Syntax:
            // Sorteren in alfabetische volgorde
            var fruitAlfabetisch =
                from fruit in vruchten
                orderby fruit
                select fruit;
   
            foreach (string fruit in fruitAlfabetisch)
            {
                Console.WriteLine(fruit);
            }
            Console.WriteLine("Linq query met Method syntax:");
            //LINQ Query Method Syntax(Lambdas):
            var fruitAlfabetischLambda =
                vruchten.OrderBy(f => f).Select(f=>f);
            foreach (string fruit in fruitAlfabetischLambda)
            {
                Console.WriteLine(fruit);
            }
        }
    }
}
