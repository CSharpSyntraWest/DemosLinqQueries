using System;
using System.Linq;
namespace Demo10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aggregation methoden:
            //Count(), Sum(),Average(), Max() en Min()

            double[] temperaturen = { 28.0, 19.5, 32.3, 33.6, 26.5, 29.7 };
            int aantalTempBoven30 = temperaturen.Where(t => t > 30).Count();
            int aantalTempBoven30b = temperaturen.Count(t=>t>30);
            //Query Expr notatie:
            int aantalTempBoven30c = (from t in temperaturen
                                      where t > 30
                                      select t).Count();

            int aantalTempBoven30d = (from t in temperaturen
                                      select t).Count(t => t > 30);

            //De som van alle temperaturen hoger dan 26:
            double som = temperaturen.Where(t => t>26).Sum();
            double gemiddelde = temperaturen.Average();
            double maxTemp = temperaturen.Max();
            double minTemp = temperaturen.Min();
        }
    }
}
