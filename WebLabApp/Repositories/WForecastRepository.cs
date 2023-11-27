using WebLabApp.Models.OpenWeatherMap;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WebLabApp.Repositories
{
	public class WForecastRepository : IWForecastRepository
	{
		public WeatherResponse GetForecast(string city)
		{
			string APP_ID = Configuration.Values.OPEN_WEATHER_APP_ID;
			var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={APP_ID}");
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);
			if(response.IsSuccessful)
			{
				var content = JsonConvert.DeserializeObject<JToken>(response.Content);
				return content?.ToObject<WeatherResponse>();
			}
			else
			{
				return null;
			}
		}
	}
}
