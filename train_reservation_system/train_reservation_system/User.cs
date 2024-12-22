using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_reservation_system
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Login method to check user credentials
        public static User UserLogin(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                        UserName = reader.GetString(reader.GetOrdinal("UserName")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Password = reader.GetString(reader.GetOrdinal("Password"))
                    };
                }
                return null;
            }
        }

        // Register method to add a new user
        public static void Register(string userName, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (UserName, Email, Password) VALUES (@UserName, @Email, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
                Console.WriteLine("User registered successfully!");
            }
        }
    }

}
