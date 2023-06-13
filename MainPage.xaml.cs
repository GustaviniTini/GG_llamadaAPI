
using GG_llamadaAPI.Models;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;


namespace GG_llamadaAPI
{
    public partial class MainPage : ContentPage
    {
    

        public MainPage()
        {
            InitializeComponent();
        }

        private void GG_OnEnviarClicked(object sender, EventArgs e)
        {
            string latitud = GG_latitudEntry.Text;
            string longitud = GG_longitudEntry.Text;

            using(var client = new HttpClient())
            {
                var url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=9c3a0a4932ecfe14a0ad4703d88ee296";

                var response = client.GetAsync(url).Result;
                if(response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    var weatherData = JsonConvert.DeserializeObject<Clima>(content);
                    GG_estadoClimaLabel.Text = weatherData.weather[0].description;
                    GG_paisLabel.Text = weatherData.sys.country;
                    GG_ciudadLabel.Text = weatherData.name;
                }
            }
        }

    }
}


