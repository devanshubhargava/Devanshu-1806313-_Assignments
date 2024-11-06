using System;
namespace Assignment3

{

    internal class Student

    {

        private string rollNo;

        private string name;

        private string studentClass;

        private string semester;

        private string branch;

        private int[] marks = new int[5];

        public Student(string rollNo, string name, string studentClass, string semester, string branch)

        {

            this.rollNo = rollNo;

            this.name = name;

            this.studentClass = studentClass;

            this.semester = semester;

            this.branch = branch;

        }

        public void GetMarks()

        {

            Console.WriteLine("\nEnter marks for 5 subjects (out of 100 each):");

            for (int i = 0; i < marks.Length; i++)

            {

                Console.Write($"Subject {i + 1}: ");

                marks[i] = int.Parse(Console.ReadLine());

            }

        }

        public void DisplayResult()

        {

            bool failedInAnySubject = false;

            int totalMarks = 0;

            for (int i = 0; i < marks.Length; i++)

            {

                totalMarks += marks[i];

                if (marks[i] < 35)

                {

                    failedInAnySubject = true;

                }

            }

            double average = totalMarks / (double)marks.Length;

            if (failedInAnySubject || average < 50)

            {

                Console.WriteLine("\nResult: Failed");

            }

            else

            {

                Console.WriteLine("\nResult: Passed");

            }

            Console.WriteLine($"\nAverage Marks: {average:F2}");

        }

        public void DisplayData()

        {

            Console.WriteLine("\nStudent Details:");

            Console.WriteLine($"Roll No: {rollNo}");

            Console.WriteLine($"Name: {name}");

            Console.WriteLine($"Class: {studentClass}");

            Console.WriteLine($"Semester: {semester}");

            Console.WriteLine($"Branch: {branch}");

        }

        static void Main(string[] args)

        {
            Console.Write("------Student Details------");

            Console.Write("\n\nEnter Roll No: ");

            string rollNo = Console.ReadLine();

            Console.Write("Enter Name: ");

            string name = Console.ReadLine();

            Console.Write("Enter Class: ");

            string studentClass = Console.ReadLine();

            Console.Write("Enter Semester: ");

            string semester = Console.ReadLine();

            Console.Write("Enter Branch: ");

            string branch = Console.ReadLine();

            Student student = new Student(rollNo, name, studentClass, semester, branch);

            student.DisplayData();

            student.GetMarks();

            student.DisplayResult();

            Console.ReadLine();

        }

    }

}

