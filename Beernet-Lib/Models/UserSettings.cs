using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beernet_Lib.Models
{
    public class userSettings
    {
        [BsonElement("userID")]
        public string userID { get; set; }
        [BsonElement("firstName")]
        public string firstName { get; set; }
        [BsonElement("lastName")]
        public string lastName { get; set; }
        [BsonElement("theme")]
        public string theme { get; set; }
        [BsonElement("userCreatedDate")]
        public DateTimeOffset userCreatedDate { get; set; }
    }
}
