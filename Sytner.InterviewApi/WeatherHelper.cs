using Sytner.InterviewApi.DataAccess;
using Sytner.Utilities.Domain;

namespace Sytner.InterviewApi
{
    public class WeatherHelper
    {
        public List<WeatherForecast> BuildWeatherForecasts(List<ForecastData> data)
        {
            var foreCasts = new List<WeatherForecast>();

            var summariesList = new WeatherStationDataAccess(new WeatherStationContext()).GetSummaries();

            foreach (var forecast in data) 
            {
                foreCasts.Add(new WeatherForecast()
                {
                    Date = forecast.Date,
                    Summary = summariesList.Where(s => s.Above < Decimal.ToInt32(forecast.Temperature) && s.Below > Decimal.ToInt32(forecast.Temperature)).First().Description,
                    TemperatureC = Decimal.ToInt32(forecast.Temperature)
                });
            }

            return foreCasts;
        }
    }
}
