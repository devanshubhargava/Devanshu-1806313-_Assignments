using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7
{
    
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        
        public Employee(int emp_id, string first_name, string last_name, string title, DateTime dob, DateTime doj, string city)
        {
            EmployeeID = emp_id;
            FirstName = first_name;
            LastName = last_name;
            Title = title;
            DOB = dob;
            DOJ = doj;
            City = city;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the list of employees

            List<Employee> empList = new List<Employee>
            {
                new Employee(1001, "Malcolm", "Daruwalla", "Manager", new DateTime(1984, 11, 16), new DateTime(2011, 6, 8), "Mumbai"),
                new Employee(1002, "Asdin", "Dhalla", "AsstManager", new DateTime(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai"),
                new Employee(1003, "Madhavi", "Oza", "Consultant", new DateTime(1987, 11, 14), new DateTime(2015, 4, 12), "Pune"),
                new Employee(1004, "Saba", "Shaikh", "SE", new DateTime(1990, 6, 3), new DateTime(2016, 2, 2), "Pune"),
                new Employee(1005, "Nazia", "Shaikh", "SE", new DateTime(1991, 3, 8), new DateTime(2016, 2, 2), "Mumbai"),
                new Employee(1006, "Amit", "Pathak", "Consultant", new DateTime(1989, 11, 7), new DateTime(2014, 8, 8), "Chennai"),
                new Employee(1007, "Vijay", "Natrajan", "Consultant", new DateTime(1989, 12, 2), new DateTime(2015, 6, 1), "Mumbai"),
                new Employee(1008, "Rahul", "Dubey", "Associate", new DateTime(1993, 11, 11), new DateTime(2014, 11, 6), "Chennai"),
                new Employee(1009, "Suresh", "Mistry", "Associate", new DateTime(1992, 8, 12), new DateTime(2014, 12, 3), "Chennai"),
                new Employee(1010, "Sumit", "Shah", "Manager", new DateTime(1991, 4, 12), new DateTime(2016, 1, 2), "Pune")
            };

            // 1. Display a list of all employees who joined before 1/1/2015

            var employeesJoinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)).ToList();
            Console.WriteLine("Employees who joined before 1/1/2015:\n");
            foreach (var emp in employeesJoinedBefore2015)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} joined on {emp.DOJ.ToShortDateString()}");
            }
            Console.WriteLine();

            // 2. Display a list of all employees whose date of birth is after 1/1/1990

            var employee_born_after_1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1)).ToList();
            Console.WriteLine("Employees whose date of birth is after 1/1/1990:\n");
            foreach (var emp in employee_born_after_1990)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}, born on {emp.DOB.ToShortDateString()}");
            }
            Console.WriteLine();

            // 3. Display a list of all employees whose designation is Consultant or Associate

            var consultant_and_associate = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate").ToList();
            Console.WriteLine("Employees with designation Consultant or Associate:\n");
            foreach (var emp in consultant_and_associate)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}, Title: {emp.Title}");
            }
            Console.WriteLine();

            // 4. Display total number of employees

            int total_no_employee = empList.Count;
            Console.WriteLine($"Total number of employees: {total_no_employee}");
            Console.WriteLine();

            // 5. Display total number of employees belonging to Chennai

            int chennai_employee = empList.Count(e => e.City == "Chennai");
            Console.WriteLine($"Total number of employees in Chennai: {chennai_employee}");
            Console.WriteLine();

            // 6. Display the highest employee ID from the list

            int highest_employee = empList.Max(e => e.EmployeeID);
            Console.WriteLine($"Highest Employee ID: {highest_employee}");
            Console.WriteLine();

            // 7. Display total number of employees who joined after 1/1/2015

            int employee_after_2015 = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"Total number of employees who joined after 1/1/2015: {employee_after_2015}");
            Console.WriteLine();

            // 8. Display total number of employees whose designation is not Associate

            int employee_not_associate = empList.Count(e => e.Title != "Associate");
            Console.WriteLine($"Total number of employees whose designation is not Associate: {employee_not_associate}");
            Console.WriteLine();

            // 9. Display total number of employees based on City

            var employee_city = empList.GroupBy(e => e.City)
                                         .Select(g => new { City = g.Key, Count = g.Count() })
                                         .ToList();
            Console.WriteLine("Total number of employees based on City:");
            foreach (var group in employee_city)
            {
                Console.WriteLine($"City: {group.City}, Employees: {group.Count}");
            }
            Console.WriteLine();

            // 10. Display total number of employees based on City and Title

            var employee_city_title = empList.GroupBy(e => new { e.City, e.Title })
                                                 .Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() })
                                                 .ToList();
            Console.WriteLine("Total number of employees based on City and Title:");
            foreach (var group in employee_city_title)
            {
                Console.WriteLine($"City: {group.City}, Title: {group.Title}, Employees: {group.Count}");
            }
            Console.WriteLine();

            // 11. Display total number of employees who is youngest in the list

            var youngest = empList.Max(e => e.DOB);
            var youngest_employee = empList.Where(e => e.DOB == youngest).ToList();
            Console.WriteLine("Youngest employee(s):");
            foreach (var emp in youngest_employee)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}, Born on: {emp.DOB.ToShortDateString()}");
            }

            Console.ReadLine(); 
        }
    }
}
