using System;
using System.Collections.Generic;
using System.Linq;
namespace OefeningLinq
{
    enum Geslacht
    { 
        Man,
        Vrouw,
        X
    }
    class Persoon
    { 
        public string Naam { get; set; }
        public Geslacht Geslacht { get; set; }
        public DateTime GeboorteDatum { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Persoon[] personen = new Persoon[] {
                new Persoon(){ Naam="Jan" , Geslacht = Geslacht.Man,GeboorteDatum = new DateTime(1983,1,1)},
                new Persoon(){ Naam="An" , Geslacht = Geslacht.Vrouw,GeboorteDatum = new DateTime(1983,1,2)},
                new Persoon(){ Naam="Jos" , Geslacht = Geslacht.X,GeboorteDatum = new DateTime(1983,10,1)},
            };
            //Oefening1: Maak een Linq query (zelf syntax kiezen), die alle namen van Personen selecteert die
            // beginnen met de letter 'j' (case-insensitive , zowel hoofd-als kleine letters) 
            //sorteer op Geboortedatum
            var namen = from p in personen
                        where p.Naam.Contains("j", StringComparison.OrdinalIgnoreCase)
                        orderby p.GeboorteDatum
                        select p.Naam;
            List<string> lijstNamen = namen.ToList();
            lijstNamen.ForEach(n => Console.WriteLine(n));
            //Methode notatie:
            var resultPersonenMetJ = personen.Where(p => p.Naam.Contains("j", StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.GeboorteDatum).Select(p => p.Naam);
            //Oefening 2: Maak een Linq query , die het Geslacht en Naam teruggeeft van de
            //de personen die in januari geboren zijn. Geef daarna ook het aantal Personen terug die 
            //in januari geboren.
            var personenGeborenInJan = personen.Where(p => p.GeboorteDatum.Month == 1)
                                                .Select(p => new
                                                            {
                                                                Sex = p.Geslacht,
                                                                Name = p.Naam
                                                            });
            Console.WriteLine("Het aantal personen geboren in Januari: " + personenGeborenInJan.Count());
            foreach (var el in personenGeborenInJan)
            {
                Console.WriteLine(el.Name + ":" + el.Sex);
            }

        }
    }
}
