using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Common.Models;

namespace Common
{
    public class EventsFromJson
    {
        public List<RootObject> GetJson()
        {
            var path = "https://planerkulturalny.pl/api/rest/events.json";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(path);
                List<RootObject> getData = JsonConvert.DeserializeObject<List<RootObject>>(json);
                return getData;
            }
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
    }
}
