using System;
using System.IO;
using System.Linq;

namespace FiveWordFiveLetters

        {

    internal class Program
    {
        static void Main()
        {
            string filePath = "words_alpha.txt";
            string[] words = File.ReadAllLines(filePath).Where(x => x.Length == 5 && x.Distinct().Count() == 5).ToArray();
            Console.WriteLine($"{words.Length} words.");

            var dictionary = new Dictionary<int, string>();
            foreach (string word in words)
            {
                var bit = 0;
                foreach (char c in word)
                {
                    bit |= 1 << (c - 'a');
                }
                if (dictionary.ContainsKey(bit)) continue;
                dictionary.Add(bit, word);
            }

            Console.WriteLine($"{dictionary.Count} unique words.");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            RecursiveFindSolution(dictionary, dictionary.Keys.ToArray(), 5, dictionary.Count()-1);
            watch.Stop();
            Console.WriteLine($"find in {watch.ElapsedMilliseconds} ms.");
        }

        static void RecursiveFindSolution(Dictionary<int, string> dictionary, int[] words, int wordLength, int index, string solution = "", int mask = 0)
        {
            if (solution.Where(c => c == ' ').Count() == 4)
            {
                Console.WriteLine(solution);
                return;
            }
            if (mask == 0)
            {
                Parallel.For(0, index, x =>
                {
                    RecursiveFindSolution(dictionary, words, wordLength, x - 1, dictionary[words[x]], words[x]);
                });
            }
            else
            {
                for (int i = index; i >= 0; i--)
                {
                    if ((mask & words[i]) != 0) continue;
                    RecursiveFindSolution(dictionary, words, wordLength, i - 1, string.Concat(solution, " ", dictionary[words[i]]).TrimStart(), mask | words[i]);
                }
            }
        }
    }
}
