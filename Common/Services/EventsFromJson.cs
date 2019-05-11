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
        public List<EventsFields> _eventsList = new List<EventsFields>();
        private readonly DataContext _context;

        public List<EventsFields> GetJson()
        {
            if (_eventsList.Count == 0)
            {
                var path = "https://planerkulturalny.pl/api/rest/events.json";
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(path);
                    _eventsList = JsonConvert.DeserializeObject<List<EventsFields>>(json);
                }
            }
            return _eventsList;
            
        }

        public EventsFields Create(EventsFields oneEvent)
        {
            oneEvent.Id = _eventsList.Count + 1;
            _eventsList.Add(oneEvent);
            return oneEvent;
        }

        public List<EventsFields> GetEventsByTicketType(string type)
        {
            if (type == "all")
            {
                var _all = GetJson();
                return _all;
            }
            else
            {
                var _filtered = _eventsList.Where(ticket => ticket.TicketsType.Contains(type)).ToList();
                return _filtered;
            }
        }

        public EventsFields GetEventById(int id)
        {
            return _eventsList.Single(events => events.Id == id);
        }

        public bool UpdateEvent(int id, EventsFields EventToUpdate)
        {
            var currentEvent = GetEventById(id);
            currentEvent.Name = EventToUpdate.Name;
            currentEvent.StartDate = EventToUpdate.StartDate;
            currentEvent.PlaceName = EventToUpdate.PlaceName;
            currentEvent.TicketsType = EventToUpdate.TicketsType;
            return true;
        }
    }
}
