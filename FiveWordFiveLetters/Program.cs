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
            String file = File.ReadAllText(filePath);
            char[] separators = { '\r', '\n' };
            String[] words = file.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> words5 = new List<string>();

            foreach (string word in words)
            {
                if (word.Length == 5)
                {
                    words5.Add(word);
                }
            }

            List<string> words5final = new List<string>();
            foreach (string word in words5)
            {
                bool isUnique = true;
                char[] chars = word.ToCharArray();
                for (int k = 1; k < chars.Length - 1; k++)
                {
                    for (int i = k; i < chars.Length; i++)
                    {
                        if (chars[i] == chars[i - 1])
                        {
                            isUnique = false;
                            break;
                        }
                    }
                }
                if (isUnique)
                {
                    words5final.Add(word);
                }
            }
            foreach (string word in words5final)
            {
                Console.WriteLine(word);
            }

        }

    }

}

