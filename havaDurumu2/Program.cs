using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;


namespace HavaDurumu
{
    class GetWeatherState
    {
        public string temp { get; set; }
        public string weatherState { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            Console.WriteLine("Lütfen Hava Durumunu Görmek İstediginiz Sehri Girin: ");
            input = Console.ReadLine();
            string connection = $"https://api.openweathermap.org/data/2.5/weather?q={input}&mode=xml&lang=tr&units=metric&appid=8f54418aedd0985932a74e410a5d5de0";
            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var weatherstate = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            Console.WriteLine(input + " için sicaklik: " + temp + "--------- asd Durumu: " + weatherstate);
        }

        public static GetWeatherState  getWeatherState(string temp, string weatherState)
        {


            return new GetWeatherState
            {
                temp = temp,
                weatherState = weatherState
            };
  
        }


    }
}

