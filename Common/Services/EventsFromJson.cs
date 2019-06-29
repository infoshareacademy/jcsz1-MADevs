using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Common.Models;
using Common.Services;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;
using System;

namespace Common
{
    public class EventsFromJson : IEventsFromJson
    {
        public List<EventsFields> _eventsList = new List<EventsFields>();
        //private readonly DataContext _context;
        //DataContext context = new DataContext();
        
        //private readonly Serilog.ILogger _log = Log.ForContext<IEventsFromJson>();
        
        public List<EventsFields> GetJson()
        {
            if (_eventsList.Count == 0)
            {
                var path = "https://planerkulturalny.pl/api/rest/events.json";

                try
                {                   
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString(path);
                        _eventsList = JsonConvert.DeserializeObject<List<EventsFields>>(json);

                    }
                }
                catch (Exception message)
                {
                    
                    Serilog.Log.Error(message.ToString());
                };
            }
            return _eventsList;
            
        }

        public EventsFields Create(EventsFields oneEvent)
        {
            Serilog.Log.Information("User added new event");
            _eventsList.Add(oneEvent);
            oneEvent.Id = _eventsList.Count + 1;           
            ;
            return oneEvent;
        }

        //public Event CretateToDB(Event oneEvent)
        //{
        //    using (_context)
        //    {
                
        //    }
        //}

        public List<EventsFields> GetEventsByTicketType(string type)
        {
            if (type == "all")
            {
                Serilog.Log.Information("User listed all events");
                var _all = GetJson();                
                return _all;
            }
            else
            {
                Serilog.Log.Information($"User listed events with {type} tickets", type);
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
            Serilog.Log.Information("User updated an event");
            var currentEvent = GetEventById(id);
            currentEvent.Name = EventToUpdate.Name;
            currentEvent.StartDate = EventToUpdate.StartDate;
            currentEvent.PlaceName = EventToUpdate.PlaceName;
            currentEvent.TicketsType = EventToUpdate.TicketsType;
            return true;
        }
    }
}
