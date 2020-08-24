
using BL.MongoDB;
using MongoDB.Driver;

namespace models
{
    public class DbContext : BaseDbContext
    {
        public DbContext()         { }

        public IMongoCollection<Test1> Test1s => _database.GetCollection<Test1>("t1");
        public IMongoCollection<Test2> Test2s => _database.GetCollection<Test2>("t2");
    }
    public class Test1
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ESex Sex { get; set; }
    }
    public enum ESex
    { 
        GG=1,
        MM=0
    }
    public class Test2
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ESex Sex { get; set; }
    }
}
