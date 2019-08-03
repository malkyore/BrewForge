using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Beernet_Lib.Tools;
using Brewforge;
using Brewforge.Controllers;
using Brewforge.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewForge.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IOptions<AppSettings> settings, IHostingEnvironment env) : base(settings)
        {

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        public IActionResult Login(LoginViewModel returnModel)
        {
            var values = new Dictionary<string, string>
            {
               { "Username", "" + returnModel.username},
               { "Password", "" + returnModel.password }
            };
            string token = Auth.getAPIAuthToken(AppSettings.apiLink, AppSettings.loginEndpoint, values).Replace("\"", "");
            if(token == "error")
            {
                returnModel.password = "";
                returnModel.errorMessage = "Invalid Credentials";
                return View("Index",returnModel);
            }
            else
            {
                userSettings settings = DataAccess.getUserSettings(token, AppSettings.apiLink);
                AppSettings.apiAuthToken = token;
                AppSettings.userSettings = settings;
                return RedirectToAction("Dashboard", "Home");
            }
        }

        public IActionResult Logout(LoginViewModel returnModel)
        {
                AppSettings.apiAuthToken = "";
                return RedirectToAction("Dashboard", "Home");
        }
    }
}
