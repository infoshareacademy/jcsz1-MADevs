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
        public ApiQuerry apiquerry = new ApiQuerry();

        [HttpGet]
        public ActionResult<List<EventsFields>> GetAll()
        {
            return apiquerry.GetAllEvents().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<List<EventsFields>> GetById(int id)
        {
            return apiquerry.GetEventById(id).ToList();
        }

        [HttpGet("{favorites}")]
        public ActionResult<List<EventsFields>> GetFavorites()
        {
            return apiquerry.GetFavorites().ToList();
        }
    }
}