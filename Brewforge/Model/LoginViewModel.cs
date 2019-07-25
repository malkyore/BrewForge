using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string errorMessage { get; set; }
    }
}