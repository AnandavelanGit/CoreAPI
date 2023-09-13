using CoreAPI_Practise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Practise.Contracts
{
    public interface IWeatherRepository
    {
        public Task<IEnumerable<WeatherData>> GetWeather()
        ;

    }
}
