using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your database
        string connectionString = "Server=ICS-LT-1F6XV44\\SQLEXPRESS;Database=sql_training;Trusted_Connection=True;";

        // Create a SQL connection
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Create a SQL command to execute the stored procedure
            using (SqlCommand cmd = new SqlCommand("InsertProductDetails", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Define input parameters
                cmd.Parameters.AddWithValue("@ProductName", "Sample Product");
                cmd.Parameters.AddWithValue("@Price", 100.00);  // Example price

                // Define output parameters
                SqlParameter outProductId = new SqlParameter("@GeneratedProductId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outProductId);

                SqlParameter outDiscountedPrice = new SqlParameter("@CalculatedDiscountedPrice", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outDiscountedPrice);

                // Execute the stored procedure
                cmd.ExecuteNonQuery();

                // Retrieve the output values
                int generatedProductId = (int)outProductId.Value;
                decimal discountedPrice = (decimal)outDiscountedPrice.Value;

                // Display the results
                Console.WriteLine("Generated ProductId: " + generatedProductId);
                Console.WriteLine("Discounted Price: " + discountedPrice);
            }
        }
    }
}
