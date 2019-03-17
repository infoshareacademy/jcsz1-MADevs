using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using WebCultureInGdansk.Models;

namespace WebCultureInGdansk
{
    public class JsonGetParse
    {     

        public List<RootObject> JsonGet(string type)
        {
            var path = "https://planerkulturalny.pl/api/rest/events.json";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(path);
                List<RootObject> getData = JsonConvert.DeserializeObject<List<RootObject>>(json);
                List<RootObject> filtered = new List<RootObject>();


                if (type == "Darmowe")
                {
                    foreach (var item in getData)
                    {
                        if (item.tickets.type == "free")
                        {
                            filtered.Add(item);
                        }
                    }

                    return filtered;
                }
                if (type == "Płatne")
                {
                    foreach (var item in getData)
                    {
                        if (item.tickets.type == "tickets")
                        {
                            filtered.Add(item);
                        }
                    }

                    return filtered;
                }
                if (type == "Nie podano")
                {
                    foreach (var item in getData)
                    {
                        if (item.tickets.type == "unknown")
                        {
                            filtered.Add(item);
                        }
                    }

                    return filtered;
                }
                else
                {
                    return getData;
                }            
            }
            
        }
    }
}
