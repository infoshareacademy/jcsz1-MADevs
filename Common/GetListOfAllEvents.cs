using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public class GetListOfAllEvents
    {
        public IList<JToken> Events()
        {
            using (StreamReader jsonStream = new StreamReader("Events.json"))
            {
                string jsonFile = jsonStream.ReadToEnd();

                JObject events = JObject.Parse(jsonFile);
                IList<JToken> entry = events["result"]["entry"].Children().ToList();

                return entry;
            }
        }
    }
}