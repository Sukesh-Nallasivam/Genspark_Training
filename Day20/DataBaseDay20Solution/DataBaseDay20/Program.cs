using System;
using System.Data.SqlClient;

namespace DataBaseDay20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Attempting to connect to the database...");
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbEmployeeTracker;Integrated Security=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connected to the database successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to the database: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
