
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Globalization;
using Sytner.Utilities.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sytner.InterviewApi.DataAccess
{
    public class WeatherStationDataAccess
    {
        private static WeatherStationContext _context;
        public WeatherStationDataAccess(WeatherStationContext context) 
        {
            _context = context;
        }
        public List<ForecastData> GetForecastByWeatherStationId(int stationId) 
        { 
            return _context.Forecasts.Where(f => f.WeatherStationId == stationId).ToList();
        }

        public List<ForecastData> GetForecastByWeatherStationCodeandDateRange(string fromDate, string toDate)
        {
            var forecastList = new List<ForecastData>();
            var culture = new CultureInfo("en-GB");
            
            try
            {
                var fromDateToDateTime = DateTime.Parse(fromDate, culture);
                var toDateFromDateTime = DateTime.Parse(toDate, culture);

                forecastList = _context.Forecasts.Where(f => f.Date >= fromDateToDateTime && f.Date <= toDateFromDateTime).ToList();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return forecastList;
        }

        public List<Summary> GetSummaries()
        {
            return _context.Summaries.ToList();
        }

        public WeatherStations AddWeatherStation(string name, string code, string latitude, string longitude)
        {
            var weatherStation = new WeatherStations()
            {
                Name = name,
                Code = code,
                Latitude = latitude,
                Longitude = longitude,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.WeatherStations.Add(weatherStation);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return weatherStation;
        }

        public ForecastData AddWeatherStationForecastData(int stationId, decimal temperature, string forecastDate)
        {
            var culture = new CultureInfo("en-GB");

            var dateToDateTime = DateTime.Parse(forecastDate, culture);

            var forecastData = new ForecastData()
            {
                WeatherStationId = stationId,
                Temperature = temperature,
                Date = dateToDateTime,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.Forecasts.Add(forecastData);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return forecastData;
        }

        public ForecastData UpdateForecast(int forecastId, int stationId, decimal temperature, string forecastDate)
        {
            var culture = new CultureInfo("en-GB");

            var dateToDateTime = DateTime.Parse(forecastDate, culture);

            var forecastData = new ForecastData()
            {
                Id = forecastId,
                WeatherStationId = stationId,
                Temperature = temperature,
                Date = dateToDateTime,
                ModifiedDate = DateTime.Now
            };

            try
            {                
                _context.Forecasts.Update(forecastData);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return forecastData;
        }
    }
}
