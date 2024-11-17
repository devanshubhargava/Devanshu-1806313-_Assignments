using System;
using System.Collections.Generic;

class Program
{
    // Task 1
    static void numberwithsquares()
    {
        Console.WriteLine("------Numbers WITH Squares------");
        Console.WriteLine("\n\nEnter a list of numbers separated by spaces:");
        var input = Console.ReadLine();
        var numbers = input.Split(' ');
        List<string> result = new List<string>();

        foreach (var num in numbers)
        {

            if (int.TryParse(num , out int number)) 
            {
                int square = number * number;
                if (square > 20)
                {
                    result.Add($"{number} - {square}");
                }
            }

            else
            {
                Console.WriteLine($"\n{num} is not a valid number.");
            }
        }

        if (result.Count == 0)
        {
            Console.WriteLine("\nNo numbers found with square greater than 20.");
        }
        else
        {
            Console.WriteLine("\nNumbers with square greater than 20:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    // Task 2
    static void Words()
    {
        Console.WriteLine("\n\n------Word starting from a and ending with m------");
        Console.WriteLine("\n\nEnter words separated by spaces:");
        var words = Console.ReadLine().Split(' ');
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            
            if (word[0] == 'a' && word[word.Length - 1] == 'm')
            {
                result.Add(word);
            }
        }

        if(result.Count == 0)
        {
            Console.WriteLine("\nThere is no Word starting from a and ending with m");
        }

        
        
        
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
        
    }

    // Task 3
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }

        public override string ToString()
        {
            return $"EmpId: {EmpId}, Name: {EmpName}, City: {EmpCity}, Salary: {EmpSalary}";
        }
    }

    static void Employee_information()
    {
        
        var employees = new List<Employee>();

        Console.WriteLine("\n\n------Employee Information------");
        Console.WriteLine("\n\nHow many employees do you want to enter?");
        int numEmployees = int.Parse(Console.ReadLine());
        

        for (int i = 0; i < numEmployees; i++)
        {
            Console.WriteLine($"\nEnter details for employee {i + 1}:");

            
            Console.Write("Enter Employee ID: ");
            int empId = int.Parse(Console.ReadLine());

            
            Console.Write("Enter Employee Name: ");
            string empName = Console.ReadLine();

            
            Console.Write("Enter Employee City: ");
            string empCity = Console.ReadLine();

            
            Console.Write("Enter Employee Salary: ");
            double empSalary = double.Parse(Console.ReadLine());


            
            employees.Add(new Employee { EmpId = empId, EmpName = empName, EmpCity = empCity, EmpSalary = empSalary });
        }

        
        Console.WriteLine("\nAll Employees:");
        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }

        
        Console.WriteLine("\nEmployees with salary greater than 45000:");
        foreach (var emp in employees)
        {
            if (emp.EmpSalary > 45000)
            {
                Console.WriteLine(emp);
            }
        }

        
        Console.WriteLine("\nEmployees from Bangalore:");
        foreach (var emp in employees)
        {
            
            if (emp.EmpCity.ToLower() == "bangalore")
            {
                Console.WriteLine(emp);
            }
        }

        
        Console.WriteLine("\nEmployees sorted by name:");
        employees.Sort((e1, e2) => e1.EmpName.CompareTo(e2.EmpName));
        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }
    }

    
    static void Main()
    {
        
        numberwithsquares();

        Words();
        
        Employee_information();

        
        Console.Read();
    }
}
