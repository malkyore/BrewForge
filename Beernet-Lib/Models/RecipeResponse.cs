using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beernet_Lib.Models
{
    public class RecipeResponse
    {
        public RecipeStatistics recipeStats { get; set; }
        public string idString { get; set; }
        public Guid lastModifiedGuid { get; set; }
        string success { get; set; }
        string message { get; set; }
    }
}
