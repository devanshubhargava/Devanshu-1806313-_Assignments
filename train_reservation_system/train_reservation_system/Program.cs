using System;

namespace train_reservation_system
{
    public class Program
    {
        public static string connectionString = "Server=ICS-LT-1F6XV44\\SQLEXPRESS;Database=Train_Reservation_DataBase;Integrated Security=True";

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n----------------------Hello! Welcome to Train Reservation System!-----------------------------\n\n");
                Console.WriteLine("Please Choose One of the options below:-\n");
                Console.WriteLine("Press '1' for User");
                Console.WriteLine("Press '2' for Admin");

                int choice;
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);
                if (!validChoice || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("\nInvalid choice. Please enter '1' for User or '2' for Admin.\n");
                    continue;
                }

                if (choice == 1)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("---------------Welcome Aboard! Please choose an Option--------------------");
                        Console.WriteLine("\n1. Login as User");
                        Console.WriteLine("2. Register as User");
                        Console.WriteLine("3. Exit");
                        Console.Write("\nEnter Your Choice:- ");

                        int choice_2;
                        bool validChoice2 = int.TryParse(Console.ReadLine(), out choice_2);
                        if (!validChoice2 || (choice_2 < 1 || choice_2 > 3))
                        {
                            Console.WriteLine("\nInvalid choice. Please try again.\n");
                            continue; 
                        }

                        if (choice_2 == 1)
                        {
                            Console.Clear();
                            UserManager.UserLoginProcess();
                            break; 
                        }
                        else if (choice_2 == 2)
                        {
                            Console.Clear();
                            UserManager.RegisterUser();
                            break; 
                        }
                        else if (choice_2 == 3)
                        {
                            break; 
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("-------------------Welcome Aboard! Please choose an Option--------------------");
                        Console.WriteLine("\n1. Login as Admin");
                        Console.WriteLine("2. Register as Admin");
                        Console.WriteLine("3. Exit");
                        Console.Write("\nEnter Your Choice:- ");

                        int choice_2;
                        bool validChoice2 = int.TryParse(Console.ReadLine(), out choice_2);
                        if (!validChoice2 || (choice_2 < 1 || choice_2 > 3))
                        {
                            Console.WriteLine("\nInvalid choice. Please try again.\n");
                            continue;
                        }

                        if (choice_2 == 1)
                        {
                            AdminManager.AdminLoginProcess();
                            break;
                        }
                        else if (choice_2 == 2)
                        {
                            AdminManager.RegisterAdmin();
                            break;
                        }
                        else if (choice_2 == 3)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
