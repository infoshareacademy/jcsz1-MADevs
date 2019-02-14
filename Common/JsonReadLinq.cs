using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    public class JsonReadLinq
    {
        public static List<Events.Entry> GetEvents()
        {
            return JsonConvert.DeserializeObject<List<Events.Entry>>(File.ReadAllText("Events2.json"));
        }
    }
}
