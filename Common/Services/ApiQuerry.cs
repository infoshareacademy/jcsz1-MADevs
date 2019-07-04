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
                    PlaceName = x.PlaceName,
                    UrlsWww = x.Urls,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    DescLong = x.DescLong,
                    DescShort = x.DescShort,
                    TicketsType = x.TicketsType

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
                    PlaceName = x.PlaceName,
                    UrlsWww = x.Urls,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    DescLong = x.DescLong,
                    DescShort = x.DescShort,
                    TicketsType = x.TicketsType
                })
                .Where(x => x.Id == id)
                .ToList();

                return dbevents;
            }
        }

        public List<Favorite> GetFavEvents()
        {
            using (context)
            {
                List<Favorite> dbevents = context.ViewsHistory.Select(x => new Favorite()
                {
                    Id = x.EventId,

                }).ToList();

                return dbevents;
            }
        }

        public List<Favorite> GetFavEventById(int id)
        {
            using (context)
            {
                List<Favorite> dbevents = context.Events.Select(x => new Favorite()
                {
                    Id = x.EventId,
                })
                .Where(x => x.Id == id)
                .ToList();

                return dbevents;
            }
        }

        public List<ViewsHistory> GetAllViews()
        {
            using (context)
            {
                List<ViewsHistory> dbevents = context.ViewsHistory.Select(x => new ViewsHistory()
                {
                    Id = x.Id,
                    EventId = x.EventId,

                }).ToList();

                return dbevents;
            }
        }

        public List<ViewsHistory> GetViewById(int id)
        {
            using (context)
            {
                List<ViewsHistory> dbevents = context.Events.Select(x => new ViewsHistory()
                {
                    Id = x.Id,
                    EventId = x.EventId,
                })
                .Where(x => x.Id == id)
                .ToList();

                return dbevents;
            }
        }
    }
}
