using Microsoft.AspNetCore.Mvc;
using WebLabApp.Models;
using WebLabApp.Models.OpenWeatherMap;
using WebLabApp.Repositories;

namespace WebLabApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWForecastRepository _WForecastRepository;

        public WeatherForecastController(IWForecastRepository WForecastRepository) 
        {
            _WForecastRepository = WForecastRepository;
        }

        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }

        [HttpPost]  
        public IActionResult SearchByCity(SearchByCity model) 
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = model.CityName});
            }
            return View(model); 
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
            City viewModel = new City();
            if(weatherResponse != null) 
            {
                viewModel.Name = weatherResponse.Name;
				viewModel.Temperature = weatherResponse.Main.Temp;
				viewModel.Humidity = weatherResponse.Main.Humidity;
				viewModel.Pressure = weatherResponse.Main.Pressure;
				viewModel.Weather = weatherResponse.Weather[0].Main;
				viewModel.Wind = weatherResponse.Wind.Speed;
			}
            return View(viewModel);
        }
    }
}
