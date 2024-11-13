using System;
using System.Collections.Generic;


namespace Assessment2
{
    // Question 1
    public abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public abstract bool IsPassed(double grade);
    }
    public class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    public class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    // Question 2
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Product(int productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Price: {Price:C}";
        }
    }
    public class Program
    {
        
        public static void TestStudentClasses()
        {
            Console.Write("Enter name for Undergraduate student:");
            string undergradName = Console.ReadLine();

            Console.Write("Enter Student ID for Undergraduate student:");
            int undergradId = int.Parse(Console.ReadLine());

            Console.Write("Enter Grade for Undergraduate student:");
            double undergradGrade = double.Parse(Console.ReadLine());

            Student undergrad = new Undergraduate { Name = undergradName, StudentId = undergradId, Grade = undergradGrade };

            if(undergrad.IsPassed(undergrad.Grade))
            {
                Console.WriteLine($"{undergrad.Name} (Undergrad) is passed");

            }
            else
            {
                Console.WriteLine($"{undergrad.Name} (Undergrad) is Failed");
            }

            Console.WriteLine("\nEnter name for Graduate student:");
            string gradName = Console.ReadLine();

            Console.WriteLine("Enter Student ID for Graduate student:");
            int gradId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Grade for Graduate student:");
            double gradGrade = double.Parse(Console.ReadLine());

            Student grad = new Graduate { Name = gradName, StudentId = gradId, Grade = gradGrade };
            if (grad.IsPassed(grad.Grade))
            {
                Console.WriteLine($"\n{grad.Name} (Graduate) is passed");

            }

            else
            {
                Console.WriteLine($"\n{grad.Name} (Graduate) is Failed");
            }
        }
        
        public static void TestProductSorting()
        {
            List<Product> products = new List<Product>();
            Console.WriteLine("Enter details for 10 products:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Product {i} - Enter Product ID:");
                int productId = int.Parse(Console.ReadLine());

                Console.WriteLine($"Product {i} - Enter Product Name:");
                string productName = Console.ReadLine();

                Console.WriteLine($"Product {i} - Enter Product Price:");
                double price = double.Parse(Console.ReadLine());

                products.Add(new Product(productId, productName, price));
            }
            
            for (int i = 0; i < products.Count - 1; i++)
            {
                for (int j = 0; j < products.Count - i - 1; j++)
                {
                    if (products[j].Price > products[j + 1].Price)
                    {
                        
                        var temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("\nProducts sorted by price:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        // Question 3
        public static void CheckPositive(int number)
        {
            if (number < 0)
                throw new ArgumentException("Number cannot be negative.");
            Console.WriteLine($"The number {number} is positive.");
        }
        
        public static void TestExceptionHandling()
        {
            Console.WriteLine("\nEnter a number to check if it is positive:");
            try
            {
                int number = int.Parse(Console.ReadLine());
                CheckPositive(number);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("------Question No. 1------\n\n");
            TestStudentClasses();

            Console.WriteLine("\n------Question No. 2------\n\n");
            TestProductSorting();

            Console.WriteLine("\n------Question No. 3------\n\n");
            TestExceptionHandling();

            Console.Read();
        }
    }
}