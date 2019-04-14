using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Common.Models;
using Common.Services;

namespace Common
{
    public class EventsFromJson : IEventsFromJson
    {
        public List<RootObject> _eventsList = new List<RootObject>();


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

        public List<RootObject> DisplayByTicketType(string type)
        {
            switch (type)
            {
                case "Darmowe":
                    return FilterByTicket("free");
                case "Płatne":
                    return FilterByTicket("tickets");
                case "Nie podano":
                    return FilterByTicket("unknown");
                default:
                    return GetJson();
            }
        }

        private List<RootObject> FilterByTicket(string type)
        {
            var getData = GetJson();

            List<RootObject> filtered = new List<RootObject>();

            foreach (var item in getData)
            {
                if (item.tickets.type == type)
                {
                    filtered.Add(item);
                }
            }
            return filtered;
        }

        public RootObject Create(RootObject oneEvent)
        {
            oneEvent.id = _eventsList.Count + 1;
            _eventsList.Add(oneEvent);
            return oneEvent;
        }
    }
}
