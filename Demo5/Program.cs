using System;
using System.Collections.Generic;
using System.Linq;
namespace Demo5
{
    class Boek
    {
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public double Prijs { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Boek[] boeken = { 
                new Boek{ Titel=  "LINQ in Action", Prijs=53.51},
                new Boek{ Titel = "LINQ for Fun", Prijs=35.51},
                new Boek{ Titel = "Extreme LINQ", Prijs=150.50}
            };
            var resultTitelsMetAction = boeken.Where(b => b.Titel.Contains("aCtion", StringComparison.OrdinalIgnoreCase))
                                                .Select(b => b.Titel);
            //Omzetten van resultTitelsMetAction naar List<string>
            List<string> boekTitelsMetActionLijst = resultTitelsMetAction.ToList();
            boekTitelsMetActionLijst.ForEach(t => Console.WriteLine(t));
            //Anonymous Type voorbeeld
            //var anonymousType = new { Id = 1, Naam = "naam" };
            //Console.WriteLine(anonymousType.Id + ":" + anonymousType.Naam);

            var resultAnonymousTypesMetAction = boeken.Where(b => b.Titel.Contains("aCtion", StringComparison.OrdinalIgnoreCase))
                                            .Select(b =>
                                                new { Title = b.Titel,
                                                      Price = b.Prijs
                                                     });
            foreach (var element in resultAnonymousTypesMetAction)
            {
                Console.WriteLine(element.Title + ":" + element.Price);
            }
            //Zelfde Linq Queries, maar met de Query Expressie syntax:
            var titels =
                from b in boeken
                where b.Titel.Contains("Action", StringComparison.OrdinalIgnoreCase)
                select b.Titel;
            var titelsMetAnonymousTypes =
                    from b in boeken
                    where b.Titel.Contains("Action", StringComparison.OrdinalIgnoreCase)
                    select new{
                                 Title= b.Titel,
                                 Price = b.Prijs
                                };

            foreach (var element in titelsMetAnonymousTypes)
            {
                Console.WriteLine(element.Title + ":" + element.Price);
            }
        }
    }
}
