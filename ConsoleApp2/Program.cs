using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("1:" + RemoveDuplicates("IXYZZI")); // IXYZ
            Console.WriteLine("2:" + MostEfficient("IXYZZI")); // IXYZ
            Console.Read();
        }

        private static string MostEfficient(string word) {
            HashSet<char> uniqueChars = new HashSet<char>(word);
            return new string(uniqueChars.ToArray());
        }

        private static string RemoveDuplicates(string word)
        {
            //verify if string is not blank 
            if (string.IsNullOrWhiteSpace(word))
                throw new Exception("No word work with");

            List<char> processedCharacters = new List<char>();
            List<char> result = new List<char>();

            foreach (char character in word)
            {
                // find if it is in processedCharacters
                var isItProcessed = processedCharacters.Contains(character);

                if (!isItProcessed)
                {
                    result.Add(character);
                    processedCharacters.Add(character);
                }

                //if processed and
                if (isItProcessed)
                {                    
                    processedCharacters.Add(character);
                }
            }
            return string.Concat(result);
        }
    }
}
