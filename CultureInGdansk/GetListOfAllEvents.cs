using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CultureInGdansk
{
    class GetListOfAllEvents
    {

        public IList<JToken> Events()
        {
            using (StreamReader JsonStream = new StreamReader("Events.json"))
            {
                string JsonFile = JsonStream.ReadToEnd();

                JObject Events = JObject.Parse(JsonFile);
                IList<JToken> entry = Events["result"]["entry"].Children().ToList();

                return entry;
            }

        }

    }
}