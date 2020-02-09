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

            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

            //Acquire user ID for updating event
            var UserID = HttpContext.Session.Get("UserID");
            string sUserID = Encoding.ASCII.GetString(UserID, 0, UserID.Length);
            ViewBag.UserID = sUserID;

            Microsoft.AspNetCore.Http.IFormCollection nvc = Request.Form; //source https://stackoverflow.com/questions/564289/read-post-data-submitted-to-asp-net-form
            
            //values for object initialization
            string eventName = "", eventDate = "" , venueName = "", venueAddress= "", 
            venueUnspecified = "", eventDescription = "", eventNumOfGuest="", eventComments="", floorPlanSpecified="",
            liveEntertainment = "", eventStage = "", eventAudio = "", eventVideo = "";
            
            //controls - the commented out ones are not used for initializations in the current state of application
            bool ENSet = false, EDateSet = false, VNSet = false, VASet = false, 
            /* VUSet = false, */ EDescSet = false, ENogSet = false, ECSet = false, /* FSSet = false, */
            /*LESet = false, */ EStageSet = false, EASet = false, EVSet = false; 

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
                //VUSet = true;
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
                //FSSet = true;
            }
            else
            {
                RedirectToAction("Error", "Home");
            }

            if (!string.IsNullOrEmpty(nvc["LiveEntertainment"]))
            {
                liveEntertainment = nvc["LiveEntertainment"];
                //LESet = true;
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

            if (ENSet == true && EDateSet == true && VNSet == true && VASet == true && 
                EDescSet == true && ENogSet == true && ECSet == true && 
                EStageSet == true && EASet == true && EVSet == true)
            {
                Event newEvent = new Event(eventName, eventDate, venueName, venueAddress,
                eventDescription, eventComments, eventNumOfGuest, eventStage, eventAudio, eventVideo, sUserID);

                DatabaseContext.Add(newEvent);
                DatabaseContext.SaveChanges();
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

            //Acquire user ID for updating event
            var UserID = HttpContext.Session.Get("UserID");
            string sUserID = Encoding.ASCII.GetString(UserID, 0, UserID.Length);
            ViewBag.UserID = sUserID;
            int userID = 0;
            Int32.TryParse(sUserID, out userID);

            var obj = DatabaseContext.Events;
            Event eventRequested = null;

            foreach (var alpha in obj)
            {
                if (alpha.CustomerReference == userID )
                {
                    eventRequested = alpha;
                }
            }

            try{
            ViewBag.Accepted = eventRequested.AcceptedQ;
            ViewBag.EventName = eventRequested.Name;
            }
            catch (System.NullReferenceException)
            {
                return RedirectToAction("NothingToShow", "Home");
            }

            return View();
        }

        public IActionResult NothingToShow()
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

            //obtain security level of logged in user
            var SecurityLevel = HttpContext.Session.Get("SecurityLevel");
            string sSecurityLevel = Encoding.ASCII.GetString(SecurityLevel, 0, SecurityLevel.Length);
            ViewBag.SecurityLevel = sSecurityLevel;

            var isUserAdmin = sSecurityLevel;
            if (isUserAdmin != "admin")
            {
                return RedirectToAction("Error", "Home");
            }

            List<Event> forView = new List<Event>();

            Microsoft.EntityFrameworkCore.DbSet<Event> table = DatabaseContext.Events;

            foreach (var alpha in table)
            {
                if (alpha.AcceptedQ == "Awaiting Approval" || alpha.AcceptedQ == "Denied")
                {
                    forView.Add(alpha);
                }
            }

            ViewData["EventTable"] = forView;

            return View();
        }

        [HttpPost]
        public IActionResult EventRequestsPost()
        {
            //logged in / out checking
            bool Logged = isUserLoggedIn();
            if (Logged == false)
            {
                ViewBag.LoggedInQ = "False";
            }

            //obtain security level of logged in user
            var SecurityLevel = HttpContext.Session.Get("SecurityLevel");
            string sSecurityLevel = Encoding.ASCII.GetString(SecurityLevel, 0, SecurityLevel.Length);
            ViewBag.SecurityLevel = sSecurityLevel;

            var isUserAdmin = sSecurityLevel;
            if (isUserAdmin != "admin")
            {
                return RedirectToAction("Error", "Home");
            }

            Microsoft.AspNetCore.Http.IFormCollection nvc = Request.Form;
            string result = "";
            //bool? accepted = null, denied = null;

            if (!string.IsNullOrEmpty(nvc["Accepted"]))
            {
                result = nvc["Accepted"];
                //accepted = true;
            }
            if (!string.IsNullOrEmpty(nvc["Denied"]))
            {
                result = nvc["Denied"];
                //denied = true;
            }
            if (!string.IsNullOrEmpty(nvc["Awaiting Approval"]))
            {
                result = nvc["Awaiting Approval"];
            }
            if (!string.IsNullOrEmpty(nvc["Delete"]))
            {
                result = nvc["Delete"];
            }

            Event toUpdate = new Event();

            var table = DatabaseContext.Events;

            foreach (Event alpha in table)
            {
                if (alpha.Name == nvc["EventName"])
                {
                    toUpdate = alpha;
                }
            }

            /* DatabaseContext.Update(toUpdate).Member(toUpdate.AcceptedQ).EntityEntry. */

            if ( result == "Accepted") //implementation source: https://stackoverflow.com/questions/3642371/how-to-update-only-one-field-using-entity-framework
            {
                toUpdate.AcceptedQ = "Accepted";

                DatabaseContext.Events.Attach(toUpdate);
                DatabaseContext.Entry(toUpdate).Property( x => x.AcceptedQ).IsModified = true;
                DatabaseContext.SaveChanges();
            }
            else if ( result == "Denied")
            {
                toUpdate.AcceptedQ = "Denied";

                DatabaseContext.Events.Attach(toUpdate);
                DatabaseContext.Entry(toUpdate).Property( x => x.AcceptedQ).IsModified = true;
                DatabaseContext.SaveChanges();
            }
            else if (result == "Delete")
            {
                DatabaseContext.Events.Remove(toUpdate);
                DatabaseContext.SaveChanges();
            }
            else if (result == "Awaiting Approval")
            {
                toUpdate.AcceptedQ = "Awaiting Approval";

                DatabaseContext.Events.Attach(toUpdate);
                DatabaseContext.Entry(toUpdate).Property( x => x.AcceptedQ).IsModified = true;
                DatabaseContext.SaveChanges();
            }


            return RedirectToAction ("EventRequests", "Home");
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