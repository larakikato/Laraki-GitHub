using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mypartysite.Model;
using Newtonsoft.Json;

namespace mypartysite.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext DatabaseContext = new DatabaseContext();

        public bool isUserLoggedIn()
        {
            string LoggedInQ = "";
            try{
                LoggedInQ = HttpContext.Session.Get("LoggedInQ").ToString();
                if ( LoggedInQ == "True")
                {
                    ViewBag.LoggedInQ = "True";
                    ViewBag.UserName = HttpContext.Session.Get("UserName");
                    ViewBag.SecurityLevel = HttpContext.Session.Get("SecurityLevel");
                    ViewBag.UserID = HttpContext.Session.Get("UserID");
                    ViewBag.Email = HttpContext.Session.Get("Email");
                    return true;
                }
            } catch(System.NullReferenceException) {

                   LoggedInQ = "False";
            }

            if (LoggedInQ == "False"){
            
            ViewBag.LoggedInQ = "False";
            
            return false;
            
            }

            return false;
        }
        public IActionResult Index()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }
            else if ( Logged == true )
            {
                ViewBag.LoggedInQ = "True";
                ViewBag.UserName = HttpContext.Session.Get("UserName");
                ViewBag.SecurityLevel = HttpContext.Session.Get("SecurityLevel");
                ViewBag.UserID = HttpContext.Session.Get("UserID");
                ViewBag.Email = HttpContext.Session.Get("Email");
            }

            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        public IActionResult Current()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }
            else if ( Logged == true )
            {
                ViewBag.LoggedInQ = "True";
                ViewBag.UserName = HttpContext.Session.Get("UserName");
                ViewBag.SecurityLevel = HttpContext.Session.Get("SecurityLevel");
                ViewBag.UserID = HttpContext.Session.Get("UserID");
                ViewBag.Email = HttpContext.Session.Get("Email");
            }

            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        public IActionResult ToDoLists()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }
            else if ( Logged == true )
            {
                ViewBag.LoggedInQ = "True";
                ViewBag.UserName = HttpContext.Session.Get("UserName");
                ViewBag.SecurityLevel = HttpContext.Session.Get("SecurityLevel");
                ViewBag.UserID = HttpContext.Session.Get("UserID");
                ViewBag.Email = HttpContext.Session.Get("Email");
            }
            
            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        public IActionResult Success()
        {

            ViewBag.LoggedInQ = "True";

            return View();
        }

        [HttpPost]
        public IActionResult Register()
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

            
            if (UNSet == true && PWSet == true && ESet == true)
            {
                User newUser = new User(userName, password, email);

                DatabaseContext.Add(newUser);
                DatabaseContext.SaveChanges();
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            
            
            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return RedirectToAction("ToDoLists", "Home");
        }

        [HttpPost]
        public IActionResult Login()
        {
            Microsoft.AspNetCore.Http.IFormCollection nvc = Request.Form; //source https://stackoverflow.com/questions/564289/read-post-data-submitted-to-asp-net-form
            string userName = "", password = "";
            bool UNSet = false, PWSet = false;
            if (!string.IsNullOrEmpty(nvc["LoginUsername"]))
            {
                userName = nvc["LoginUsername"];
                UNSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["LoginPassword"]))
            {
                password = nvc["LoginPassword"];
                PWSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            bool userFound = false;
            
            if ( PWSet == true && UNSet == true )
            {
                User loggingIn = new User(userName, password);
                
                var users = DatabaseContext.Users.ToList();

                /*
                must use these methods to set cookies:
                HttpContext.Session.SetString("Name", "Mike");
                HttpContext.Session.SetInt32("Age", 21);
                 */

                foreach (User alpha in users)
                {
                    if ( alpha.UserName == loggingIn.UserName && alpha.Password == loggingIn.Password)
                    {
                        userFound = true;
                        HttpContext.Session.SetString("LoggedInQ", "True");
                        HttpContext.Session.SetString("UserName", alpha.UserName);
                        HttpContext.Session.SetString("SecurityLevel", alpha.securityLevel);
                        HttpContext.Session.SetInt32("UserID", alpha.UserId);
                        HttpContext.Session.SetString("Email", alpha.email);
                    }
                }
            
            }

            var LoggedInQ = HttpContext.Session.Get("LoggedInQ");
            string sLoggedInQ = Encoding.ASCII.GetString(LoggedInQ, 0, LoggedInQ.Length);
            ViewBag.LoggedInQ = sLoggedInQ;


            //these two lines are the holy grail of bullshit
            ViewBag.LoggedInQ = HttpContext.Session.Get("LoggedInQ");
            string what = Encoding.ASCII.GetString(ViewBag.LoggedInQ, 0, ViewBag.LoggedInQ.Length);
            
            //string What = BitConverter.ToString(ViewBag.LoggedInQ);
            ViewBag.UserName = HttpContext.Session.Get("UserName");
            ViewBag.SecurityLevel = HttpContext.Session.Get("SecurityLevel");
            ViewBag.UserID = HttpContext.Session.Get("UserID");
            ViewBag.Email = HttpContext.Session.Get("Email");

            if (userFound == true)
            {
               return RedirectToAction("Success", "Home");
            }
            else
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Logout()
        {

            //need to clear cookie
            HttpContext.Session.Clear();

           return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }
            else if ( Logged == true )
            {
                ViewBag.LoggedInQ = "True";
                ViewBag.UserName = HttpContext.Session.Get("UserName");
                ViewBag.SecurityLevel = HttpContext.Session.Get("SecurityLevel");
                ViewBag.UserID = HttpContext.Session.Get("UserID");
                ViewBag.Email = HttpContext.Session.Get("Email");
            }

            return View();
        }
    }
}

/*
i think our actual true false logic is fucked up like... my thing logged, is checking the wrong thing... like its checking if a user is logged in when it should check if theyre logged out or something
 */