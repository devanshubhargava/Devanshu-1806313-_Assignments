using System;

namespace Assignment_4
{

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Insufficient balance to complete the withdrawal.");
            }
            balance -= amount;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    public class Scholarship
    {
        public decimal Merit(int marks, decimal fees)
        {
            decimal scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = fees * 0.20m;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = fees * 0.30m;
            }
            else if (marks > 90)
            {
                scholarshipAmount = fees * 0.50m;
            }
            else
            {
                Console.WriteLine("No scholarship awarded for marks less than 70.");
            }

            return scholarshipAmount;
        }
    }

    public class Doctor
    {
        private string regnNo;
        private string name;
        private decimal feesCharged;

        public string RegnNo
        {
            get { return regnNo; }
            set { regnNo = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal FeesCharged
        {
            get { return feesCharged; }
            set { feesCharged = value; }
        }

        public void DisplayDoctorInfo()
        {
            Console.WriteLine($"Doctor Name: {name}, Registration No: {regnNo}, Fees Charged: {feesCharged}");
        }
    }

    public class Book
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Book(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Book[] books = new Book[5];

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Length)
                    return books[index];
                else
                    throw new IndexOutOfRangeException("Index out of range.");
            }
            set
            {
                if (index >= 0 && index < books.Length)
                    books[index] = value;
                else
                    throw new IndexOutOfRangeException("Index out of range.");
            }
        }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public float Salary { get; set; }

        public Employee(int empId, string empName, float salary)
        {
            EmpId = empId;
            EmpName = empName;
            Salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"Employee ID: {EmpId}, Name: {EmpName}, Salary: {Salary}");
        }
    }

    public class ParttimeEmployee : Employee
    {
        public float Wages { get; set; }

        public ParttimeEmployee(int empId, string empName, float salary, float wages) : base(empId, empName, salary)
        {
            Wages = wages;
        }

        public new void Display()
        {
            base.Display();
            Console.WriteLine($"Wages: {Wages}");
        }
    }

    public interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }
        void ShowDetails();
    }

    public class Dayscholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public Dayscholar(int studentId, string name)
        {
            StudentId = studentId;
            Name = name;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"DayScholar Student ID: {StudentId}, Name: {Name}");
        }
    }

    public class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public Resident(int studentId, string name)
        {
            StudentId = studentId;
            Name = name;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident Student ID: {StudentId}, Name: {Name}");
        }
    }

    class Program
    {
        static void Main()
        {
            // 1. Bank Account Transaction
            Console.WriteLine("------Bank Account Transaction------");
            try
            {
                Console.WriteLine("\n\nEnter initial balance for the Bank Account:");
                decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
                BankAccount account = new BankAccount(initialBalance);

                Console.WriteLine("Enter amount to deposit:");
                decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                account.Deposit(depositAmount);
                Console.WriteLine("Balance after deposit: " + account.GetBalance());

                Console.WriteLine("Enter amount to withdraw:");
                decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                account.Withdraw(withdrawAmount);
                Console.WriteLine("Balance after withdrawal: " + account.GetBalance());

                Console.WriteLine("Enter amount to withdraw again:");
                withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                account.Withdraw(withdrawAmount);
                Console.WriteLine("Balance after withdrawal: " + account.GetBalance());
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

            // 2. Scholarship Calculation
            Console.WriteLine("\n\n------Scholarship Calculation------");
            Console.WriteLine("\n\nEnter student marks and fees for scholarship calculation:");
            Console.Write("Enter marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter fees: ");
            decimal fees = Convert.ToDecimal(Console.ReadLine());

            Scholarship scholarship = new Scholarship();
            decimal scholarshipAmount = scholarship.Merit(marks, fees);
            Console.WriteLine($"Scholarship Amount: {scholarshipAmount}");

            // 3.1 Doctor Information
            Console.WriteLine("\n\n------Doctor Information------");
            Console.WriteLine("\nEnter Doctor details:");
            Console.Write("Enter Registration No: ");
            string regnNo = Console.ReadLine();
            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine();
            Console.Write("Enter Fees Charged: ");
            decimal feesCharged = Convert.ToDecimal(Console.ReadLine());

            Doctor doctor = new Doctor
            {
                RegnNo = regnNo,
                Name = doctorName,
                FeesCharged = feesCharged
            };
            doctor.DisplayDoctorInfo();

            // 3.2 Book Information
            Console.WriteLine("\n\n------Book Information------");
            BookShelf shelf = new BookShelf();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nEnter details for Book {i + 1}:");
                Console.Write("Enter Book Name: ");
                string bookName = Console.ReadLine();
                Console.Write("Enter Author Name: ");
                string authorName = Console.ReadLine();
                shelf[i] = new Book(bookName, authorName);
            }

            Console.WriteLine("\nBook Shelf Details:");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }

            // 4. Employee and ParttimeEmployee Information

            Console.WriteLine("\n\n------Employee and ParttimeEmployee Information------");
            Console.WriteLine("\n\nEnter Employee details:");
            Console.Write("Enter Employee ID: ");
            int empId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name: ");
            string empName = Console.ReadLine();
            Console.Write("Enter Salary: ");
            float salary = float.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Part-time Employee Wages:");
            Console.Write("Enter Wages: ");
            float wages = float.Parse(Console.ReadLine());

            ParttimeEmployee partTimeEmployee = new ParttimeEmployee(empId, empName, salary, wages);
            partTimeEmployee.Display();

            // 5. IStudent Interface and Implementation
            Console.WriteLine("\n\n------IStudent Interface and Implementation------");
            Console.WriteLine("\nEnter details for DayScholar Student:");
            Console.Write("Enter Student ID: ");
            int dayScholarId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            string dayScholarName = Console.ReadLine();
            IStudent dayScholar = new Dayscholar(dayScholarId, dayScholarName);
            dayScholar.ShowDetails();

            Console.WriteLine("\nEnter details for Resident Student:");
            Console.Write("Enter Student ID: ");
            int residentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            string residentName = Console.ReadLine();
            IStudent resident = new Resident(residentId, residentName);
            resident.ShowDetails();

            Console.Read();
        }
    }

}
