using System;

namespace Assignment_2
{
    internal class Program
    {
        static void Swap(ref int a ,ref  int b)
        {
            a += b;
            b = a - b;
            a -= b;
            Console.WriteLine($"After Swapping the number, a = {a}, b = {b}\n\n");


        }

        static void array2_marks()
        {
            Console.WriteLine("Enter the Marks");
            int[] array2 = new int[10];

            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = int.Parse(Console.ReadLine());
            }


            // Total

            int total = 0;
            for (int i = 0; i < array2.Length; i++)
            {
                total += array2[i];
            }

            Console.WriteLine($"\nTotal of marks is {total}");


            // Calculate average
            double average = total / (double)array2.Length;
            Console.WriteLine($"\nAverage of marks is {average}");


            // minimum and maximum marks 
            int min = array2[0];
            int max = array2[0];
            for (int i = 1; i < array2.Length; i++)
            {
                if (array2[i] < min)
                {
                    min = array2[i];
                }
                if (array2[i] > max)
                {
                    max = array2[i];
                }
            }
            Console.WriteLine($"\nMax : {max} , Min : {min}");

            // Ascending and Decending 

            int[] ascending_order = (int[])array2.Clone();
            for (int i = 0; i < ascending_order.Length - 1; i++)
            {
                for (int j = 0; j < ascending_order.Length - i - 1; j++)
                {
                    if (ascending_order[j] > ascending_order[j + 1])
                    {

                        int temp = ascending_order[j];
                        ascending_order[j] = ascending_order[j + 1];
                        ascending_order[j + 1] = temp;
                    }
                }
            }





            int[] descendingOrder = (int[])array2.Clone();
            for (int k = 0; k < descendingOrder.Length - 1; k++)
            {
                for (int l = 0; l < descendingOrder.Length - l - 1; l++)
                {
                    if (descendingOrder[l] < descendingOrder[l + 1])
                    {
                        // Swap elements
                        int temp = descendingOrder[l];
                        descendingOrder[l] = descendingOrder[l + 1];
                        descendingOrder[l + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nMarks in Ascending Order:");
            foreach (var mark in ascending_order)
            {
                Console.Write(mark + " ");
            }

            Console.WriteLine("\nMarks in Descending Order:");
            foreach (var mark in descendingOrder)
            {
                Console.Write(mark + " ");
            }



        }

        static void array1_avg_max_min(int size)
        {
            float avg = 0;
            int[] array = new int[size];
            Console.WriteLine("Enter the Values for Array: ");
            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            foreach(int i in array)
            {
                avg += i;


            }
            avg = avg / array.Length;
            Console.WriteLine("------Average of the array------");
            Console.WriteLine($"\nThe Average of the Array is {avg}");
            int max = array[0];
            int min = array[0];

            for(int i = 1; i < size; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }

                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine("\n------Max and Min Values------\n");
            Console.WriteLine($"The maximum Value is: {max} and the minimum Value is: {min}");




        }

        static void printingline(int num1)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{num1} {num1} {num1} {num1}");
                }

                else
                {
                    Console.WriteLine($"{num1}{num1}{num1}{num1}");
                }
            }
        }
        static void whatdayitis(int day)
            {
            string dayName;

            switch (day)
            {
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                case 7:
                    dayName = "Sunday";
                    break;
                default:
                    dayName = "Invalid day number. Please enter a number between 1 and 7.";
                    break;
            }
            Console.WriteLine($"The Day is {dayName}");


        }
        
        static void Main()
        {

            // 1st. Swapping Two Numbers
            Console.WriteLine("------Swapping 2 Numbers------ \n\n");
            Console.Write("Enter the First Value, a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter the Second Value, b: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Before swapping the number, a = {a}, b = {b}\n");
            Swap(ref a, ref b);
           

            // 2nd. Printing Values in Multiple Line

            Console.WriteLine("------Printing Line------\n\n");
            Console.Write("Enter the Value: ");
            int num1 = int.Parse(Console.ReadLine());
            printingline(num1);

            // 3rd C# Sharp program to read any day number as an integer and display the name of the day as a word

            Console.WriteLine("\n\n------What Day it is------\n\n");
            Console.Write("Enter the Value: ");
            int day = int.Parse(Console.ReadLine());
            whatdayitis(day);

            // Arrays 

            /* 1st a  Program to assign integer values to an array  and then print the following
             

            a.Average value of Array elements 
            */
            Console.WriteLine("\n\n------Average and Maximum, Minimum Value in an array------");
            Console.Write("\n\nThe Size of the array: ");
            int size = int.Parse(Console.ReadLine());
            array1_avg_max_min(size);

            /* a program in C# to accept ten marks and display the following
	           a.	Total
	           b.	Average
	           c.	Minimum marks
	           d.	Maximum marks
	           e.	Display marks in ascending order
	           f.	Display marks in descending order */

            Console.WriteLine("\n\n------Ten Marks Array Solution------");
            array2_marks();
           









            Console.Read();


        }

        
    }
}
