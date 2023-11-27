using WebLabApp.Models.OpenWeatherMap;

namespace WebLabApp.Repositories
{
	public interface IWForecastRepository
	{
		WeatherResponse GetForecast(string city);
	}
}
