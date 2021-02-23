using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;

namespace BL.BusinessLog
{
    public static class BusinessLogHelper
    {
        private static void LogOperateOne(dynamic user, Enum business, string operateType, string id, object content = null, string update = null, string title = null)
        {
            var time = DateTime.Now;
            string filter = null;
            if (operateType != BusinessOperateType.InsertOne)
            {
                filter = $"{{_id:\"{id}\"}}";
                if (ObjectId.TryParse(id, out _)) filter += $" | {{ _id: ObjectId('{id}')}}";
            }
            var log = new BusinessLog
            {
                App = App,
                Business = business.ToString(),
                Title = title,
                OperateType = operateType,
                Operator = new() { Rid = user.Rid, Name = user.Name, Time = time },
                Key = id,
                Filter = filter,
                Update = update,
                EffectCount = 1,
                Content = content?.ToJson(),
                Text = $"[{user.Name}:{user.Rid}] [{time:yyyy-MM-dd}] [{operateType}] [_id:{id}] [{App.Name}]"
            };
            Coll.InsertOne(log);
        }
        public static void LogInsertOne(dynamic user, Enum business, string id, object content = null, string title = null)
        {
            LogOperateOne(user, business, BusinessOperateType.InsertOne, id, content, title);
        }
        public static void LogDeleteOne(dynamic user, Enum business, string id, object content = null, string title = null)
        {
            LogOperateOne(user, business, BusinessOperateType.DeleteOne, id, content, title);
        }
        public static void LogUpdateOne(dynamic user, Enum business, string id, string update = null, object content = null, string title = null)
        {
            LogOperateOne(user, business, BusinessOperateType.UpdateOne, id, content, update, title);
        }
        public static void LogUpdateOne<T>(dynamic user, Enum business, string id, UpdateDefinition<T> updateDefinition = null, object content = null, string title = null)
        {
            LogOperateOne(user, business, BusinessOperateType.UpdateOne, id, content, GetJson(updateDefinition), title);
        }

        public static void LogDeleteMany<T>(dynamic user, Enum business, FilterDefinition<T> filterDefinition, long effectCount, string content = null, string title = null)
        {
            LogDeleteMany(user, business, GetJson(filterDefinition), effectCount, content, title);
        }
        public static void LogDeleteMany(dynamic user, Enum business, string filter, long effectCount, string content = null, string title = null)
        {
            var time = DateTime.Now;
            var log = new BusinessLog
            {
                App = App,
                Business = business.ToString(),
                Title = title,
                OperateType = BusinessOperateType.DeleteMany,
                Operator = new() { Rid = user.Rid, Name = user.Name, Time = time },
                Filter = filter,
                EffectCount = effectCount,
                Content = content?.ToJson(),
                Text = $"[{user.Name}:{user.Rid}] [{time:yyyy-MM-dd}] [{BusinessOperateType.DeleteMany}] [{App.Name}]"
            };
            Coll.InsertOne(log);
        }
        public static void LogUpdateMany<T>(dynamic user, Enum business, FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition, long effectCount, string content = null, string title = null)
        {
            LogUpdateMany(user, business, GetJson(filterDefinition), GetJson(updateDefinition), effectCount, content, title);
        }
        public static void LogUpdateMany(dynamic user, Enum business, string filter, string update, long effectCount, string content = null, string title = null)
        {
            var time = DateTime.Now;
            var log = new BusinessLog
            {
                App = App,
                Business = business.ToString(),
                Title = title,
                OperateType = BusinessOperateType.UpdateMany,
                Operator = new() { Rid = user.Rid, Name = user.Name, Time = time },
                Filter = filter,
                Update = update,
                EffectCount = effectCount,
                Content = content?.ToJson(),
                Text = $"[{user.Name}:{user.Rid}] [{time:yyyy-MM-dd}] [{BusinessOperateType.UpdateMany}] [{App.Name}]"
            };
            Coll.InsertOne(log);
        }

        public static void LogImport(dynamic user, Enum business, string[] ids, string content = null, string title = null)
        {
            var time = DateTime.Now;
            if (ids is null) ids = Array.Empty<string>();
            var log = new BusinessLog
            {
                App = App,
                Business = business.ToString(),
                Title = title,
                OperateType = BusinessOperateType.Import,
                Operator = new() { Rid = user.Rid, Name = user.Name, Time = time },
                Key = $"[{string.Join(",", ids)}]",
                EffectCount = ids.Length,
                Content = content?.ToJson(),
                Text = $"[{user.Name}:{user.Rid}] [{time:yyyy-MM-dd}] [{BusinessOperateType.Import}] [{App.Name}]"
            };
            Coll.InsertOne(log);
        }

        public static BusinessLogPageResult<object> Page(BusinessLogKeywordPageInfo dto)
        {
            var bf = Builders<BusinessLog>.Filter;
            var filter = bf.Empty;
            if (!string.IsNullOrWhiteSpace(dto.SearchKey)) filter &= bf.Where(x => x.Text.Contains(dto.SearchKey));
            var query = Coll.Find(filter);
            var total = query.CountDocuments();
            var list = query.Project(x => new
            {
                x.Id,
                x.App,
                x.Business,
                x.OperateType,
                x.Key,
                x.Operator,
                x.Text
            }).SortByDescending(x => x.Id).Skip((dto.PageIndex - 1) * dto.PageSize).Limit(dto.PageSize).ToList();
            return BusinessLogPageResult.WrapDynamic(total, list);
        }

        public static void ConfigureUseDefaultColl(IMongoDatabase db, BusinessApp app)
        {
            if (db is null) throw new("db cant be null");
            App = app;
            Coll = db.Client.GetDatabase("blcommon").GetCollection<BusinessLog>("blogs");
        }
        private static BusinessApp App;
        private static IMongoCollection<BusinessLog> Coll;
        private static string GetJson<T>(FilterDefinition<T> filterDefinition)
        {
            if (filterDefinition is null) return null;
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<T>();
            return filterDefinition.Render(documentSerializer, serializerRegistry).ToJson();
        }
        private static string GetJson<T>(UpdateDefinition<T> updateDefinition)
        {
            if (updateDefinition is null) return null;
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<T>();
            return updateDefinition.Render(documentSerializer, serializerRegistry).ToJson();
        }
    }
}
