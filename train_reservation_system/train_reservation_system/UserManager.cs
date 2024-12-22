using System;

namespace train_reservation_system
{
    public static class UserManager
    {
        public static void UserLoginProcess()
        {
            Console.Clear();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine().ToUpper();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine().ToUpper();

            var user = User.UserLogin(email, password);
            if (user == null)
            {
                Console.WriteLine("\nUser not found. Please register.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\nWelcome {user.UserName}! What would you like to do?\n");
                ShowUserOptions(user.UserId);
            }
        }

        public static void RegisterUser()
        {
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine().ToUpper();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine().ToUpper();
            User.Register(userName, email, password);

            Console.Clear();
            Console.WriteLine("User registered successfully! Please login.");
        }

        private static void ShowUserOptions(int userId)
        {
            while (true)
            {
                Console.WriteLine("\n1. View Available Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. Show all Booked/Cancelled Tickets");
                Console.WriteLine("5. Logout");
                Console.Write("\nEnter your choice: ");

                int userChoice;
                bool validChoice = int.TryParse(Console.ReadLine(), out userChoice);

                if (!validChoice || userChoice < 1 || userChoice > 5)
                {
                    Console.WriteLine("\nInvalid choice. Please try again.\n");
                    continue;
                    
                }

                switch (userChoice)
                {
                    case 1:
                        
                        Console.Clear();
                        Train.ShowAllTrains();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("\nEnter The Boarding Location: ");
                        string from = Console.ReadLine().ToUpper();
                        Console.Write("Enter The Destination Location: ");
                        string to = Console.ReadLine().ToUpper();

                        
                        Ticket.BookTicket(userId, from, to);
                        break;

                    case 3:
                        Console.Clear();
                        Ticket.CancelTicket(userId);
                        break;

                    case 4:
                        Console.Clear();
                        Ticket.ShowAllBookingsAndCancellations(userId);
                        break;

                    case 5:
                        Console.Clear();
                        return; 
                }
            }
        }
    }
}
