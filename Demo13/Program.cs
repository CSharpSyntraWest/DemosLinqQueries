using System;
using System.Collections.Generic;
using System.Linq;
namespace Demo13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = from w in words
                              orderby w
                              select w;
            var sortedWordsMethodNotatie = words.OrderBy(w => w).Select(w=>w);
            List<string> wordList = sortedWords.ToList();
            wordList.ForEach(w => Console.WriteLine(w));
        }
    }
}
