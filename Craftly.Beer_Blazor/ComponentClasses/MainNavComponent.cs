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
    public class MainNavComponent : ComponentBase
    {
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        public void logout()
        {
            RecipeHelper.Logout();
        }

        public static bool isLoggedIn()
        {
            return RecipeHelper.isLoggedIn;
        }
    }
}
