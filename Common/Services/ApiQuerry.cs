using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Services
{
    public class ApiQuerry
    {
        public DataContext context = new DataContext();

        public List<EventsFields> GetAllEvents()
        {
            using (context)
            {
                List<EventsFields> dbevents = context.Events.Select(x => new EventsFields()
                {
                    Id = x.EventId,
                    Name = x.Name,
                    PlaceName = x.PlaceName
                }).ToList();

                return dbevents;
            }
        }

        public List<EventsFields> GetEventById(int id)
        {
            using (context)
            {
                List<EventsFields> dbevents = context.Events.Select(x => new EventsFields()
                {
                    Id = x.EventId,
                    Name = x.Name,
                    PlaceName = x.PlaceName
                })
                .Where(x => x.Id == id)
                .ToList();

                return dbevents;
            }
        }

        public List<EventsFields> GetEventsViews()
        {
            using (context)
            {
                List<EventsFields> dbevents = context.Events.Select(x => new EventsFields()
                {
                    Id = x.EventId,
                    Name = x.Name,
                    PlaceName = x.PlaceName
                })
                .ToList();

                return dbevents;
            }
        }
    }
}
