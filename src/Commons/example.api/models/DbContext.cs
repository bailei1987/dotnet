
using BL.MongoDB;
using MongoDB.Driver;

namespace models
{
    public class DbContext : BaseDbContext
    {
        public DbContext(NetCoreAppSetting dbSettings) : base(dbSettings)
        { }

        public IMongoCollection<WeatherForecast> WeatherForecasts => _database.GetCollection<WeatherForecast>("weatherForecasts");
    }
}
