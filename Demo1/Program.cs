using System;
using System.Linq;
namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //LINQ Query syntax:
            var kleineGetallen =
                from getal in getallen
                where getal < 5 
                select getal;
            foreach (int getal in kleineGetallen)
                Console.Write(getal + " ");

            Console.WriteLine("Zelfde linq query met method notatie (lambda)");
            //Zelfde LINQ Query maar met Method notatie (lambda-expressies)
            var kleineGetallenLambda = getallen.Where(getal => getal < 5).Select(g => g);
            foreach (int getal in kleineGetallenLambda)
                Console.Write(getal + " ");
            Console.WriteLine("oefening:");
            //Oefening: Schrijf een Linq query met Query syntax en eveneens met
            //de Method syntax; die alle getallen uit de lijst getallen teruggeeft 
            // tussen >=1 en < 8
            //https://www.tutorialsteacher.com/linq/what-is-linq
            //Oefening LINQ Query syntax:
            var selectieGetallen =
                from getal in getallen
                where getal >= 1 && getal < 8
                select getal;
            //Oefening Linq Method syntax:
            var selectieGetallenLambda =
                 getallen.Where(g => g >= 1 && g < 8).Select(g => g);
            foreach (int getal in selectieGetallenLambda)
                Console.Write(getal + " ");
            Console.ReadKey();
        }
    }
}
