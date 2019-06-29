using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCultureInGdansk.Models;
using Common;
using Common.Services;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace WebCultureInGdansk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventsFromJson _eventsList;
        public EventsFromDB _eventsListDb = new EventsFromDB();

        public HomeController(IEventsFromJson eventsList)
        {
            _eventsList = eventsList;
        }

        public IActionResult Index()
        {
            var items = _eventsList.GetJson();
            return View(items);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });

            return LocalRedirect(returnUrl);
        }

       
    }
}
