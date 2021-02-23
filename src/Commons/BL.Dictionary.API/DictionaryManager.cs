using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BL.Dictionary
{
    public class DictionaryManager
    {
        private IMongoCollection<DictionaryItem> Coll { get; set; }
        public void SetTable(IMongoDatabase db, string table)
        {
            Coll = db.GetCollection<DictionaryItem>(table);
        }

        public void Post(DictionaryItem dto)
        {
            if (string.IsNullOrWhiteSpace(dto.K) || string.IsNullOrWhiteSpace(dto.V) || string.IsNullOrWhiteSpace(dto.Type)) throw new("k,v,type cant be null");
            if (Coll.CountDocuments(x => x.Type == dto.Type && (x.K == dto.K || x.V == dto.V)) > 0) throw new("this item already exist");
            Coll.InsertOne(dto);
        }
        public void Put(DictionaryItem dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Id)) throw new("id cant be null");
            var obj = Coll.Find(x => x.Id == dto.Id).SingleOrDefault();
            if (obj is null) throw new("id is not correct");
            if (obj.Type != dto.Type) throw new("type cant be modified");
            if (string.IsNullOrWhiteSpace(dto.K) || string.IsNullOrWhiteSpace(dto.V) || string.IsNullOrWhiteSpace(dto.Type)) throw new("k,v,type cant be null");
            if (Coll.CountDocuments(x => x.Id != dto.Id && x.Type == dto.Type && (x.K == dto.K || x.V == dto.V)) > 0) throw new("this item already exist");
            obj.K = dto.K;
            obj.V = dto.V;
            obj.Order = dto.Order;
            obj.Desc = dto.Desc;
            _ = Coll.ReplaceOne(x => x.Id == dto.Id, obj);
        }

        public DictionaryItem Get(string id)
        {
            return Coll.Find(x => x.Id == id).SingleOrDefault() ?? throw new("id is not correct");
        }

        public void Delete(string id)
        {
            _ = Coll.DeleteOne(x => x.Id == id);
        }

        public List<DictionaryItem> GetByType(string type)
        {
            return Coll.Find(x => x.Type == type).SortBy(x => x.Order).ToList();
        }

        public Dictionary<string, List<DictionaryItemKV>> GetByTypes(params string[] types)
        {
            var query = Coll.Aggregate().Match(x => types.Contains(x.Type));
            var list = query.Group(x => x.Type, g => new { g.Key, Items = g.Select(x => new DictionaryItemKV { K = x.K, V = x.V }) }).ToList();
            var dics = list.ToDictionary(x => x.Key, x => x.Items.ToList());
            return dics;
        }
        public IEnumerable<object> GetStatus()
        {
            return Coll.Aggregate().Group(x => x.Type, g => new { g.Key, ItemsCount = g.Sum(x => 1) }).ToList();
        }
    }
}
