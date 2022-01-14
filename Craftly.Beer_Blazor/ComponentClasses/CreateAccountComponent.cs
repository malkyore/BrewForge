using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craftly.Beer_Blazor.ComponentClasses
{
    public class CreateAccountComponent : ComponentBase
    {
        [Inject]
        ProtectedSessionStorage ProtectedSessionStore { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        [Parameter] public EventCallback<string> changeVerb { get; set; }
        [Parameter] public EventCallback<string> userSettings { get; set; }

        string username;
        string email;
        string password;
        string confirmPassword;
        public bool isError { get; set; } = false;
        public string ErrorMessage { get; set; }

        public void ChangeUsername(Object args)
        {
            username = args.ToString();
        }

        public void ChangeEmail(Object args)
        {
            email = args.ToString();
        }

        public void ChangePassword(Object args)
        {
            password = args.ToString();
        }

        public void ChangeConfirmPassword(Object args)
        {
            confirmPassword = args.ToString();
        }

        public void backToLogin()
        {
            changeVerb.InvokeAsync(null);
            //refreshParent.InvokeAsync("");
        }
        public async void setSessionID(string sessionState)
        {
            ProtectedSessionStore.SetAsync("session", sessionState).ConfigureAwait(false);
        }

        public void CreateAccount()
        {
            ErrorMessage = "";
            if (password == confirmPassword)
            {
                string creationResponse = RecipeHelper.CreateAccount(username, email, password);

                var creationResponseMessage = SimpleJson.SimpleJson.DeserializeObject(creationResponse);

                if (creationResponseMessage.GetType() == typeof(string))
                {
                    string SessionState = RecipeHelper.Login(username, password);
                    isError = false;
                    setSessionID(SessionState);
                    userSettings.InvokeAsync(username);
                    refreshParent.InvokeAsync("");
                }
                else
                {
                    //its probably errors
                    IList<object> creationResponseObject = (IList<object>)creationResponseMessage;

                    if (creationResponseObject.Count() > 0)
                    {
                        isError = true;
                        foreach (var i in creationResponseObject)
                        {
                            IDictionary<string, object> creationResponseItem = (IDictionary<string, object>)i;
                            object error = "";
                            creationResponseItem.TryGetValue("Description", out error);
                            ErrorMessage += "" + error + " ";
                        }
                    }
                }
            }
            else
            {
                isError = true;
                ErrorMessage = "Passwords do not match";
            }
        }
    }
}
