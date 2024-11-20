using System;
using System.IO;

namespace assessment3
{
    class File_extraction
    {
        static void Main()
        {
            Console.WriteLine("------File Data------");
            Console.Write("\n\nWrite the name of the file with (.txt) extension! ");
            string fileName = Console.ReadLine();

            Console.WriteLine("\nPlease enter the text you want to append to the file:");
            string textToAppend = Console.ReadLine();

            
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("\nFile Created! First line added.");
                }
                Console.WriteLine("\nFile does not exist. It has been created with the first line.");
            }

            
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(textToAppend);
            }

            Console.WriteLine("\nText has been appended to the file.");
            Console.Read();
        }
    }
}
