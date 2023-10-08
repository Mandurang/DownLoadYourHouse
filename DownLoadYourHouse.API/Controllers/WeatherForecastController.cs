using Microsoft.AspNetCore.Mvc;

namespace DownLoadYourHouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly Dictionary<Guid, WeatherForecast> weatherForecasts = new();

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(weatherForecasts);
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            var id = Guid.NewGuid();
            weatherForecasts.Add(id, weatherForecast);
            return Ok(weatherForecasts);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] WeatherForecast weatherForecast)
        {
            var existingWeather = weatherForecasts.GetValueOrDefault(id);
            if (existingWeather != null)
            {
                weatherForecasts[id] = weatherForecast;
            }
            return Ok(weatherForecasts);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var existingWeather = weatherForecasts.GetValueOrDefault(id);
            return Ok(existingWeather);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            weatherForecasts.Remove(id);
            return Ok(weatherForecasts);
        }
    }
}