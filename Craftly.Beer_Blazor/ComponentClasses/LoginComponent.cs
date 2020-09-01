using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;
using Beernet_Lib.Tools;

namespace Craftly.Beer_Blazor.ComponentClasses
{
    public class LoginComponent : ComponentBase
    {
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        public bool isError { get; set; } = false;
        public string ErrorMessage { get; set; }
        private string Username { get; set; }

        private string Password { get; set; }

        public void ChangeUsername(Object args)
        {
            Username = args.ToString();
        }

        public void ChangePassword(Object args)
        {
            Password = args.ToString();
        }

        public void Login()
        {
            isError = !RecipeHelper.Login(Username, Password);
            ErrorMessage = "FAILED AS SHIT DOG";

            if(!isError)
            {
                refreshParent.InvokeAsync("");
            }
        }
    }
}
