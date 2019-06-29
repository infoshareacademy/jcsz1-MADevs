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
using System.Text.RegularExpressions;
using Microsoft.Extensions.Localization;

namespace WebCultureInGdansk.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsFromJson _eventsList;
        public EventsFromDB _eventsListDb = new EventsFromDB();


        public EventsController(IEventsFromJson eventsList)
        { 
            _eventsList = eventsList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //_dbContext.SaveChanges();
  
            var result = _eventsListDb.GetAllEvents();
            return View(result);
        }

        public IActionResult Favorite()
        {
            return View();
        }

        // GET: Events/Details/5
        public IActionResult Details(int id)
        {
 
            var result = _eventsList.GetEventById(id);
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventsFields oneEvent)
        {
            if (ModelState.IsValid)
            {
                EventsFields events = _eventsList.Create(oneEvent);
                return RedirectToAction("Index");
            }
            return View(oneEvent);
        }

        public IActionResult Edit(int id)
        {
            var eventtoupdate = _eventsList.GetEventById(id);
            return View(eventtoupdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EventsFields eventtoupdate)
        {
            _eventsList.UpdateEvent(id, eventtoupdate);
            return RedirectToAction(nameof(Index));
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
        public IActionResult TicketFilter(string type)
        {
            var result = _eventsList.GetEventsByTicketType(type);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByName(string searchString)
        {
            var result = _eventsList.GetJson();
            if (!String.IsNullOrEmpty(searchString))
            {
                    
                       result = result
                        
                        .Where(s => s.Name.ToLower().Contains(searchString) || 
                                    s.Name.ToUpper().Contains(searchString) ||
                                    s.Name.Contains(searchString))
                                    .ToList();
            }

            return View(result);
        }
    }
}