using System;


namespace assessment3
{
    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }

        
        public Box(int length, int breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        
        public Box AddBox(Box other)
        {
            int newLength = this.Length + other.Length;
            int newBreadth = this.Breadth + other.Breadth;
            return new Box(newLength, newBreadth);
        }

        
        public void DisplayBox()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    class Test
    {
        static void Main()
        {
            Console.WriteLine("----Boxes------");
            Console.Write("\n\nEnter the Length and Breadth of Box 1 (separate by space): ");
            string[] input1 = Console.ReadLine().Split(' ');
            int length1 = int.Parse(input1[0]);
            int breadth1 = int.Parse(input1[1]);

            Console.Write("\nEnter the Length and Breadth of Box 2 (separate by space): ");
            string[] input2 = Console.ReadLine().Split(' ');
            int length2 = int.Parse(input2[0]);
            int breadth2 = int.Parse(input2[1]);





            
            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);

            Console.WriteLine("\nBox 1 Details:");
            box1.DisplayBox();

            Console.WriteLine("\nBox 2 Details:");
            box2.DisplayBox();

            
            Box box3 = box1.AddBox(box2);
            Console.WriteLine("\nBox 3 (sum of Box 1 and Box 2) Details:");
            box3.DisplayBox();

            Console.Read();
        }
    }
}
