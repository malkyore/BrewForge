﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;
using Beernet_Lib.Tools;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ProtectedBrowserStorage;

namespace Craftly.Beer_Blazor.ComponentClasses
{
    public class LoginComponent : ComponentBase
    {
        [Inject] 
        ProtectedSessionStorage ProtectedSessionStore { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        public bool isError { get; set; } = false;
        public string ErrorMessage { get; set; }
        private string Username { get; set; }

        private string state { get; set; } = "";
        private string Password { get; set; }

        public void ChangeUsername(Object args)
        {
            Username = args.ToString();
        }

        public void ChangePassword(Object args)
        {
            Password = args.ToString();
        }

        public async  void setSessionID(string sessionState)
        {
            ProtectedSessionStore.SetAsync("session", sessionState).ConfigureAwait(false);
        }

        ValueTask<string> getSessionID()
        {
            string session = "";
            return ProtectedSessionStore.GetAsync<string>("session");
        }

        public async void Login()
        {
            string SessionState = RecipeHelper.Login(Username, Password);

            if(SessionState != "false")
            {
                isError = false;
                setSessionID(SessionState);
                string test = await getSessionID();
                string sesh = state;
            }
            else
            {
                isError = true;
            }
            ErrorMessage = "FAILED AS SHIT DOG";

            if(!isError)
            {
                refreshParent.InvokeAsync("");
            }
        }
    }
}
