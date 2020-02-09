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
            string check = "";

            try {
            var LoggedInQ = HttpContext.Session.Get("LoggedInQ");
            string sLoggedInQ = Encoding.ASCII.GetString(LoggedInQ, 0, LoggedInQ.Length);
            ViewBag.LoggedInQ = sLoggedInQ;

            var UserName = HttpContext.Session.Get("UserName");
            string sUserName = Encoding.ASCII.GetString(UserName, 0, UserName.Length);
            ViewBag.UserName = sUserName;

            var SecurityLevel = HttpContext.Session.Get("SecurityLevel");
            string sSecurityLevel = Encoding.ASCII.GetString(SecurityLevel, 0, SecurityLevel.Length);
            ViewBag.SecurityLevel = sSecurityLevel;

            var UserID = HttpContext.Session.Get("UserID");
            string sUserID = Encoding.ASCII.GetString(UserID, 0, UserID.Length);
            ViewBag.UserID = sUserID;

            var Email = HttpContext.Session.Get("Email");
            string sEmail = Encoding.ASCII.GetString(Email, 0, Email.Length);
            ViewBag.Email = sEmail;
            }
            catch(System.NullReferenceException) {

                return false;
                
            }

            check = ViewBag.LoggedInQ;
            if (check == "True")
            {
                    return true;
            }
            else
            return false;
        }
        public IActionResult Index()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        public IActionResult RequestEvent() // this is for user to fill out request
        {
            //logged in / out checking
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

            //todo

            return View();
        }

        [HttpPost]
        public IActionResult RequestEventPost() //user submit request should handle post
        {

            Microsoft.AspNetCore.Http.IFormCollection nvc = Request.Form; //source https://stackoverflow.com/questions/564289/read-post-data-submitted-to-asp-net-form
            
            //values for object initialization
            string eventName = "", eventDate = "" , venueName = "", venueAddress= "", 
            venueUnspecified = "", eventDescription = "", eventNumOfGuest="", eventComments="", floorPlanSpecified="",
            liveEntertainment = "", eventStage = "", eventAudio = "", eventVideo = "";
            
            //controls
            //bool UNSet = false, PWSet = false, ESet = false;
            bool ENSet = false, EDateSet = false, VNSet = false, VASet = false, 
            VUSet = false, EDescSet = false, ENogSet = false, ECSet = false, FSSet = false,
            LESet = false, EStageSet = false, EASet = false, EVSet = false; 

            //logic camelCase strings are to hold values the other case names are corresponding to name field in cshtml
            if (!string.IsNullOrEmpty(nvc["EventName"]))
            {
                eventName = nvc["EventName"];
                ENSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["EventDate"]))
            {
                eventDate = nvc["EventDate"];
                EDateSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["VenueName"]))
            {
                venueName = nvc["VenueName"];
                VNSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["VenueAddress"]))
            {
                venueAddress = nvc["VenueAddress"];
                VASet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["VenueUnspecified"]))
            {
                venueUnspecified = nvc["VenueUnspecified"];
                VUSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["EventDescription"]))
            {
                eventDescription = nvc["EventDescription"];
                EDescSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["EventNumOfGuest"]))
            {
                eventNumOfGuest = nvc["EventNumOfGuest"];
                ENogSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["EventComments"]))
            {
                eventComments = nvc["EventComments"];
                ECSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["FloorplanSpecified"]))
            {
                floorPlanSpecified = nvc["FloorplanSpecified"];
                FSSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["LiveEntertainment"]))
            {
                liveEntertainment = nvc["LiveEntertainment"];
                LESet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["EventStage"]))
            {
                eventStage = nvc["EventStage"];
                EStageSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["EventAudio"]))
            {
                eventAudio = nvc["EventAudio"];
                EASet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["EventVideo"]))
            {
                eventVideo = nvc["EventVideo"];
                EVSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            return RedirectToAction("RequestStatus", "Home");
        }

        public IActionResult RequestStatus() //user can see if request accepted
        {
            //logged in /out checking
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

            return View();
        }
        public IActionResult EventRequests() //this is the administrator one to view requests and approve them just list each request, with a button for approval/denial, and status approved denied, denied get removed from this page
        {
            //logged in / out checking
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

            //todo

            return View();
        }

        public IActionResult Current()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
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
            
            var context = new mypartysite.Model.Current();
            var currEvent = context.initialize();

            return View(currEvent);
        }

        public IActionResult LoginSuccess()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

            return View();
        }

        public IActionResult RegisterSuccess()
        {
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

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

            return RedirectToAction("RegisterSuccess", "Home");
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

            var UserName = HttpContext.Session.Get("UserName");
            string sUserName = Encoding.ASCII.GetString(UserName, 0, UserName.Length);
            ViewBag.UserName = sUserName;

            var SecurityLevel = HttpContext.Session.Get("SecurityLevel");
            string sSecurityLevel = Encoding.ASCII.GetString(SecurityLevel, 0, SecurityLevel.Length);
            ViewBag.SecurityLevel = sSecurityLevel;

            var UserID = HttpContext.Session.Get("UserID");
            string sUserID = Encoding.ASCII.GetString(UserID, 0, UserID.Length);
            ViewBag.UserID = sUserID;

            var Email = HttpContext.Session.Get("Email");
            string sEmail = Encoding.ASCII.GetString(Email, 0, Email.Length);
            ViewBag.Email = sEmail;


            if (userFound == true)
            {
               return RedirectToAction("LoginSuccess", "Home");
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

            return View();
        }
    }
}

/*
i think our actual true false logic is fucked up like... my thing logged, is checking the wrong thing... like its checking if a user is logged in when it should check if theyre logged out or something
 */