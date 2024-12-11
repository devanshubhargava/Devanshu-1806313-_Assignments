using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        
        string connectionString = "Server=ICS-LT-1F6XV44\\SQLEXPRESS;Database=sql_training;Trusted_Connection=True;";

        
        string productName = "New Product";  
        float price = 100.0f;               

        
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
               
                conn.Open();

               
                using (SqlCommand cmd = new SqlCommand("Product_id_gen", conn))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@Product_name", productName);
                    cmd.Parameters.AddWithValue("@Price", price);

                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                            
                            int generatedProductId = (int)reader["GeneratedId"];

                            
                            decimal discountedPrice = reader["DiscountedPrice"] != DBNull.Value
                                ? Convert.ToDecimal(reader["DiscountedPrice"])
                                : 0;

                            
                            Console.WriteLine("Generated ProductId: " + generatedProductId);
                            Console.WriteLine("Discounted Price: " + discountedPrice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
