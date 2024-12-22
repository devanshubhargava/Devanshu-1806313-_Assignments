using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_reservation_system
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TrainId { get; set; }
        public int UserId { get; set; }
        public string Class { get; set; }
        public int SeatCount { get; set; }


        public static void ShowAllBookingsAndCancellations(int userId)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Query to fetch all tickets (both booked and cancelled) for the user

                string query = "SELECT TicketId, TrainId, Class, SeatCount, IsCancelled FROM Tickets WHERE UserId = @UserId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = command.ExecuteReader();

                List<int> ticketIds = new List<int>(); // To store TicketIds
                Console.WriteLine("\nYour All Booked and Cancelled Tickets:\n");

                // Check if tickets are available for the user

                if (!reader.HasRows)
                {
                    Console.WriteLine("No tickets found for this user.");
                    return;
                }

                // Display all tickets (booked and cancelled)

                while (reader.Read())
                {
                    int ticketId = reader.GetInt32(reader.GetOrdinal("TicketId"));
                    int trainId = reader.GetInt32(reader.GetOrdinal("TrainId"));
                    string classType = reader.GetString(reader.GetOrdinal("Class"));
                    int seatCount = reader.GetInt32(reader.GetOrdinal("SeatCount"));
                    bool isCancelled = reader.GetBoolean(reader.GetOrdinal("IsCancelled"));

                    ticketIds.Add(ticketId); // Store the TicketId for later use

                    string status = isCancelled ? "Cancelled" : "Booked"; // Display status

                    Console.WriteLine($"Ticket ID: {ticketId}, Train No: {trainId}, Class: {classType}, Seat Count: {seatCount}, Status: {status}");
                    Console.WriteLine("--------------------------------------");
                }

                reader.Close();
            }
        }

        public static void BookTicket(int userId, string from, string to)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "SELECT TrainId, TrainNo, TrainName, Available_FirstClassSeats, Available_SecondClassSeats, Available_SleeperClassSeats " +
                               "FROM Trains WHERE Source = @Source AND Destination = @Destination AND IsActive = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Source", from);
                command.Parameters.AddWithValue("@Destination", to);

                SqlDataReader reader = command.ExecuteReader();
                List<Train> availableTrains = new List<Train>();

                Console.Clear();
                Console.WriteLine("\nAvailable Trains:");
                while (reader.Read())
                {
                    Train train = new Train
                    {
                        TrainId = reader.GetInt32(reader.GetOrdinal("TrainId")),
                        TrainNo = reader.GetString(reader.GetOrdinal("TrainNo")),
                        TrainName = reader.GetString(reader.GetOrdinal("TrainName")),
                        AvailableFirstClassSeats = reader.GetInt32(reader.GetOrdinal("Available_FirstClassSeats")),
                        AvailableSecondClassSeats = reader.GetInt32(reader.GetOrdinal("Available_SecondClassSeats")),
                        AvailableSleeperClassSeats = reader.GetInt32(reader.GetOrdinal("Available_SleeperClassSeats"))
                    };
                    availableTrains.Add(train);
                    Console.WriteLine($"\n{train.TrainNo}: {train.TrainName}");
                    Console.WriteLine($"1st Class Seats: {train.AvailableFirstClassSeats}, 2nd Class Seats: {train.AvailableSecondClassSeats}, Sleeper Seats: {train.AvailableSleeperClassSeats}");
                    Console.WriteLine("--------------------------------------");
                }
                reader.Close();

                if (availableTrains.Count == 0)
                {
                    Console.WriteLine("\n No trains available for this route.");
                    return;
                }

                string selectedTrainNo = string.Empty;
                bool validTrainNo = false;
                while (!validTrainNo)
                {
                    Console.Write("\n Enter the Train Number to book a ticket: ");
                    selectedTrainNo = Console.ReadLine();
                    validTrainNo = availableTrains.Any(t => t.TrainNo == selectedTrainNo);
                    if (!validTrainNo)
                    {
                        Console.WriteLine("Invalid Train Number, please try again.");
                    }
                }

                Train selectedTrain = availableTrains.FirstOrDefault(t => t.TrainNo == selectedTrainNo);

                string classType = string.Empty;
                int seatCount = 0;
                bool validClassType = false;

                while (!validClassType)
                {
                    Console.Write("\n Enter the class type (1st, 2nd, or Sleeper): ");
                    classType = Console.ReadLine().Trim();
                    validClassType = classType == "1st" || classType == "2nd" || classType == "Sleeper";
                    if (!validClassType)
                    {
                        Console.WriteLine("Invalid class type, please choose from 1st, 2nd, or Sleeper.");
                    }
                }

                bool validSeatCount = false;
                while (!validSeatCount)
                {
                    Console.Write("\n Enter the number of seats you want to book: ");
                    validSeatCount = int.TryParse(Console.ReadLine(), out seatCount) && seatCount > 0;
                    if (!validSeatCount)
                    {
                        Console.WriteLine("Invalid seat count, please enter a positive number.");
                    }
                }

                int availableSeats = 0;

                if (classType == "1st")
                {
                    availableSeats = selectedTrain.AvailableFirstClassSeats;
                }
                else if (classType == "2nd")
                {
                    availableSeats = selectedTrain.AvailableSecondClassSeats;
                }
                else if (classType == "Sleeper")
                {
                    availableSeats = selectedTrain.AvailableSleeperClassSeats;
                }

                if (availableSeats >= seatCount)
                {
                    string bookTicketQuery = "INSERT INTO Tickets (TrainId, UserId, Class, SeatCount) VALUES (@TrainId, @UserId, @Class, @SeatCount); SELECT SCOPE_IDENTITY();";
                    SqlCommand bookTicketCommand = new SqlCommand(bookTicketQuery, connection);
                    bookTicketCommand.Parameters.AddWithValue("@TrainId", selectedTrain.TrainId);
                    bookTicketCommand.Parameters.AddWithValue("@UserId", userId);
                    bookTicketCommand.Parameters.AddWithValue("@Class", classType);
                    bookTicketCommand.Parameters.AddWithValue("@SeatCount", seatCount);

                    object result = bookTicketCommand.ExecuteScalar();
                    int newTicketId = Convert.ToInt32(result);

                    string updateSeatsQuery = string.Empty;
                    if (classType == "1st")
                    {
                        updateSeatsQuery = "UPDATE Trains SET Available_FirstClassSeats = Available_FirstClassSeats - @SeatCount WHERE TrainId = @TrainId";
                    }
                    else if (classType == "2nd")
                    {
                        updateSeatsQuery = "UPDATE Trains SET Available_SecondClassSeats = Available_SecondClassSeats - @SeatCount WHERE TrainId = @TrainId";
                    }
                    else if (classType == "Sleeper")
                    {
                        updateSeatsQuery = "UPDATE Trains SET Available_SleeperClassSeats = Available_SleeperClassSeats - @SeatCount WHERE TrainId = @TrainId";
                    }

                    SqlCommand updateSeatsCommand = new SqlCommand(updateSeatsQuery, connection);
                    updateSeatsCommand.Parameters.AddWithValue("@TrainId", selectedTrain.TrainId);
                    updateSeatsCommand.Parameters.AddWithValue("@SeatCount", seatCount);
                    updateSeatsCommand.ExecuteNonQuery();

                    Console.WriteLine($"\nTicket booked successfully! Your Ticket ID is {newTicketId}");
                }
                else
                {
                    Console.WriteLine("Not enough seats available.");
                }
            }
        }

        // Cancel ticket procedure
        public static void CancelTicket(int userId)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string getAllTicketsQuery = "SELECT TicketId, TrainId, Class, SeatCount FROM Tickets WHERE IsCancelled = 0 AND UserId = @UserId";
                SqlCommand getAllTicketsCommand = new SqlCommand(getAllTicketsQuery, connection);
                getAllTicketsCommand.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = getAllTicketsCommand.ExecuteReader();

                List<int> ticketIds = new List<int>(); 
                Console.WriteLine("Your Booked Tickets:\n");

                
                while (reader.Read())
                {
                    int ticketId = reader.GetInt32(reader.GetOrdinal("TicketId"));
                    int trainId = reader.GetInt32(reader.GetOrdinal("TrainId"));
                    string classType = reader.GetString(reader.GetOrdinal("Class"));
                    int seatCount = reader.GetInt32(reader.GetOrdinal("SeatCount"));

                    ticketIds.Add(ticketId); 

                    Console.WriteLine($"Ticket ID: {ticketId}, Train No: {trainId}, Class: {classType}, Seat Count: {seatCount}");
                }

                reader.Close();

                
                if (ticketIds.Count == 0)
                {
                    Console.WriteLine("No booked tickets to cancel.");
                    return;
                }

                int ticketIdToCancel = 0;
                bool validTicketId = false;

                while (!validTicketId)
                {
                    Console.Write("\nEnter the Ticket ID you want to cancel:");
                    validTicketId = int.TryParse(Console.ReadLine(), out ticketIdToCancel) && ticketIds.Contains(ticketIdToCancel);
                    if (!validTicketId)
                    {
                        Console.WriteLine("Invalid Ticket ID, please try again.");
                    }
                }

                
                string getTicketQuery = "SELECT TrainId, Class, SeatCount FROM Tickets WHERE TicketId = @TicketId";
                SqlCommand getTicketCommand = new SqlCommand(getTicketQuery, connection);
                getTicketCommand.Parameters.AddWithValue("@TicketId", ticketIdToCancel);
                SqlDataReader ticketReader = getTicketCommand.ExecuteReader();

                if (ticketReader.Read())
                {
                    int trainId = ticketReader.GetInt32(ticketReader.GetOrdinal("TrainId"));
                    string classType = ticketReader.GetString(ticketReader.GetOrdinal("Class"));
                    int seatCount = ticketReader.GetInt32(ticketReader.GetOrdinal("SeatCount"));

                    ticketReader.Close();

                    
                    string getTrainNoQuery = "SELECT TrainNo FROM Trains WHERE TrainId = @TrainId";
                    SqlCommand getTrainNoCommand = new SqlCommand(getTrainNoQuery, connection);
                    getTrainNoCommand.Parameters.AddWithValue("@TrainId", trainId);
                    object trainNoResult = getTrainNoCommand.ExecuteScalar();

                    if (trainNoResult == null)
                    {
                        Console.WriteLine("Invalid TrainId in the ticket.");
                        return;
                    }

                    string trainNo = trainNoResult.ToString();

                    
                    string updateSeatsQuery = string.Empty;

                    if (classType == "1st")
                    {
                        updateSeatsQuery = "UPDATE Trains SET Available_FirstClassSeats = Available_FirstClassSeats + @SeatCount WHERE TrainId = @TrainId";
                    }
                    else if (classType == "2nd")
                    {
                        updateSeatsQuery = "UPDATE Trains SET Available_SecondClassSeats = Available_SecondClassSeats + @SeatCount WHERE TrainId = @TrainId";
                    }
                    else if (classType == "Sleeper")
                    {
                        updateSeatsQuery = "UPDATE Trains SET Available_SleeperClassSeats = Available_SleeperClassSeats + @SeatCount WHERE TrainId = @TrainId";
                    }

                    SqlCommand updateSeatsCommand = new SqlCommand(updateSeatsQuery, connection);
                    updateSeatsCommand.Parameters.AddWithValue("@TrainId", trainId);
                    updateSeatsCommand.Parameters.AddWithValue("@SeatCount", seatCount);
                    updateSeatsCommand.ExecuteNonQuery();

                    
                    string cancelTicketQuery = "UPDATE Tickets SET IsCancelled = 1 WHERE TicketId = @TicketId";
                    SqlCommand cancelTicketCommand = new SqlCommand(cancelTicketQuery, connection);
                    cancelTicketCommand.Parameters.AddWithValue("@TicketId", ticketIdToCancel);
                    cancelTicketCommand.ExecuteNonQuery();

                    Console.WriteLine("\nTicket cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Ticket not found.");
                }
            }
        }
    }
}
