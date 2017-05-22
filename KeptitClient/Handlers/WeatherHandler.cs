using KeptitClient.Models.JSON_OpenWeatherMap_API.Model;
using KeptitClient.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace KeptitClient.Handlers
{
    public class WeatherHandler
    {
        public GreenkeeperViewModel LocalViewModel { get; set; }

        public WeatherHandler(GreenkeeperViewModel InViewModel)
        {
            this.LocalViewModel = InViewModel;
        }

        public async void GetWeatherData()
        {
            //URL til Lejre med City id=2617832
            string url = "http://api.openweathermap.org/data/2.5/weather?id=2617832&units=metric&appid=849b2c0ed687ebcd5de14111bcfada83";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<Rootobject>(response);

            LocalViewModel.Temp = data.main.temp;

            string icon = String.Format("http://openweathermap.org/img/w/{0}.png", data.weather[0].icon);
            LocalViewModel.Icon = new BitmapImage(new Uri(icon, UriKind.Absolute));
        }
    }
}
