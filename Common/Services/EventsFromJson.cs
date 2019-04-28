using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Common.Models;
using Common.Services;

namespace Common
{
    public class EventsFromJson : IEventsFromJson
    {
        public List<RootObject> _eventsList = new List<RootObject>();
        private readonly DataContext _context;

        public List<RootObject> GetJson()
        {
            if (_eventsList.Count == 0)
            {
                var path = "https://planerkulturalny.pl/api/rest/events.json";
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(path);
                    _eventsList = JsonConvert.DeserializeObject<List<RootObject>>(json);
                }
            }
            return _eventsList;
        }

        public RootObject Create(RootObject oneEvent)
        {
            oneEvent.id = _eventsList.Count + 1;
            _eventsList.Add(oneEvent);
            return oneEvent;
        }

        public List<RootObject> GetEventsByTicketType(string type)
        {
            if (type == "all")
            {
                var _all = GetJson();
                return _all;
            }
            else
            {
                var _filtered = _eventsList.Where(ticket => ticket.tickets.type.Contains(type)).ToList();
                return _filtered;
            }
        }

        public RootObject GetEventById(int id)
        {
            return _eventsList.Single(events => events.id == id);
        }

        public bool UpdateEvent(int id, RootObject EventToUpdate)
        {
            var currentEvent = GetEventById(id);
            currentEvent.name = EventToUpdate.name;
            currentEvent.startDate = EventToUpdate.startDate;
            currentEvent.place.name = EventToUpdate.place.name;
            currentEvent.tickets.type = EventToUpdate.tickets.type;
            return true;
        }
    }
}
