using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beernet_Lib.Models
{
    public class yeastAddition
    {
        [BsonElement("additionGuid")]
        public string additionGuid { get; set; } = Guid.NewGuid().ToString();
        [BsonElement("yeast")]
        public yeast yeast { get; set; }
    }
}
