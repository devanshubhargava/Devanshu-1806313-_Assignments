using System;
using System.Collections.Generic;
using System.Linq;


namespace Assessment4
{
    class Employee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        
        public string Location { get; set; }
        public Employee(int empId, string firstName, string lastName, string title, string location)
        {
            EmpId = empId;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Location = location;
        }
        public override string ToString()
        {
            return $"EmpId: {EmpId}, FirstName: {FirstName}, LastName: {LastName}, Title: {Title},Location: {Location}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Employee> empList = new List<Employee>
            {
               new Employee(1001, "Malcolm", "Daruwalla", "Manager","Mumbai"),
               new Employee(1002, "Asdin", "Dhalla", "AsstManager","Mumbai"),
               new Employee(1003, "Madhavi", "Oza", "Consultant","Pune"),
               new Employee(1004, "Saba", "Shaikh", "SE", "Pune"),
               new Employee(1005, "Nazia", "Shaikh", "SE", "Mumbai"),
               new Employee(1006, "Amit", "Pathak", "Consultant","Chennai"),
               new Employee(1007, "Vijay", "Natrajan", "Consultant","Mumbai"),
               new Employee(1008, "Rahul", "Dubey", "Associate", "Chennai"),
               new Employee(1009, "Suresh", "Mistry", "Associate","Chennai"),
               new Employee(1010, "Sumit", "Shah", "Manager", "Pune")
             };


            // a. Display details of all employees

            Console.WriteLine("------All Employees:------\n\n");
            var allEmployees = empList.Select(emp => emp);
            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp);
            }

            // b. Display details of all employees whose location is not Mumbai

            Console.WriteLine("\n------Employees whose location is not Mumbai:------\n\n");
            var nonMumbaiEmployees = empList.Where(emp => emp.Location != "Mumbai");
            foreach (var emp in nonMumbaiEmployees)
            {
                Console.WriteLine(emp);
            }
            // c. Display details of all employees whose title is AsstManager

            Console.WriteLine("\n------Employees whose title is AsstManager:------\n\n");
            var asstManagerEmployees = empList.Where(emp => emp.Title == "AsstManager");
            foreach (var emp in asstManagerEmployees)
            {
                Console.WriteLine(emp);
            }
            // d. Display details of all employees whose Last Name starts with S

            Console.WriteLine("\n------Employees whose Last Name starts with S:------\n\n");
            var lastNameStartsWithS = empList.Where(emp => emp.LastName.StartsWith("S"));
            foreach (var emp in lastNameStartsWithS)
            {
                Console.WriteLine(emp);
            }

            Console.Read();
        }
    }
}
