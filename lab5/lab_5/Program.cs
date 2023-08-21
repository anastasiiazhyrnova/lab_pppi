using lab_5;

class Program
{
    static async Task Main(string[] args)
    {
        var apiClient = new ApiClient();

        try
        {
            Console.WriteLine("Fetching data using GET()...");
            ApiModel getResponse = await apiClient.Get();
            getResponse.PrintResult();


            Console.WriteLine("\nFetching data using POST()...");
            var postResponse = await apiClient.Post("users", "3");
            postResponse.PrintResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.ReadLine();
    }
}
