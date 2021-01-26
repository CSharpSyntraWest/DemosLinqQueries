using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoGroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
           // Demo1();
            Demo2();
        }

        private static void Demo2()
        {
            List<string> woorden = new List<string>() { "apple", "bosbes", 
                "banaan", "citroen","kiwi" };
            var woordGroepen = from woord in woorden
                               group woord by woord.Length into woordGroep
                               select (Lengte:woordGroep.Key, Woorden: woordGroep);
            //om uit te schrijven:
            //De lengten(Key-waarden) uitschrijven en alle woorden per groep 
            //die bij de Key-waarde van de groep horen
            foreach (var groep in woordGroepen)
            {
                Console.WriteLine($"Woorden met lengte {groep.Lengte} :");
                foreach (string woord in groep.Woorden)
                {
                    Console.WriteLine("\t" + woord);
                }
            }
        }

        private static void Demo1()
        {
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var getallenGroepen = from getal in getallen
                                  group getal by getal % 5 into groep
                                  select (RestBijDeling: groep.Key, Getallen: groep);

            foreach (var groep in getallenGroepen)
            {
                Console.WriteLine($"Getallen met rest {groep.RestBijDeling} bij deling door 5:");
                foreach (var getal in groep.Getallen)
                {
                    Console.WriteLine(getal);
                }
            }
        }
    }
}
