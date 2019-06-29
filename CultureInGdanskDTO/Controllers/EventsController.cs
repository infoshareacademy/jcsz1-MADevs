using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace CultureInGdanskDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public EventsFromDB context = new EventsFromDB();

        [HttpGet]
        public ActionResult<List<EventsFields>> Get()
        {
            return context.GetAllEvents().ToList();
        }
        public ActionResult<List<EventsFields>> Get(int id)
        {
            var result = context.GetEventById(id).ToList();
            return result;
        }
    }
}