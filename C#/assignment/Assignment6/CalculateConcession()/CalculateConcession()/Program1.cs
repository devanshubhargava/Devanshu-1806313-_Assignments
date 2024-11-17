using System;
using System.Collections.Generic;
using CalculateConcession__;

namespace CalculateConcession__
{
    internal class Program1
    {
        static void Main()
        {
            ConcessionCalculator concessionCalculator = new ConcessionCalculator();
            Console.Write("\nEnter your Age:");

            int age = int.Parse(Console.ReadLine());
            string concessionResult = concessionCalculator.CalculateConcession(age);
            Console.WriteLine(concessionResult);
            Console.ReadLine();



        }
    }
}
