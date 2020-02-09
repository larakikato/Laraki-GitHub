using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
