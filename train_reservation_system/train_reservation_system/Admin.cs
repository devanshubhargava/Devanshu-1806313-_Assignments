using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_reservation_system
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Admin Login
        public static Admin AdminLogin(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Admins WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Admin
                    {
                        AdminId = reader.GetInt32(reader.GetOrdinal("AdminId")),
                        AdminName = reader.GetString(reader.GetOrdinal("AdminName")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Password = reader.GetString(reader.GetOrdinal("Password"))
                    };
                }
                return null;
            }
        }

        // Register admin
        public static void Register(string adminName, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Admins (AdminName, Email, Password) VALUES (@AdminName, @Email, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AdminName", adminName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
                Console.WriteLine("Admin registered successfully!");
            }
        }
    }

}
