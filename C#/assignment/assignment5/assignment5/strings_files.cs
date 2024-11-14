using System;
using System.IO;

namespace Assignment_5
{
    internal class StringsToFile
    {
        public static void Main()
        {
            Console.WriteLine("-------Files TO Strings------\n\n");
            Console.Write("Enter no of strings:");
            int n = int.Parse(Console.ReadLine());
            string[] strs = new string[n];
            Console.WriteLine($"\nEnter {n} strings to write them to a file");
            for (int i = 0; i < n; i++)
            {
                strs[i] = Console.ReadLine();
            }
            Console.WriteLine("\nWriting the string to a text file");
            string outputFilePath = "StringsToFiles.txt";

            try
            {
                File.WriteAllLines(outputFilePath, strs);
                Console.WriteLine("Pushing File\n\n");
                Console.WriteLine($"File written successfully to: {outputFilePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An Error Occurred: {e.Message}");
            }

            Console.Read();
        }
    }
}