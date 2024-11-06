using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal class Strings
    {
        static void DisplayLength()
        {
            Console.WriteLine("------Length of the String------");
            Console.Write("\nEnter a word: ");
            string word = Console.ReadLine();
            Console.WriteLine($"\nThe length of the word is: {word.Length}");
        }

        // 2. Accept a word from the user and display the reverse of it.
        static void DisplayReverse()
        {
            Console.WriteLine("\n\n------Reversing The String------");
            Console.Write("\nEnter a word: ");
            string word = Console.ReadLine();
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversedWord = new string(charArray);
            Console.WriteLine($"\nThe reverse of the word is: {reversedWord}");
        }

        // 3. Accept two words from the user and find out if they are the same.
        static void CompareWords()
        {
            Console.WriteLine("\n\n------Comparing the Words------");
            Console.Write("\nEnter the first word: ");
            string word1 = Console.ReadLine();

            Console.Write("\nEnter the second word: ");
            string word2 = Console.ReadLine();

            if (word1.Equals(word2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nThe words are the same.");
            }
            else
            {
                Console.WriteLine("\nThe words are different.");
            }
        }

        static void Main()
        {
            DisplayLength();
            DisplayReverse();
            CompareWords();

            Console.ReadLine();
        }
    }
}
