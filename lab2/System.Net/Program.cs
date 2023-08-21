using System;

class Program
{
    static void Main()
    {
        Task.Run(new Action(DownloadPageAsync));
        Console.ReadLine();
    }
    static HttpClient сlient = new HttpClient();

    static async void DownloadPageAsync()
    {
        var result = await сlient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
        Console.WriteLine("Status code: " + result.StatusCode);
        string response = await result.Content.ReadAsStringAsync();
        Console.WriteLine("Response:");
        Console.WriteLine(response);
    }
}
