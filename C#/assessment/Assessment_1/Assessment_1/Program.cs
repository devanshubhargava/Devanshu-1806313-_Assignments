using System;

namespace assessment
{
    internal class Program
    {
        static string Remove_character(string str, int index)
        {

            if (index < 0 || index >= str.Length)
            {
                Console.WriteLine("Index is out of Range, Please Provide Valid Index No.");
                return str;
            }
            else
            {
                return str.Remove(index, 1);
            }
        }

        static string SwapFirstAndLast(string input)
        {

            if (input.Length <= 1)
            {
                return input;
            }


            char first = input[0];
            char last = input[input.Length - 1];


            return last + input.Substring(1, input.Length - 2) + first;
        }

        static int FindLargest(int[] numbers)
        {

            int largest = numbers[0];


            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > largest)
                {
                    largest = numbers[i];
                }
            }

            return largest;
        }

        static int CountLetterOccurrences(string input, char letter)
        {
            int count = 0;


            if (string.IsNullOrEmpty(input))
            {
                return count;
            }


            foreach (char ch in input)
            {

                if (Char.ToLower(ch) == letter)
                {
                    count++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            // Question No. 1
            Console.WriteLine("------Question 1 ------");
            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();

            Console.Write("\nEnter the position of the character to remove (starting from 0): ");
            int position = int.Parse(Console.ReadLine());

            string result = Remove_character(inputString, position);
            Console.WriteLine($"\nResult is: {result}");

            // Question No. 2
            Console.WriteLine("------Question 2------");
            Console.Write("Enter a string: ");
            string input1 = Console.ReadLine();
            string result2 = SwapFirstAndLast(input1);
            Console.WriteLine($"Resulting string: {result2}");

            // Question No. 3
            Console.WriteLine("------Question 3 ------");
            Console.WriteLine("Enter three integers separated by commas: ");
            string input2 = Console.ReadLine();


            string[] parts = input2.Split(',');
            int[] numbers = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                numbers[i] = int.Parse(parts[i].Trim());
            }

            int largest = FindLargest(numbers);
            Console.WriteLine($"The largest number is: {largest}");

            // Question No. 4
            Console.WriteLine("------Question 4 ------");
            Console.Write("Enter a string: ");
            string input3 = Console.ReadLine();

            Console.Write("Enter the letter to count: ");
            char letterToCount = Char.ToLower(Console.ReadLine()[0]);

            int occurrences = CountLetterOccurrences(input3, letterToCount);
            Console.WriteLine($"The letter '{letterToCount}' appears {occurrences} times in the string.");

            Console.Read();
        }
    }
}
