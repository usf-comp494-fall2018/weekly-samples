using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectService.Models
{
    public class WeatherModel
    {
        private NorthwindContext _db = null;

        public WeatherModel(NorthwindContext db)
        {
            _db = db;
        }

        public CurrentConditions GetCurrentConditions()
        {
            var currentConditions = _db.CurrentConditions.FirstOrDefault();
            // If we don't have any data or it's more than 15 minutes old
            if (currentConditions == null || DateTime.Now.Subtract(Convert.ToDateTime(currentConditions.Lastcheck)).Minutes > 15)
            {
                // Go Get the current conditions
                var client = new RestClient("http://api.wunderground.com");
                var request = new RestRequest("api/<insert-api-key-here>/conditions/q/IL/Lemont.json");
                var response = client.Execute(request);
                var content = response.Content;
                bool bIsNew = false;
                var currCond = JsonConvert.DeserializeObject<WundergroundCurrentConditions>(content);
                // Did we find one or are we starting new?
                if (currentConditions == null)
                {
                    currentConditions = new CurrentConditions();
                    bIsNew = true;
                }
                // Set the updated values
                currentConditions.ObservationTime = currCond.current_observation.observation_time;
                currentConditions.RelativeHumidity = currCond.current_observation.relative_humidity;
                currentConditions.TempF = currCond.current_observation.temp_f;
                currentConditions.Weather = currCond.current_observation.weather;
                currentConditions.WindDir = currCond.current_observation.wind_dir;
                currentConditions.WindMph = currCond.current_observation.wind_mph;
                currentConditions.Lastcheck = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                // Insert or Update as appropriate
                if (bIsNew)
                {
                    _db.CurrentConditions.Add(currentConditions);
                }
                else
                {
                    _db.CurrentConditions.Update(currentConditions);
                    _db.SaveChanges();
                }
            }
            return currentConditions;
        }

        public IEnumerable<ThreeDayForecast> GetThreeDayForecast()
        {
            // If we don't have any data or it's more than 12 hours old

            if (_db.ThreeDayForecast.Count() < 1 || DateTime.Now.Subtract(Convert.ToDateTime(_db.ThreeDayForecast.First().Lastcheck)).Hours > 12)
            {
                // Go Get the current conditions
                var client = new RestClient("http://api.wunderground.com");
                var request = new RestRequest("api/<insert-api-key-here>/forecast/q/IL/Lemont.json");
                var response = client.Execute(request);
                var content = response.Content;
                var threeDays = JsonConvert.DeserializeObject<WundergroundForecast>(content);
                // Clear the previous list
                _db.ThreeDayForecast.RemoveRange(_db.ThreeDayForecast);
                foreach (Forecastday forecastday in threeDays.forecast.txt_forecast.forecastday)
                {
                    ThreeDayForecast tdf = new ThreeDayForecast
                    {
                        Id = forecastday.period,
                        Fcttext = forecastday.fcttext,
                        Icon = forecastday.icon,
                        Period = forecastday.period,
                        Title = forecastday.title,
                        Lastcheck = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                    };
                    _db.ThreeDayForecast.Add(tdf);
                }
                _db.SaveChanges();
            }

            return _db.ThreeDayForecast;
        }
    }
}
