using System;
using System.Linq;
namespace Demo4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Trump News en fake news ...";

            string zoekTerm = "news";
            string[] woorden = text.Split(
              new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                StringSplitOptions.RemoveEmptyEntries);

            // Gebruik ToLower() om  zowel "news" en bv "News" terug te krijgen
            var zoekQuery =
                          from woord in woorden
                          where woord.ToLower() == zoekTerm.ToLower()
                          select woord;
            int aantalWoorden = zoekQuery.Count();
            //Iets kortere manier:
            //int aantalWoorden =
            //           (from woord in woorden
            //           where woord.ToLower() == zoekTerm.ToLower()
            //           select woord).Count();
            //Zelfde, maar met LINQ Method notatie:
            int aantalWoordenLambda = woorden.Where(woord => woord.ToLower() ==
                                    zoekTerm.ToLower()).Count();

            Console.WriteLine("Aantal keer dat zoekTerm voorkomt:" + aantalWoorden);

        }
    }
}
