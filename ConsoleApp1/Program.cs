// OpenWeatherMap REST API example
// DKY 2021

using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TelegramBot

{
    class Program
    {
        static void Main(string[] args)
        {
            var ApiKey = "d864a56ba60c223cf96aae9c485e48f2";
            //var City = "Kazan";
            var url = $"https://apidata.mos.ru/v1/datasets/654/rows?api_key={ApiKey}";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine(result);
                var weatherForecast = JsonConvert.DeserializeObject<@class>(result);
            }

        }
    }
}
