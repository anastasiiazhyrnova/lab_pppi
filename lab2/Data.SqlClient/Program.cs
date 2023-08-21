using Microsoft.Data.SqlClient;
class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=DESKTOP-Q4SMK7F;Database=kursova;Trusted_Connection=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully..");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Connection closed..");
        Console.WriteLine("Completed");
        Console.Read();
    }
}