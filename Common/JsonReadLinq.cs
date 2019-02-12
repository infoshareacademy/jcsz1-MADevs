using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureInGdansk
{
    public class JsonReadLinq
    {

        static public List<Events.Entry> GetEvents()
        {
            return JsonConvert.DeserializeObject<List<Events.Entry>>(File.ReadAllText("Events2.json"));
        }

        
    }
}
