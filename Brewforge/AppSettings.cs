using Beernet_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewforge
{
    public class AppSettings
    {
        public string apiLink { get; set; }
        public string recipeEndpoint { get; set; }
        public string loginEndpoint { get; set; }
        public string apiAuthToken { get; set; }
        public userSettings userSettings { get; set; }
    }
}
