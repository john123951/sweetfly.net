using MongoDB.Bson;

namespace SweetFly.Model.Entities.UserCracker
{
    public class PositionInfo
    {
        public ObjectId Id { get; set; }

        public long Position { get; set; }
    }
}