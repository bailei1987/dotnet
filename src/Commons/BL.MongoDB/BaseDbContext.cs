using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.MongoDB
{

    /// <summary>
    /// map the [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId]
    /// </summary>
    public class StringObjectIdIdGeneratorConventionThatWorks : ConventionBase, IPostProcessingConvention
    {
        private readonly ConventionPackOptions _options = null;
        public StringObjectIdIdGeneratorConventionThatWorks(ConventionPackOptions options)
        {
            _options = options;
        }
        public void PostProcess(BsonClassMap classMap)
        {
            if (_options.IsNotConvertObjectIdToStringType(classMap.ClassType)) return;
            var idMemberMap = classMap.IdMemberMap;
            if (idMemberMap == null || idMemberMap.IdGenerator != null) return;
            if (idMemberMap.MemberType == typeof(string)) idMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance).SetSerializer(new StringSerializer(BsonType.ObjectId));
        }
    }
    /// <summary>
    /// mongodb base context
    /// </summary>
    public class BaseDbContext
    {
        public BaseDbContext(NetCoreAppSetting dbSettings)
        {
            if (dbSettings.Servers.Count == 0) throw new Exception("BaseDbContext Init error! host,port,db must not null");
            if (dbSettings.Credential == null || dbSettings.Credential.User == null || dbSettings.Credential.Pwd == null) throw new Exception("BaseDbContext Init error! user,pwd must not null");
            var settings = new MongoClientSettings
            {
                Credential = MongoCredential.CreateCredential("admin", dbSettings.Credential.User, dbSettings.Credential.Pwd),
                ReplicaSetName = dbSettings.ReplSetName
            };
            if (dbSettings.Servers.Count > 1 && !string.IsNullOrWhiteSpace(dbSettings.ReplSetName)) settings.Servers = dbSettings.Servers.Select(x => new MongoServerAddress(x.Host, x.Port));
            else settings.Server = new MongoServerAddress(dbSettings.Servers[0].Host, dbSettings.Servers[0].Port);
            if (dbSettings.ServerSelectionTimeout != null && dbSettings.ServerSelectionTimeout != 0)
            {
                settings.ServerSelectionTimeout = new TimeSpan(0, 0, 0, 0, dbSettings.ServerSelectionTimeout.Value);
            }
            _client = new MongoClient(settings);
            _database = _client.GetDatabase(dbSettings.Db);
        }

        public static void RegistConventionPack(Action<ConventionPackOptions> configure = null)
        {
            configure?.Invoke(options);
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention(),//property to camel
                new IgnoreExtraElementsConvention(true),//
                new NamedIdMemberConvention("Id","ID"),//_id mapping Id or ID
                new EnumRepresentationConvention(BsonType.String),//save enum value as string
                new StringObjectIdIdGeneratorConventionThatWorks(options)//Id[string] mapping ObjectId
            };
            ConventionRegistry.Register("myconvention", pack, x => true);
            BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(DateTimeKind.Local));//to local time
        }

        public BaseDbContext() { }
        public IMongoClient _client;
        public IMongoDatabase _database;
        public IMongoCollection<BsonDocument> GetCollection(string collection)
        {
            return _database.GetCollection<BsonDocument>(collection);
        }
        private static readonly ConventionPackOptions options = new ConventionPackOptions();
    }

    public class ConventionPackOptions
    {
        private readonly List<Type> NotConvertObjectIdToStringTypes = new List<Type>();
        public void AddNotConvertObjectIdToStringTypes(params Type[] types)
        {
            NotConvertObjectIdToStringTypes.AddRange(types);
        }
        public bool IsNotConvertObjectIdToStringType(Type type)
        {
            return NotConvertObjectIdToStringTypes.Contains(type);
        }
    }
}
