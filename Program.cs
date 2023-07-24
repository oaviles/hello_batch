using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide the URL of the Logic App as a command-line argument.");
            return;
        }

        try
        {
            using (var client = new HttpClient())
            {
                var logicAppUrl = args[0];
                var response = await client.PostAsync(logicAppUrl, null);
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}