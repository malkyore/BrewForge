//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beernet_Lib.Models
{
    public class recipe
    {
        [BsonId]
        public string id { get; set; }
        //public id id { get; set; }
        public string idString
        {
            get; set;
        }
      //  [BsonElement("name")]
        public string name { get; set; }
      //  [BsonElement("style")]
        public string style { get; set; }
      //  [BsonElement("description")]
        public string description { get; set; }
      //  [BsonElement("recipeStats")]
        public RecipeStatistics recipeStats { get; set; }
     //   [BsonElement("recipeParameters")]
        public RecipeParameters recipeParameters { get; set; }
      //  [BsonElement("version")]
        public double version { get; set; }
      //  [BsonElement("parentRecipe")]
        public string parentRecipe { get; set; }
      //  [BsonElement("clonedFrom")]
        public string clonedFrom { get; set; }
       // [BsonElement("hidden")]
        public string hidden { get; set; }
      //  [BsonElement("hops")]
        public List<hopAddition> hops { get; set; }
      //  [BsonElement("fermentables")]
        public List<fermentableAddition> fermentables { get; set; }
      //  [BsonElement("yeasts")]
        public List<yeast> yeasts { get; set; }
      //  [BsonElement("adjuncts")]
        public List<adjunctAddition> adjuncts { get; set; }
      //  [BsonElement("styleID")]
        public string styleID { get; set; }
        
    }

}
