using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebCultureInGdansk.Controllers
{
    public class AdminController : Controller
    {
        public ApiService  raports = new ApiService();
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Raport()
        {
            var result = raports.ViewsFromApi();
            return View(result);
        }
    }
}