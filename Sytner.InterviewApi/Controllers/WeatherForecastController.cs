using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sytner.InterviewApi.DataAccess;
using Sytner.Utilities.AspNetCore.Extensions;
using Sytner.Utilities.Domain;
using Sytner.Utilities.ServiceResult;

namespace Sytner.InterviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecastByStationId")]
        public IActionResult GetForecastByStationId(int id)
        {
            var forecastData = new WeatherStationDataAccess(new WeatherStationContext()).GetForecastByWeatherStationId(id);

            var forecastList = new WeatherHelper().BuildWeatherForecasts(forecastData);

            var serviceResult = ServiceResult<IEnumerable<WeatherForecast>>.Success(forecastList);

            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpGet("GetWeatherForecastByDateRange")]
        public IActionResult GetWeatherForecastByDateRange(string dateFrom, string dateTo)
        {
            var forecastData = new WeatherStationDataAccess(new WeatherStationContext()).GetForecastByWeatherStationCodeandDateRange(dateFrom, dateTo);

            var forecastList = new WeatherHelper().BuildWeatherForecasts(forecastData);

            var serviceResult = ServiceResult<IEnumerable<WeatherForecast>>.Success(forecastList);

            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpPost("AddWeatherStation")]
        public IActionResult AddWeatherStation(string stationName, string stationCode, string latitude, string longitude)
        {
            var station = new WeatherStationDataAccess(new WeatherStationContext()).AddWeatherStation(stationName, stationCode, latitude, longitude);

            var serviceResult = ServiceResult<WeatherStations>.Success(station);

            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpPost("AddWeatherStationForecastData")]
        public IActionResult AddWeatherStationForecastData(int stationId, decimal temperature, string forecastDate)
        {
            var forecastData = new WeatherStationDataAccess(new WeatherStationContext()).AddWeatherStationForecastData(stationId, temperature, forecastDate);

            var serviceResult = ServiceResult<ForecastData>.Success(forecastData);

            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpPatch("UpdateWeatherDataByWeatherStationCode")]
        public IActionResult Update(int forecastId, int stationId, decimal temperature, string forecastDate)
        {
            var forecastData = new WeatherStationDataAccess(new WeatherStationContext()).UpdateForecast(forecastId, stationId, temperature, forecastDate);

            var serviceResult = ServiceResult<ForecastData>.Success(forecastData);

            return this.ServiceResultToActionResult(serviceResult);
        }


    }
}