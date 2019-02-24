using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static Common.Events;

namespace Common
{
    public class JsonReadLinq
    {
        public IEnumerable<Entry> GetEvents()
        {

            

            return JsonConvert.DeserializeObject<IEnumerable<Entry>>(File.ReadAllText("Events.json"));
        }
    }
}
