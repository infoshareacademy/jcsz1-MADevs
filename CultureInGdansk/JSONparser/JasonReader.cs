using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONparser
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader JasonStream = new StreamReader("Events.json"))
            {
                string JsonFile = JasonStream.ReadToEnd();

                JObject Events = JObject.Parse(JsonFile);
                IList<JToken> entry = Events["result"]["entry"].Children().ToList();
               
                Console.WriteLine("Place: " + entry[1]["place"]["name"]);
                Console.WriteLine("\nDetailed place: " + entry[1]["place"]["subname"]);
                Console.WriteLine("\nDate of event: " + entry[1]["startDate"]);
                Console.WriteLine("\nDate of event end: " + entry[1]["endDate"]);
                Console.WriteLine("\nDescription: " + entry[1]["descShort"]);

                Console.ReadLine();
            }

        }


    }
}
