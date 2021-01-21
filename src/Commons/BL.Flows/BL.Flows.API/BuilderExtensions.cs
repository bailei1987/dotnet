using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
namespace BL.Flows.API
{
    public static class FlowBuilderExtensions
    {
        public static IServiceCollection AddBLFlow(this IServiceCollection services, IMongoDatabase database, bool useDefalutdb = true)
        {
            if (database is null) throw new Exception("db cant be null");
            var databaseUse = useDefalutdb ? database.Client.GetDatabase("blcommon") : database;
            services.AddSingleton(databaseUse);
            return services;
        }
    }
}