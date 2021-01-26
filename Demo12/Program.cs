using System;
using System.Collections.Generic;
using System.Linq;
namespace Demo12
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };
            var gesoorteerdeDoubles = from d in doubles
                                      orderby d descending
                                      select d;
            var gesoorteerdeDoublesMethodNotatie = doubles.OrderByDescending(d => d);
            double[] doublesArray = gesoorteerdeDoubles.ToArray();

            List<double> doubleList = gesoorteerdeDoubles.ToList();
            doubleList.ForEach(d => Console.WriteLine(d));
            //hetzelfde resultaat als vorige lijn is:
            //foreach (double d in doubleList)
            //{
            //    Console.WriteLine(d);
            //}
        }
}
    }
