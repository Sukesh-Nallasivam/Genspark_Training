using System;
using System.Linq;
namespace Question6
{
   internal class Program
    {
        static int CountVowels(string word)
        {
            int count = 0;
            string vowels = "aeiouAEIOU";
            foreach (char c in word)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
        static void Main()
        {
            Console.WriteLine("Enter words separated by commas:");
            string input = Console.ReadLine();
            string[] words = input.Split(',');
            var vowelCounts = words.ToDictionary(w => w.Trim(), w => CountVowels(w));
            int minCount = vowelCounts.Min(w => w.Value);
            var leastRepeatingWords = vowelCounts.Where(w => w.Value == minCount).Select(w => w.Key);
            Console.WriteLine("Count of least repeating vowels: " + minCount);
            Console.WriteLine("Words with least repeating vowels:");
            foreach (var word in leastRepeatingWords)
            {
                Console.WriteLine(word);
            }
        }

    }

}
