﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BL.MongoDB
{
    public static class BLMongoDBServiceCollectionExtensions
    {
        /// <summary>
        /// 1.Use BaseDbContext.RegistConventionPack()
        /// 1.create a DbContext(inherit BL.MongoDB.BaseDbContext) use connectionString with [ConnectionStrings.Mongo in appsettings.json] or with [CONNECTIONSTRINGS_MONGO] setting value in environment variable
        /// 3.inject DbContext use services.AddSingleton(db);
        public static T AddBLMongoDbContext<T>(this IServiceCollection services, IConfiguration configuration, Action<ConventionPackOptions> conventionPackOptionsAction = null, bool first = true) where T : BaseDbContext
        {
            var tipHead = "BL.MongoDB.Gen.AddBLMongoDbContext";
            var connectionString = configuration["CONNECTIONSTRINGS_MONGO"];
            if (string.IsNullOrWhiteSpace(connectionString) == false) Console.WriteLine($"[{tipHead}]:get [CONNECTIONSTRINGS_MONGO] setting value [{connectionString}] from env,used ");
            else
            {
                connectionString = configuration.GetConnectionString("Mongo");
                Console.WriteLine($"[{tipHead}]:get ConnectionStrings.Mongo in appsettings.json");
            }
            if (string.IsNullOrWhiteSpace(connectionString)) throw new($"[{tipHead}]:no [CONNECTIONSTRINGS_MONGO] setting in env and ConnectionStrings.Mongo in appsettings.json");
            BaseDbContext.RegistConventionPack(conventionPackOptionsAction, first);
            var db = BaseDbContext.CreateInstance<T>(connectionString);
            db.BuildTransactCollections();
            _ = services.AddSingleton(db);
            return db;
        }

        public static T AddBLMongoDbContextSpecificConnKey<T>(this IServiceCollection services, IConfiguration configuration, string connKey, Action<ConventionPackOptions> conventionPackOptionsAction = null, bool first = true) where T : BaseDbContext
        {
            var tipHead = "BL.MongoDB.Gen.AddBLMongoDbContext";
            var connectionString = configuration[connKey];
            if (string.IsNullOrWhiteSpace(connectionString) == false) Console.WriteLine($"[{tipHead}]:get [{connKey}] setting value [{connectionString}] from env,used ");
            else
            {
                connectionString = configuration.GetConnectionString(connKey);
                Console.WriteLine($"[{tipHead}]:get ConnectionStrings.{connKey} in appsettings.json");
            }
            if (string.IsNullOrWhiteSpace(connectionString)) throw new($"[{tipHead}]:no [{connKey}] setting in env and ConnectionStrings.{connKey} in appsettings.json");
            BaseDbContext.RegistConventionPack(conventionPackOptionsAction, first);
            var db = BaseDbContext.CreateInstance<T>(connectionString);
            db.BuildTransactCollections();
            _ = services.AddSingleton(db);
            return db;
        }

        public static T AddBLMongoDbSet<T>(this IServiceCollection services, IConfiguration configuration, Action<ConventionPackOptions> conventionPackOptionsAction = null, bool first = true) where T : BaseDbContext, IDbSet
        {
            var tipHead = "BL.MongoDB.Gen.AddBLDbSet";
            var connectionString = configuration["CONNECTIONSTRINGS_MONGO"];
            if (string.IsNullOrWhiteSpace(connectionString) == false) Console.WriteLine($"[{tipHead}]:get [CONNECTIONSTRINGS_MONGO] setting value [{connectionString}] from env,used ");
            else
            {
                connectionString = configuration.GetConnectionString("Mongo");
                Console.WriteLine($"[{tipHead}]:get ConnectionStrings.Mongo in appsettings.json");
            }
            if (string.IsNullOrWhiteSpace(connectionString)) throw new($"[{tipHead}]:no [CONNECTIONSTRINGS_MONGO] setting in env and ConnectionStrings.Mongo in appsettings.json");
            BaseDbContext.RegistConventionPack(conventionPackOptionsAction, first);
            var db = BaseDbContext.CreateInstance<T>(connectionString);
            db.BuildTransactCollections();
            _ = services.AddSingleton(typeof(IDbSet), db);
            return db;
        }
    }


}