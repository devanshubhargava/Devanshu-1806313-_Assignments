using System;

namespace train_reservation_system
{
    public static class AdminManager
    {
        public static void AdminLoginProcess()
        {
            Console.Clear();
            Console.Write("Enter Admin Email: ");
            string email = Console.ReadLine().ToUpper();
            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine().ToUpper();

            var admin = Admin.AdminLogin(email, password);
            if (admin == null)
            {
                Console.WriteLine("Admin not found. Please register.");
            }
            else
            {
                
                Console.WriteLine($"\nWelcome Admin {admin.AdminName}! What would you like to do?");
                ShowAdminOptions(admin.AdminId);
            }
        }

        
        public static void RegisterAdmin()
        {
            Console.Clear();
            Console.Write("Enter Admin Name: ");
            string adminName = Console.ReadLine().ToUpper();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine().ToUpper();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine().ToUpper();
            Admin.Register(adminName, email, password);

            
            Console.Clear();
            Console.WriteLine("Admin registered successfully! Please login.");
        }

        
        private static void ShowAdminOptions(int adminId)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add New Train");
                Console.WriteLine("2. Modify Train");
                Console.WriteLine("3. Delete Train");
                Console.WriteLine("4. View All Active Trains");
                Console.WriteLine("5. Logout");
                Console.Write("\nEnter your choice: ");

                int adminChoice;
                bool validChoice = int.TryParse(Console.ReadLine(), out adminChoice);

                if (!validChoice || adminChoice < 1 || adminChoice > 5)
                {
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    continue; 
                }

                switch (adminChoice)
                {
                    case 1:
                        
                        Console.Clear();
                        Console.Write("Enter Train Number: ");
                        string trainNo = Console.ReadLine().ToUpper();
                        Console.Write("Enter Train Name: ");
                        string trainName = Console.ReadLine().ToUpper();
                        Console.Write("Enter Source Station: ");
                        string source = Console.ReadLine().ToUpper();
                        Console.Write("Enter Destination Station: ");
                        string destination = Console.ReadLine().ToUpper();
                        Console.Write("Enter Total Seats: ");
                        int totalSeats = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Available First Class Seats: ");
                        int availableFirstClassSeats = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Available Second Class Seats: ");
                        int availableSecondClassSeats = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Available Sleeper Class Seats: ");
                        int availableSleeperClassSeats = Convert.ToInt32(Console.ReadLine());

                        
                        Train.AddTrain(trainNo, trainName, source, destination, totalSeats, availableFirstClassSeats, availableSecondClassSeats, availableSleeperClassSeats);
                        break;

                    case 2:
                        
                        Console.Clear();
                        Train.ModifyTrain();
                        break;

                    case 3:
                        
                        Console.Clear();
                        Train.DeleteTrain();
                        break;

                    case 4:
                        
                        Console.Clear();
                        Train.ShowAllTrains();
                        break;

                    case 5:
                        
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
