using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Remotion.Linq.Parsing.ExpressionVisitors.TreeEvaluation;

namespace Common.Services
{
    public class EventsFromDB 
    {
        public DataContext context = new DataContext();
        public List<EventsFields> usersFavorite = new List<EventsFields>();

        public List<EventsFields> GetAllEvents()
        {
            using (context)
            {
                List <EventsFields> dbevents = context.Events.Select(x => new EventsFields()
                {
                    Id = x.EventId,
                    Name = x.Name,
                    PlaceName = x.PlaceName,
                    UrlsWww = x.Urls,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    DescLong = x.DescLong,
                    DescShort = x.DescShort,
                    TicketsType = x.TicketsType,
                }).ToList();

                return dbevents;
            }          
        }

        public List<EventsFields> GetFavorites(string id)
        {
            using (context)
            {
                var favorites = context.Favorites.Where(x => x.UserId == id).Select(y => y.EventId).ToList();
                var test = context.Events.Where(item => favorites.Contains(item.EventId)).ToList();

                foreach (var item in test)
                {
                    usersFavorite.Add(new EventsFields
                    {
                        Name = item.Name,
                        PlaceName = item.PlaceName,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        DescLong = item.DescLong,
                        DescShort = item.DescShort,
                        TicketsType = item.TicketsType
                    });
                }

                return usersFavorite;
            }
        }

        public void ViewAdd(int id)
        {
            context.ViewsHistory.Add(
                new ViewsHistory
                {       
                    EventId = id
                });
            context.SaveChanges();
        }
    }
}
