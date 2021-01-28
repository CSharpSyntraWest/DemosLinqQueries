using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoSetOperaties
{
    class Program
    {
        static void Main(string[] args)
        {
           // DemoUnion();
           // DemoIntersect();
             DemoExcept();
           // DemoDistinct();
        }

        private static void DemoDistinct()
        {
            IList<string> fruit = new List<string>() { "appel", "citroen", "banaan", "appel", "banaan" };

            IList<int> getallen = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distinctFruit = fruit.Distinct();

            foreach (var str in distinctFruit)
                Console.WriteLine(str);

            var distinctgetallen = getallen.Distinct();

            foreach (var i in distinctgetallen)
                Console.WriteLine(i);
        }

        private static void DemoExcept()
        {
            IList<int> getallen1 = new List<int>() { 1, 2, 3, 4 };
            IList<int> getallen2 = new List<int>() { 2, 3, 4, 5 };

            var resultaat = getallen1.Intersect(getallen2);
            Console.WriteLine("Getallen die in de 1ste lijst voorkomen én niet in de 2de");
            foreach (int getal in resultaat)
                Console.WriteLine(getal);
        }

        private static void DemoIntersect()
        {
            IList<int> getallen1 = new List<int>() { 1, 2, 3, 4 };
            IList<int> getallen2 = new List<int>() { 2, 3, 4, 5 };

            var resultaat = getallen1.Intersect(getallen2);

            Console.WriteLine("De gemeenschappelijke elementen uit de 2 lijsten getallen:");
            foreach (int getal in resultaat)
                Console.Write(getal + " ");
        }

        private static void DemoUnion()
        {
            IList<int> getallen1 = new List<int>() { 1, 2, 3, 4 };
            IList<int> getallen2 = new List<int>() { 2, 3, 4, 5 };

            var resultaat = getallen1.Union(getallen2);
            Console.WriteLine("De unieke elementen uit de 2 lijsten getallen:");
            foreach (int getal in resultaat)
                Console.Write(getal + " ");
        }
    }
}
