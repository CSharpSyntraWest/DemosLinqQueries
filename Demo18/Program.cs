using System;
using System.Linq;
namespace Demo18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] getallen = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var getallenGroepen = from getal in getallen
                                  group getal by getal % 5 into groep
                                  select new
                                  {
                                      RestBijDeling = groep.Key,
                                      Getallen = groep
                                  };   //anonymous type
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
