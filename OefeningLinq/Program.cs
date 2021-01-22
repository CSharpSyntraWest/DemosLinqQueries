using System;

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
           //Oefening 2: Maak een Linq query , die het Geslacht en Naam teruggeeft van de
           // de personen die in januari geboren zijn teruggeeft. Geef daarna ook het aantal Personen terug die in januari geboren.
        }
    }
}
