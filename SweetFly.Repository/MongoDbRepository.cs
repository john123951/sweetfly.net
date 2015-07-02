using MongoDB.Driver;
using SweetFly.Model.Entities.UserCracker;
using SweetFly.Repository.contract;
using System.IO;
using System.Threading.Tasks;

namespace SweetFly.Repository
{
    public class MongoDbRepository : IUserCrackRepository
    {
        private readonly IMongoClient _client = new MongoClient("mongodb://localhost:27017");
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<userpassword> _collection;

        public MongoDbRepository()
        {
            _database = _client.GetDatabase("sweetDict");
            _collection = _database.GetCollection<userpassword>("userpassword");
        }

        private IAsyncCursor<userpassword> cursor = null;
        private readonly object _lock = new object();

        public async Task<userpassword> GetOne(int skip)
        {
            //var cursor = _collection.FindAsync(new JsonFilterDefinition<userpassword>("{}"), new FindOptions<userpassword>() { Limit = 1, Skip = skip }).Result.;

            var result = await _collection.Find(new JsonFilterDefinition<userpassword>("{}")).Limit(1).Skip(skip).FirstOrDefaultAsync();

            return result;

            //var hasNext = await cursor.MoveNextAsync();
            //if (!hasNext)
            //{
            //    return null;
            //}

            //return cursor.Current.FirstOrDefault();
        }

        public Task SaveSuccessUserInfo(CmrUserInfo entity)
        {
            var userInfoCollection = _database.GetCollection<CmrUserInfo>("CmrUserInfo");

            return userInfoCollection.InsertOneAsync(entity);
        }

        public async Task SavePosition(long position)
        {
            Task.Factory.StartNew(() =>
            {
                File.WriteAllText(@"E:\resource\position", position.ToString());
            });
            //var positionInfoCollection = _database.GetCollection<PositionInfo>("PositionInfo");

            ////positionInfoCollection.InsertOneAsync(new PositionInfo() { Position = 1 });
            ////db.PositionInfo.update({_id:ObjectId("5592738662e7df0dbc657776")},{Position:5})
            //string value = "{Position:" + position + "}";
            //positionInfoCollection.UpdateOneAsync(new JsonFilterDefinition<PositionInfo>("{_id:ObjectId(\"5592738662e7df0dbc657776\")"), new JsonUpdateDefinition<PositionInfo>(value));
        }
    }
}