using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace BL.MongoDB
{

    /// <summary>
    /// map the [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId]
    /// </summary>
    public class StringObjectIdIdGeneratorConventionThatWorks : ConventionBase, IPostProcessingConvention
    {
        public void PostProcess(BsonClassMap classMap)
        {
            var idMemberMap = classMap.IdMemberMap;
            if (idMemberMap == null || idMemberMap.IdGenerator != null) return;
            if (idMemberMap.MemberType == typeof(string)) _ = idMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance).SetSerializer(new StringSerializer(BsonType.ObjectId));
        }
    }
    /// <summary>
    /// mongodb base context
    /// </summary>
    public class BaseDbContext
    {
        public static T CreateInstance<T>(string connectionString, string db = null) where T : BaseDbContext
        {
            T t = Activator.CreateInstance<T>();
            if (string.IsNullOrWhiteSpace(connectionString)) throw new("connectionString is empty");
            var mongoUrl = new MongoUrl(connectionString);
            t._client = new MongoClient(mongoUrl);
            var dbname = string.IsNullOrWhiteSpace(db) ? mongoUrl.DatabaseName : db;
            t._database = t._client.GetDatabase(dbname);
            return t;
        }
        public static void RegistConventionPack(Action<ConventionPackOptions> configure = null, bool first = true)
        {
            configure?.Invoke(options);
            if (first)
            {
                try
                {
                    var pack = new ConventionPack
                    {
                        new CamelCaseElementNameConvention(),//property to camel
                        new IgnoreExtraElementsConvention(true),//
                        new NamedIdMemberConvention("Id","ID"),//_id mapping Id or ID
                        new EnumRepresentationConvention(BsonType.String),//save enum value as string     
                    };
                    ConventionRegistry.Register("commonpack", pack, x => true);
                    BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(DateTimeKind.Local));//to local time
                    BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));//decimal to decimal default
                }
                catch (Exception ex)
                {
                    throw new("you have already regist commonpack,please change param [first] to false from since second RegistConventionPack Method(or BL.MongoDB.Gen.AddBLDbContext etc..):" + ex.Message);
                }
            }
            var idpack = new ConventionPack
            {
                new StringObjectIdIdGeneratorConventionThatWorks()//Id[string] mapping ObjectId
            };
            ConventionRegistry.Register("idpack" + Guid.NewGuid().ToString(), idpack, x => options.IsIdExcept(x) == false);
        }

        public BaseDbContext() { }
        public IMongoClient _client;
        public IMongoDatabase _database;
        public IMongoCollection<BsonDocument> GetCollection(string collection)
        {
            return _database.GetCollection<BsonDocument>(collection);
        }
        private static readonly ConventionPackOptions options = new();
    }

    public class ConventionPackOptions
    {
        //Indicate the types which do not use MongoDB Auto ObjectId.
        private readonly List<Type> _idExcepts = new();
        public ConventionPackOptions AddIdExcepts(params Type[] types)
        {
            _idExcepts.AddRange(types);
            return this;
        }
        public bool IsIdExcept(Type type)
        {
            return _idExcepts.Contains(type);
        }
    }
}
