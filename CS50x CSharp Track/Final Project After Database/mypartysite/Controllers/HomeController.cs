using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mypartysite.Model;

namespace mypartysite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        public IActionResult Current()
        {
            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        public IActionResult ToDoLists()
        {
            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        [HttpPost]
        public IActionResult Register(Database Dbcontext)
        {   
            //Block for Registration Error Checking
            Microsoft.AspNetCore.Http.IFormCollection nvc = Request.Form; //source https://stackoverflow.com/questions/564289/read-post-data-submitted-to-asp-net-form
            string userName = "", password = "" , email = "";
            bool UNSet = false, PWSet = false, ESet = false;
            if (!string.IsNullOrEmpty(nvc["RegisterUsername"]))
            {
                userName = nvc["RegisterUsername"];
                UNSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["RegisterPassword"]))
            {
                if ( nvc["RegisterPassword"] == nvc["RegisterConfirmPassword"])
                {
                password = nvc["RegisterPassword"];
                PWSet = true;
                }
            }
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["RegisterEmail"]))
            {
                email = nvc["RegisterEmail"];
                ESet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }
            //End Registration Error Check Block

            if (UNSet && PWSet && ESet)
            {
                using (Dbcontext)
                {
                    var user = new Model.User(userName, password, email);
                    Dbcontext.Users.Add(user);
                    Dbcontext.SaveChanges();
                }
            }
            
            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return RedirectToAction("ToDoLists", "Home");
        }

        [HttpPost]
        public IActionResult Login()
        {

            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return RedirectToAction("ToDoLists", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
