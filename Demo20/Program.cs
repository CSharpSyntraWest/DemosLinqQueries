using System;
using System.Linq;

namespace Demo20
{
    class Program
    {
        static void Main(string[] args)
        {
            DeferredLinqExecution();
            ImmediateLinqExecution();

        }

        private static void ImmediateLinqExecution()
        {
            // Methoden zoals ToList(), ToArray() zorgen //ervoor dat de query onmiddellijk wordt //uitgevoerd en de restultaten worden gecached.
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int i = 0;
            var q = (from n in getallen
                     select ++i).ToList();
            // De locale variabele i wordt reeds volledig //geïncrementeerd voordat we de resultaten //itereren via foreach:
            foreach (var v in q)
            {
                Console.WriteLine($"v = {v}, i = {i}");
            }
        }

        private static void DeferredLinqExecution()
        {
            //LINQ Deferred query execution (uitgesteld)
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int i = 0;
            var q = from n in getallen
                    select ++i;
            // de locale variabele 'i’ wordt niet //geïncrementeerd totdat elk element is //geëvalueerd (hier in de foreach) :
            foreach (var v in q)
            {
                Console.WriteLine($"v = {v}, i = {i}");
            }
        }
    }
}
