using System;
using System.Linq;
namespace Demo14
{
    class Program
    {
        static void Main(string[] args)
        {
            var scores = new[] {
                        new {Id =1, Name = "An", Score = 50},
                        new {Id= 2, Name = "Piet"  , Score = 40},
                        new {Id=3, Name = "Jos", Score = 45}};

            var scoresDict =
            scores.ToDictionary(sr => sr.Id);

            Console.WriteLine("Score van Piet: {0}", scoresDict[2].Score);

        }
    }
}
