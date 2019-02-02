using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//namespace Common
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            using (StreamReader JasonStream = new StreamReader("Events.json"))
//            {
//                string JsonFile = JasonStream.ReadToEnd();

//                JObject Events = JObject.Parse(JsonFile);
//                IList<JToken> entry = Events["result"]["entry"].Children().ToList();
               
//                Console.WriteLine("Place: " + entry[2]["place"]["name"]);
//                Console.WriteLine("\nDetailed place: " + entry[2]["place"]["subname"]);
//                Console.WriteLine("\nDate of event: " + entry[2]["startDate"]);
//                Console.WriteLine("\nDate of event end: " + entry[2]["endDate"]);
//                Console.WriteLine("\nDescription: " + entry[2]["descShort"]);

//                Console.ReadLine();
//            }

//        }


//    }
//}
