using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCultureInGdansk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common;
using Common.Models;
using Common.Services;

namespace WebCultureInGdansk.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsFromJson _eventsList;

        public EventsController(IEventsFromJson eventsList)
        {
            _eventsList = eventsList;
        }

        // GET: Events
        [HttpGet]
        public IActionResult Index()
        {
            var result = _eventsList.GetJson();
            return View(result);
        }

        // GET: Events/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // Get: Events/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        public IActionResult Create(RootObject oneEvent)
        {
            RootObject events = _eventsList.Create(oneEvent);
            return RedirectToAction("Index");
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByName(string searchString)
        {
                var result = _eventsList.GetJson();

                if (!String.IsNullOrEmpty(searchString))
                {
                    result = result.Where(s => s.name.Contains(searchString)).ToList();
                }
                return View(result);
        }
    }
}