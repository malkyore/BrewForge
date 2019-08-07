using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beernet_Lib.Models
{
    public class BrewlogIngredientAddition
    {
        [BsonElement("additionGuid")]
        public Guid additionGuid;
        [BsonElement("time")]
        public DateTimeOffset time;
        [BsonElement("amount")]
        public double amount;
    }
}
