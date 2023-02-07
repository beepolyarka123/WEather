using System.Net.Http;
using System.Text;

namespace ConsoleClientApi
{
    internal class Program
    {
        static HttpClient? httpClient;

        static async Task Main(string[] args)
        {
            httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7198/WeatherForecast\r\n");
            Console.WriteLine(response);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            // обновление данных Post
            string newRecord = "{\r\n \"id\": 1, \r\n \"date\": \"03.02.2023\", \r\n \"degree\": -10, \r\n \"location\": \"Murmansk\"\r\n}";
            var stringContent = new StringContent(newRecord, Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync("https://localhost:7198/WeatherForecast", stringContent);
            Console.WriteLine(response);

            // повторное получение GET
            response = await httpClient.GetAsync("https://localhost:7198/WeatherForecast");
            Console.WriteLine(response);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            // обновление данных Put
            string updateRecord = "{\r\n \"id\": 1, \r\n \"date\": \"03.02.2023\", \r\n \"degree\": -10, \r\n \"location\": \"Murmansk\"\r\n}";
            stringContent = new StringContent(updateRecord, Encoding.UTF8, "application/json");
            response = await httpClient.PutAsync("https://localhost:7198/WeatherForecast", stringContent);
            Console.WriteLine(response);

            // Повторное получение GET
            response = await httpClient.GetAsync("https://localhost:7198/WeatherForecast");
            Console.WriteLine(response);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}