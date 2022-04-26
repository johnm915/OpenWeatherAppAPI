using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAppAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter your API key");
            var API_Key = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a city");
                var cityName = Console.ReadLine();
                var weatherURL =$"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={API_Key}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formattedResponse);
                Console.WriteLine();

                Console.WriteLine("How about another city?");
                var userInput = Console.ReadLine();

                if (userInput.ToLower() == "no")
                {
                    break;
                }
            }
        }
    }
}
