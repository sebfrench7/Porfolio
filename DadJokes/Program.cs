using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DadJokeGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            Console.WriteLine("What topic do you want a dad joke about?");
            string topic = Console.ReadLine();

            string apiUrl = $"https://icanhazdadjoke.com/search?term={topic}";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                DadJokeResponse dadJokeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<DadJokeResponse>(jsonResponse);

                if (dadJokeResponse.total_jokes > 0)
                {
                    Random rand = new Random();
                    int index = rand.Next(0, dadJokeResponse.total_jokes - 1);

                    Console.WriteLine(dadJokeResponse.results[index].joke);
                }
                else
                {
                    Console.WriteLine($"Sorry, couldn't find any dad jokes about {topic} :(");
                }
            }
            else
            {
                Console.WriteLine("Failed to get a dad joke :(");
                
            }
        }
    }

 
    public class DadJokeResponse
    {
        public int total_jokes { get; set; }
        public DadJoke[] results { get; set; }
    }

    public class DadJoke
    {
        public string joke { get; set; } 
    }
}
 