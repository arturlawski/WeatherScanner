using Microsoft.EntityFrameworkCore;
using WeatherSofomo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Persistance.WeatherSofomo.Persistence;

namespace WeatherSofomo.Persistence
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherDbContext _context;

        public WeatherRepository(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherEntity>> GetWeathersAsync(int take, int skip)
        {
            return await _context.WeatherEntities
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<WeatherEntity> GetWeatherAsync(Guid weatherId)
        {
            var weather = await _context.WeatherEntities
                .FirstOrDefaultAsync(x => x.Id == weatherId);

            if (weather == null)
                throw new Exception("Weather not found");

            return weather;
        }

        public async Task DeleteWeatherAsync(Guid weatherId)
        {
            var weather = await _context.WeatherEntities
                .FirstOrDefaultAsync(x => x.Id == weatherId);

            if (weather == null)
                throw new Exception("Weather not found");

            _context.WeatherEntities.Remove(weather);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWeatherAsync(WeatherEntity weather)
        {
            _context.WeatherEntities.Update(weather);
            await _context.SaveChangesAsync();
        }

        public async Task AddWeatherAsync(WeatherEntity weather)
        {
            await _context.WeatherEntities.AddAsync(weather);
            await _context.SaveChangesAsync();
        }

        public int GetWeatherCount()
        {
            return _context.WeatherEntities.Count();
        }
    }
}