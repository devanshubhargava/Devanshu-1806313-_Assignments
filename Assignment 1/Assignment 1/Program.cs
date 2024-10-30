using System;


namespace Assignment_1
{
    internal class Program
    {
        /// A program to accept two integers and check whether they are equal or not. 
        static void equal_or_not(int first, int second)
        {
            if (first == second)
            {
                Console.WriteLine($"{first} and {second} are equal ");
            }

            else
            {
                Console.WriteLine($"{first} and {second} are not equal");
            }
        }

        /// A program to check whether a given number is positive or negative.  
        static void positive_or_negative(int num)
        {
            if (num > 0)
            {
                Console.WriteLine($"{num} is a positive number");

            }
            else
            {
                Console.WriteLine($"{num} is a negative number");

            }

        }
        // A program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 
        static void calculate(int num1, int num2, char op)
        {
            switch (op)
            {
                case '+':
                    Console.WriteLine($"{num1} {op} {num2} = {num1 + num2}");
                    break;

                case '-':
                    Console.WriteLine($"{num1} {op} {num2} = {num1 - num2}");
                    break;

                case '*':
                    Console.WriteLine($"{num1} {op} {num2} = {num1 * num2}");
                    break;

                case '/':
                    if (num2 != 0)
                    {
                        Console.WriteLine(num1 / num2);
                    }
                    else
                    {
                        Console.WriteLine("Division by 0");
                    }
                    break;






            }


        }
        // A program that prints the multiplication table of a number as input.

        static void table(int number)
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{number} * {i} = {number * i}");
            }


        }
        // A program to compute the sum of two given integers. If two values are the same, return the triple of their sum.
        static void sum(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine($"{(a + b) * 3}");

            }
            else
            {
                Console.WriteLine($"{a} + {b}");
            }
        }



        static void Main(string[] args)
        {
            // 1st Solution

            Console.WriteLine("-------------- 1st------------\n\n");
            Console.WriteLine("Input 2 values to know wheather they are equal or not");
            Console.Write("Input 1st number: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Input 2nd number: ");
            int second = int.Parse(Console.ReadLine());
            equal_or_not(first, second);


            // 2nd Solution 

            Console.WriteLine("-------------- 2nd------------\n\n");
            Console.Write("Enter the no. ");
            int num = int.Parse(Console.ReadLine());
            positive_or_negative(num);


            // 3rd Solution

            Console.WriteLine("-------------- 3rd------------\n\n");
            Console.Write("Input the First Number ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Input Operation: ");
            char op = char.Parse(Console.ReadLine());
            Console.Write("Input Second Number: ");
            int num2 = int.Parse(Console.ReadLine());
            calculate(num1, num2, op);

            // 4th Solution

            Console.WriteLine("-------------- 4th------------\n\n");
            Console.Write("Enter the no. ");
            int number = int.Parse(Console.ReadLine());
            table(number);


            // 5th solution

            Console.WriteLine("-------------- 5th------------\n\n");
            Console.Write("Enter First Value: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Value: ");
            int b = int.Parse(Console.ReadLine());
            sum(a, b);












            Console.ReadLine();

        }
    }
}
