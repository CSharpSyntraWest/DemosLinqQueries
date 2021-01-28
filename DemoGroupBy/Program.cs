using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoGroupBy
{
    class Dier
    { 
        public string Naam { get; set; }
        public double Leeftijd { get; set; }
       
    }



    class Program
    {
        static void Main(string[] args)
        {
            // Demo1();
            // Demo2();
            Demo3();
        }

        private static void Demo3()
        {
            List<Dier> dieren = new List<Dier>() {
                new Dier(){ Naam = "Bobby", Leeftijd = 4.3},
                new Dier(){ Naam="Minou", Leeftijd = 4.6},
                new Dier(){ Naam = "Fifi", Leeftijd=1.5},
                new Dier(){ Naam = "Rex", Leeftijd= 1.1},
                new Dier(){ Naam="Felix",Leeftijd=6.0}
                };
            var queryNotatieResultaat = from dier in dieren
                                        group dier by Math.Floor(dier.Leeftijd) into groep
                                        select new
                                        {
                                            DierKey = groep.Key,
                                            Aantal = groep.Count(),
                                            Minimum = groep.Min(d => d.Leeftijd),
                                            Maximum = groep.Max(d => d.Leeftijd)
                                        };

            var methodNotatieResultaat = dieren.GroupBy(dier => Math.Floor(dier.Leeftijd), 
                                            dier => dier.Leeftijd,
                                            (leeftijdKey, dierengroep) => new
                                            {
                                                DierKey = leeftijdKey,
                                                Aantal = dierengroep.Count(),
                                                Minimum = dierengroep.Min(),
                                                Maximum = dierengroep.Max()
                                            });
            //foreach (var groep in queryNotatieResultaat)
            //{
            //    Console.WriteLine(groep.DierKey + ":");
            //    Console.WriteLine("\t:" + groep.Aantal);
            //    Console.WriteLine("\t:" + groep.Minimum);
            //    Console.WriteLine("\t:" + groep.Maximum);
            //};
            foreach (var groep in methodNotatieResultaat)
            {
                Console.WriteLine(groep.DierKey + ":");
                Console.WriteLine("\tAantal dieren:" + groep.Aantal);
                Console.WriteLine("\tMin Leeftijd:" + groep.Minimum);
                Console.WriteLine("\tMax Leeftijd:" + groep.Maximum);
            };
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
