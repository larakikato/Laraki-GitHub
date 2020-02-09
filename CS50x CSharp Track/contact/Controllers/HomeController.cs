using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using contact.Model;

namespace contact.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ContactPost(message mess)
        {

            message curr = new message();

            List<message> contactMessages = new List<message>();

            contactMessages.Add(mess);

             curr = contactMessages.Last();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
