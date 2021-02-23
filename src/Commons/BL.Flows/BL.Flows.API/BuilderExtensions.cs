using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BL.Flows.API
{
    public static class FlowBuilderExtensions
    {
        public static IServiceCollection AddBLFlow(this IServiceCollection services, IMongoDatabase database, bool useDefalutdb = true)
        {
            if (database is null) throw new("db cant be null");
            var databaseUse = useDefalutdb ? database.Client.GetDatabase("blcommon") : database;
            _ = services.AddSingleton(databaseUse);
            return services;
        }
    }
}