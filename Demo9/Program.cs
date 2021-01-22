using System;
using System.Linq;

namespace Demo9
{
    class Program
    {
        static void Main(string[] args)
        {
            string tekst = "Aantal 12 niet-letters 5 in deze 1.0 tekst: 8";
            int aantalNietAlfChars =
                tekst.Where(c => !Char.IsLetter(c))
                     .Count();
            Console.WriteLine("Aantal niet-alf karakters=" + aantalNietAlfChars);
            //Zelfde Linq query met Query Expression syntax:
            var aantalNietAlfChars2 =
                (from c in tekst
                 where !Char.IsLetter(c)
                 select c).Count();
            //Oefening: Geef eens het aantal Digits in de tekst via een linq query
            var aantalDigits =
                   tekst.Where(c => Char.IsDigit(c))
                   .Count();
            var aantalDigits2 =
                (from c in tekst
                 where Char.IsDigit(c)
                 select c).Count();
            Console.WriteLine("Aantal digit-karakters=" + aantalDigits2);

        }
    }
}
