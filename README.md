BL.MongoDB based MongoDB C# Driver
=================

A sample useful MongoDB Driver Helper.Only rely MongoDB.Driver.Include function below:
* 1.BaseDbContext.cs:you can create your DbContext inherit BaseDbContext
*    package some useful mongodb-to-C# mapping,like ObjectId&lt;=&gt;string,UTC&lt;=&gt;LocalTime,Enum&lt;=&gt;string,property name to camel field..etc
* 2.can get ConnetionString from env "CONNECTIONSTRINGS_MONGO" in docker container or "ConnectionStrings.Mongo" in appsettings.json:
* 3.BsonDocumentExtends.cs:
*    extend method to BsonValue,for example: var bs={info:{gender:{k:'01',v:'Man'}}} . we can get "Man" through bs.GetValueByHierarchicalNames("info.gender.v")
* 4.you can simply using BL.MongoDB.Gen's AddBLMongoDbContext method in ConfigureServices(startup.cs) to create your DbContext


Getting Started
---------------
### consider your solution structure as follow

* Example.API : .NET Core 3.1 Web Api
* Example.Infrasetructure  : .NET Standard 2.1 dll
* Example.Domain : .NET Standard 2.1 dll

### Configure mongodb connection string use one of these two

* 1. configure in appsettings.json
```json
ConnectionStrings:{
    "Mongo":"mongodb://uname:pwd@127.0.0.1:27017/yourdb?authSource=admin&serverSelectionTimeoutMS=1000"
}
```
* 2. set in docker env,like docker-compose.yml
```docker-compose
 example_api:
     environment:
       - TZ=Asia/Shanghai
       - CONNECTIONSTRINGS_MONGO=mongodb://uname:pwd@127.0.0.1:27017/yourdb?authSource=admin&serverSelectionTimeoutMS=1000
       - ASPNETCORE_ENVIRONMENT=Development
       - ASPNETCORE_URLS=http://+:80
     ports:
       - 10002:80
```

### Install Package use Nuget Package Manager

* packages:
*   BL.MongoDB  : install on Example.Infrasetructure
*  BL.MongoDB.Gen  : install on Example.API

### Create your Model in Example.Domain

```C#
public class Person
{
    public string Id { get; set; }//notice,this Id is string and will store to db use string type
    public string Name { get; set; }
}
public class Cat
{
    public string Id { get; set; }//notice,this Id is string and will store to db use ObjectId type
    public string Name { get; set; }
}
```

### Create your DbContext in Example.Infrasetructure

nomally,this project only need one Class : DbContext

```C#
using BL.MongoDB;
using MongoDB.Driver;
```

```C#

    public class DbContext : BaseDbContext
    {
        public DbContext() { }

        public IMongoCollection<Person> Persons => _database.GetCollection<Person>("persons");
        public IMongoCollection<Cat> Cats => _database.GetCollection<Cat>("cats");
    }
}
```

### Create your DbContext instance in Example.API

ConfigureServices in Startup.cs

```C#
  services.AddBLMongoDbSet<DbContext>(Configuration,option=> {
       option.AddNotConvertObjectIdToStringTypes(typeof(Person));//if you want use your own value as mongodb _id,you can add that class type at here.
  });
```
notice: we set Person do not use string<=>ObjectId mapping .And the Cat type is still use default mapping(string<=>ObjectId)

### use your DbContext instance in Controllers

```C#
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController(DbContext db) { this.db = db; }
        private DbContext db;
        
        [HttpGet("{id}")]
        public Person Get(string id)
        {
            return db.Persons.Find(x => x.Id == id).SingleOrDefault() ?? throw new Exception("no data find");
        }
        
        [HttpPost("Test")]
        public void Test()
       ｛
          var person=new Person{ Id="dengjie guo 34253019871205" ,Name="dengjie guo" };
          db.Persons.InsertOne(person);//{_id:"dengjie guo 34253019871205",name:"dengjie guo"} in db
          //
          var cat=new Cat{ Name = "black cat" };
          db.Cats.InsertOne(cat); //{ _id:ObjectId("5f3b70baf27afd2fb146cb0d"),name:"black cat"} in db
        ｝
    }
```

### Maintainers:
* dengjie guo               315297830@qq.com

