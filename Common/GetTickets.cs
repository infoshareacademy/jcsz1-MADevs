using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public class GetTickets
    {
        public IList<JToken> Events()
        {
            using (StreamReader jsonStream = new StreamReader("Events.json"))
            {
                string jsonFile = jsonStream.ReadToEnd();

                JObject events = JObject.Parse(jsonFile);
                IList<JToken> entry = events["result"]["entry"].Children().ToList();

                object[] tickets = new object[entry.Count];

                return entry;
        

                //    ConsoleKeyInfo userInput;

                //    do
                //    {
                //        userInput = Console.ReadKey();
                ////        Console.ReadLine();
                //       switch (index)
                //       {
                //           case "1":

                //            Console.Clear();
                //            for (int i = 0; i < entry.Count; i++)
                //            {
                //                tickets[i] = entry[i]["tickets"]["type"];

                //                if (tickets[i].ToString() == "free")
                //                {
                //                    Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                //                    Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                //                    Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                //                    Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                //                    Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                //                    Console.WriteLine("===========================================================\n\n\n");
                //                }
                //            }
                //            break;
                //            case "2":
                //                Console.Clear();
                //                for (int i = 0; i < entry.Count; i++)
                //                {
                //                    tickets[i] = entry[i]["tickets"]["type"];

                //                    if (tickets[i].ToString() == "tickets")
                //                    {
                //                        Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                //                        Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                //                        Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                //                        Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                //                        Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                //                        Console.WriteLine("===========================================================\n\n\n");
                //                    }
                //                }
                //                break;
                //            case "3":
                //                Console.Clear();
                //                for (int i = 0; i < entry.Count; i++)
                //                {
                //                    tickets[i] = entry[i]["tickets"]["type"];

                //                    if (tickets[i].ToString() == "tickets" || tickets[i].ToString() == "free")
                //                    {
                //                        Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                //                        Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                //                        Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                //                        Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                //                        Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                //                        Console.WriteLine("===========================================================\n\n\n");
                //                    }
                //                }
                //                break;
                //            case "4":
                //                Console.Clear();
                //                for (int i = 0; i < entry.Count; i++)
                //                {
                //                    tickets[i] = entry[i]["tickets"]["type"];

                //                    if (tickets[i].ToString() == "unknown")
                //                    {
                //                        Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                //                        Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                //                        Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                //                        Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                //                        Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                //                        Console.WriteLine("===========================================================\n\n\n");
                //                    }
                //                }
                //                break;
                //            default:
                //                Console.Clear();
                //                Console.WriteLine("\nNiema takiej opcji. Spróbuj jeszcze raz");
                //                break;
                //       }
                //    } while (userInput.Key != ConsoleKey.Escape);
            }
        }
    }
}
