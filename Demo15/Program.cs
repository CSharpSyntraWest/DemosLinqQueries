using System;
using System.Linq;
namespace Demo15
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] objecten = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };
            var doubles = objecten.OfType<string>();
            Console.WriteLine("alle doubles uit lijst:");
            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }

        }
    }
}
