﻿//using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beernet_Lib.Models
{
    public class yeast
    {
       // [BsonElement("idString")]
        public string idString { get; set; }
      //  [BsonElement("name")]
        public string name { get; set; }
       // [BsonElement("lab")]
        public string lab { get; set; }
       // [BsonElement("attenuation")]
        public float attenuation { get; set; }
    }
}
