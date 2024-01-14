using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WeatherClassLibrary
{
    public class Weather
    {
        private WebClient client;

        public string Url { get; set; }
        public string Title { get; set; }
        public double Temperature { get; private set; }
        public double WindSpeed { get; private set; }
        public string WindDirection { get; private set; }
        public double Humidity { get; private set; }
        public double WaterTemperature { get; private set; }
        public string ImageLink { get; private set; }

        public Weather(string url)
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;

            Url = url;
            Title = GetTitle();
            Temperature = GetTemperature();
            WindSpeed = GetWindSpeed();
            WindDirection = GetWindDirection();
            Humidity = GetHumidity();
            WaterTemperature = GetWaterTemperature();
            ImageLink = GetImageUrl();
        }
        
        private string GetTitle()
        {
            string html = client.DownloadString("https://ua.sinoptik.ua/");
            var regex = new Regex("<div class=\"imgBlock\"> <p class=\"today-time\">Погода сьогодні о (([01]\\d|2[0-3]):([0-5]\\d))<\\/p> <div class=\"img\"> <img width=\"188\" height=\"150\" src=\"(\\/\\/([a-zA-Z0-9_\\-\\.\\/]+).jpg)\" alt=\"(.*?)\"\\/>");
            Match match = regex.Match(html);
            if (match.Success)
            {
                return match.Groups[6].Value;
            }
            throw new FormatException("Title not found");
        }

        private double GetTemperature()
        {
            string html = client.DownloadString(Url);
            var regex = new Regex("\"temperatureAir\":\\[(-?\\d+)\\]");
            Match match = regex.Match(html);
            if (match.Success)
            {
                return Convert.ToDouble(match.Groups[1].Value);
            }
            throw new FormatException("Temperature not found");
        }

        private double GetWindSpeed()
        {
            string html = client.DownloadString(Url);
            var regex = new Regex("\"windSpeed\":\\[(\\d+)\\]");
            Match match = regex.Match(html);
            if (match.Success)
            {
                return Convert.ToDouble(match.Groups[1].Value);
            }
            throw new FormatException("Wind Speed not found");
        }

        private string GetWindDirection()
        {
            string html = client.DownloadString(Url);
            var regex = new Regex("<div class=\"item-value\"><span class=\"unit unit_wind_m_s\">(\\d+)<span class=\"text-12s\">&nbsp;м\\/c,\\s(.*?)<\\/span>");
            Match match = regex.Match(html);
            if (match.Success)
            {
                return match.Groups[2].Value;
            }
            throw new FormatException("Wind Direction not found");
        }

        private double GetHumidity()
        {
            string html = client.DownloadString(Url);
            var regex = new Regex("\"humidity\":\\[(\\d+)\\]");
            Match match = regex.Match(html);
            if (match.Success)
            {
                return Convert.ToDouble(match.Groups[1].Value);
            }
            throw new FormatException("Humidity not found");
        }

        private double GetWaterTemperature()
        {
            string html = client.DownloadString(Url);
            var regex = new Regex("\"temperatureWater\":\\[(-?\\d+)\\]");
            Match match = regex.Match(html);
            if (match.Success)
            {
                return Convert.ToDouble(match.Groups[1].Value);
            }
            throw new FormatException("Water Temperature not found");
        }

        private string GetImageUrl()
        {
            string html = client.DownloadString("https://ua.sinoptik.ua/");
            var regex = new Regex("<div class=\"imgBlock\"> <p class=\"today-time\">Погода сьогодні о (([01]\\d|2[0-3]):([0-5]\\d))<\\/p> <div class=\"img\"> <img width=\"188\" height=\"150\" src=\"(\\/\\/([a-zA-Z0-9_\\-\\.\\/]+).jpg)\"");
            Match match = regex.Match(html);
            if (match.Success)
            {
                return match.Groups[4].Value;
            }
            throw new FormatException("Image Url not found");
        }
    }
}