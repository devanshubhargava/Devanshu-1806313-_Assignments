using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace train_reservation_system
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainNo { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableFirstClassSeats { get; set; }
        public int AvailableSecondClassSeats { get; set; }
        public int AvailableSleeperClassSeats { get; set; }

        // Show all active trains
        public static void ShowAllTrains()
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Trains WHERE IsActive = 1";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"\nTrain ID: {reader["TrainId"]}, Train Name: {reader["TrainName"]}");
                    Console.WriteLine($"Source: {reader["Source"]}, Destination: {reader["Destination"]}");
                    Console.WriteLine($"Available First Class Seats: {reader["Available_FirstClassSeats"]}");
                    Console.WriteLine($"Available Second Class Seats: {reader["Available_SecondClassSeats"]}");
                    Console.WriteLine($"Available Sleeper Class Seats: {reader["Available_SleeperClassSeats"]}");
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        // Add a new train
        public static void AddTrain(string trainNo, string trainName, string source, string destination, int totalSeats, int availableFirstClassSeats, int availableSecondClassSeats, int availableSleeperClassSeats)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Trains (TrainNo, TrainName, Source, Destination, TotalSeats, Available_FirstClassSeats, Available_SecondClassSeats, Available_SleeperClassSeats) VALUES (@TrainNo, @TrainName, @Source, @Destination, @TotalSeats, @AvailableFirstClassSeats, @AvailableSecondClassSeats, @AvailableSleeperClassSeats)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainNo", trainNo);
                command.Parameters.AddWithValue("@TrainName", trainName);
                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);
                command.Parameters.AddWithValue("@TotalSeats", totalSeats);
                command.Parameters.AddWithValue("@AvailableFirstClassSeats", availableFirstClassSeats);
                command.Parameters.AddWithValue("@AvailableSecondClassSeats", availableSecondClassSeats);
                command.Parameters.AddWithValue("@AvailableSleeperClassSeats", availableSleeperClassSeats);
                command.ExecuteNonQuery();
                Console.WriteLine("Train added successfully!");
            }
        }

        public static void ModifyTrain()
        {
            Console.Clear();
            ShowAllTrains();
            Console.WriteLine("\nEnter Train No. to Modify:");
            string trainNo = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                try
                {
                    connection.Open();

                    // Step 1: Check if the train exists
                    string checkTrainQuery = "SELECT COUNT(*) FROM Trains WHERE TrainNo = @TrainNo";
                    using (SqlCommand checkTrainCommand = new SqlCommand(checkTrainQuery, connection))
                    {
                        checkTrainCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                        int trainCount = (int)checkTrainCommand.ExecuteScalar();

                        if (trainCount == 0)
                        {
                            Console.WriteLine("Train with number {0} not found.", trainNo);
                            return;
                        }
                    }

                    // Step 2: Get the current train details
                    string getTrainQuery = "SELECT * FROM Trains WHERE TrainNo = @TrainNo";
                    using (SqlCommand getTrainCommand = new SqlCommand(getTrainQuery, connection))
                    {
                        getTrainCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                        SqlDataReader reader = getTrainCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            // Display current details
                            string currentTrainName = reader["TrainName"].ToString();
                            int currentTotalSeats = Convert.ToInt32(reader["TotalSeats"]);
                            int currentFirstClassSeats = Convert.ToInt32(reader["Available_FirstClassSeats"]);
                            int currentSecondClassSeats = Convert.ToInt32(reader["Available_SecondClassSeats"]);
                            int currentSleeperClassSeats = Convert.ToInt32(reader["Available_SleeperClassSeats"]);
                            string currentSource = reader["Source"].ToString();
                            string currentDestination = reader["Destination"].ToString();

                            // Prompt for modifications
                            string newTrainName = PromptForValue("Train Name", currentTrainName);
                            int newFirstClassSeats = PromptForIntValue("Available Berths in First Class", currentFirstClassSeats);
                            int newSecondClassSeats = PromptForIntValue("Available Berths in Second Class", currentSecondClassSeats);
                            int newSleeperClassSeats = PromptForIntValue("Available Berths in Sleeper Class", currentSleeperClassSeats);
                            string newSource = PromptForValue("From", currentSource);
                            string newDestination = PromptForValue("To", currentDestination);

                            int newTotalSeats = newFirstClassSeats + newSecondClassSeats + newSleeperClassSeats;

                            // Step 3: Update the train record
                            string updateTrainQuery = @"UPDATE Trains
                                                        SET TrainName = @TrainName,
                                                            TotalSeats = @TotalSeats,
                                                            Available_FirstClassSeats = @FirstClassAvailableSeats,
                                                            Available_SecondClassSeats = @SecondClassAvailableSeats,
                                                            Available_SleeperClassSeats = @SleeperClassAvailableSeats,
                                                            Source = @From,
                                                            Destination = @To
                                                        WHERE TrainNo = @TrainNo";

                            reader.Close();

                            using (SqlCommand updateTrainCommand = new SqlCommand(updateTrainQuery, connection))
                            {
                                updateTrainCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                                updateTrainCommand.Parameters.AddWithValue("@TrainName", newTrainName);
                                updateTrainCommand.Parameters.AddWithValue("@TotalSeats", newTotalSeats);
                                updateTrainCommand.Parameters.AddWithValue("@FirstClassAvailableSeats", newFirstClassSeats);
                                updateTrainCommand.Parameters.AddWithValue("@SecondClassAvailableSeats", newSecondClassSeats);
                                updateTrainCommand.Parameters.AddWithValue("@SleeperClassAvailableSeats", newSleeperClassSeats);
                                updateTrainCommand.Parameters.AddWithValue("@From", newSource);
                                updateTrainCommand.Parameters.AddWithValue("@To", newDestination);

                                updateTrainCommand.ExecuteNonQuery();
                                Console.WriteLine("Train record updated successfully.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public static string PromptForValue(string fieldName, string currentValue)
        {
            string input;
            do
            {
                Console.Write($"{fieldName} (Current: {currentValue}): ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    input = currentValue;
                }
                if (input.Trim().Length == 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid value.");
                }

            } while (string.IsNullOrEmpty(input.Trim()));
            return input;
        }

        private static int PromptForIntValue(string fieldName, int currentValue)
        {
            string input;
            int result;
            do
            {
                Console.Write($"{fieldName} (Current: {currentValue}): ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return currentValue; 
                }

                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (!int.TryParse(input, out result));

            return result;
        }

        public static void DeleteTrain()
        {
            Console.Clear();
            ShowAllTrains();
            Console.WriteLine("\nEnter TrainNo to Delete:");
            string trainNo = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteTrainQuery = "UPDATE Trains SET IsActive = 0 WHERE TrainNo = @TrainNo";
                    using (SqlCommand deleteTrainCommand = new SqlCommand(deleteTrainQuery, connection))
                    {
                        deleteTrainCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                        deleteTrainCommand.ExecuteNonQuery();
                        Console.WriteLine("Train has been marked as deleted.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

    }
}
