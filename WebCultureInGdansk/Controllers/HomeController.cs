using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCultureInGdansk.Models;
using Common;
using Common.Services;

namespace WebCultureInGdansk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventsFromJson _eventsList;

        public HomeController(IEventsFromJson eventsList)
        {
            _eventsList = eventsList;
        }

        //private EventsFromJson EventsList = new EventsFromJson();

        public IActionResult Index()
        {
            var items = _eventsList.GetJson();

            return View(items);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
