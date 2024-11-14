﻿using System;
using System.IO;

namespace Assignment_5
{
    internal class CountLines
    {
        public static void Main()
        {
            Console.WriteLine("------Counting Lines In the File------\n\n");
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    Console.WriteLine($"\nNo. of lines in file: {lines.Length}");
                }
                else
                {
                    Console.WriteLine($"{filePath} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}