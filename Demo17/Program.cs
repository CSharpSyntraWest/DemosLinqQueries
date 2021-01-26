using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Demo17
{
    class Dier:IComparable<Dier>
    {
        public string Name { get; set; }
        public double Leeftijd { get; set; }

        public int CompareTo([AllowNull] Dier other)
        {
            if (Leeftijd == other.Leeftijd)
                return 0;
            else if (Leeftijd < other.Leeftijd)
                return -1;
            else
                return 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        List<Dier> dieren = new List<Dier>(){
                new Dier { Name="Bobby", Leeftijd =8.3 },
                new Dier { Name="Balou", Leeftijd =4.9 },
                new Dier { Name="Wiske", Leeftijd =1.5 },
                new Dier { Name="Dolly", Leeftijd =4.3 } };


            var queryNotatie = from dier in dieren
                        group dier by Math.Floor(dier.Leeftijd) into groep
                        select new
                        {
                            DierKey = groep.Key,
                            Count = groep.Count(),
                            Min = groep.Min(d => d.Leeftijd),
                            Max = groep.Max(d => d.Leeftijd)
                        };


            var methodNotatie = dieren.GroupBy(dier => Math.Floor(dier.Leeftijd), 
                dier => dier.Leeftijd, 
                (LeeftijdKey, leeftijden) => 
                new { Key = LeeftijdKey, 
                    Count = leeftijden.Count(), 
                    Min = leeftijden.Min(), 
                    Max = leeftijden.Max() });

            foreach (var groep in queryNotatie)
            {
                Console.WriteLine(groep.DierKey + ":");
                Console.WriteLine("\taantal: " + groep.Count);
                Console.WriteLine("\tMin: " + groep.Min);
                Console.WriteLine("\tMax: " + groep.Max);
            }
        }
}
}
