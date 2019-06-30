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
        public ActionResult <List<EventsFields>> Get()
        {
            return apiquerry.GetAllEvents().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<List<EventsFields>> GetById(int id)
        {
            return apiquerry.GetEventById(id).ToList();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        public ApiQuerry apiquerry = new ApiQuerry();

        [HttpGet]
        public ActionResult<List<Favorite>> Get()
        {
            return apiquerry.GetFavEvents().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Favorite>> GetById(int id)
        {
            return apiquerry.GetFavEventById(id).ToList();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        public ApiQuerry apiquerry = new ApiQuerry();

        [HttpGet]
        public ActionResult<List<ViewsHistory>> Get()
        {
            return apiquerry.GetAllViews().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<List<ViewsHistory>> GetById(int id)
        {
            return apiquerry.GetViewById(id).ToList();
        }
    }
}