using System;
using System.Linq;

namespace Demo19
{
    class Program
    {
        static void Main(string[] args)
        {
            // DemoTake();
            // DemoSkip();
            //DemoTakeWhile();
            DemoSkipWhile();

        }

        private static void DemoSkipWhile()
        {
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Console.WriteLine("Alle elementen startend van het eerste drievoud:");
            var allButFirst3Numbers = getallen.SkipWhile(n => n % 3 != 0);
            foreach (var getal in allButFirst3Numbers)
            {
                Console.WriteLine(getal);
            }
            int[] getallen2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine(" Alle elementen startend van het eerste dat Kleiner is dan zijn positie(index):");
            var laterNumbers = getallen2.SkipWhile((n, index) => n >= index);
            foreach (var getal in laterNumbers)
            {
                Console.WriteLine(getal);
            }
        }

        private static void DemoTakeWhile()
        {
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("Eerste getallen Kleiner dan 6:");
            var eersteKleinerDan6 = getallen.TakeWhile(n => n < 6);
            foreach (var getal in eersteKleinerDan6)
            {
                Console.WriteLine(getal);
            }
            int[] getallen2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("Eerste getallen niet Kleiner dan hun positie(index):");

            var eersteNietKleinerDanIndex =
            getallen.TakeWhile((n, index) => n >= index);
            foreach (var getal in eersteNietKleinerDanIndex)
            {
                Console.WriteLine(getal);
            }
        }

        private static void DemoSkip()
        {
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var alleBehalveEerste4 = getallen.Skip(4);
            Console.WriteLine("Alle behalve de eerste 4 getallen:");
            foreach (var n in alleBehalveEerste4)
            {
                Console.WriteLine(n);
            }

        }

        private static void DemoTake()
        {
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var eerste3 = getallen.Take(3);
            Console.WriteLine("Eerste 3 getallen:");
            foreach (var g in eerste3)
            {
                Console.WriteLine(g);
            }
        }
    }
}
