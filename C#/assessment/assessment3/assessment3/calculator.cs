using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment3
{
     class calculator
    {
        delegate int CalculatorDelegate(int a, int b);

        static void Main()
        {
            
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            
            CalculatorDelegate add = (a, b) => a + b;
            CalculatorDelegate subtract = (a, b) => a - b;
            CalculatorDelegate multiply = (a, b) => a * b;

            
            Console.WriteLine($"Addition: {add(num1, num2)}");
            Console.WriteLine($"Subtraction: {subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {multiply(num1, num2)}");

            Console.Read();
        }
    }
}
