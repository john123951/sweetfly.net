using MongoDB.Bson;
using System;

namespace SweetFly.Model.Entities.UserCracker
{
    /// <summary>
    /// 尝试账号
    /// </summary>
    public class userpassword
    {
        public ObjectId Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }
    }
}