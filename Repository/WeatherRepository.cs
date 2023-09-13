using CoreAPI_Practise.Context;
using CoreAPI_Practise.Contracts;
using CoreAPI_Practise.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Practise.Repository
{
    public class WeatherRepository:IWeatherRepository   
    {
        private readonly DapperContext _context;
        public WeatherRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherData>> GetWeather()
        {
            var query = "SELECT * FROM WeatherData";

            using (var connection = _context.CreateConnection())
            {
                var weatherdatalist = await connection.QueryAsync<WeatherData>(query);
                return weatherdatalist.ToList();
            }            
        }
    }
}
