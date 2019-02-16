using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public class GetTickets
    {
        public void TicketInfo()
        {
            using (StreamReader JasonStream = new StreamReader("Events.json"))
            {
                string JsonFile = JasonStream.ReadToEnd();

                JObject Events = JObject.Parse(JsonFile);
                IList<JToken> entry = Events["result"]["entry"].Children().ToList();

                object[] Tickets = new object[entry.Count];

                ConsoleKeyInfo userInput;

                

                do
                {
                    Console.WriteLine("Wybierz rodzaj biletów: ");
                    Console.WriteLine("1. Darmowe");
                    Console.WriteLine("2. Płatne");
                    Console.WriteLine("3. Bez znaczenia");
                    Console.WriteLine("4. Nie podano");
                    Console.WriteLine("Wcisnij Q aby powrócić do poprzednieg menu");
                    userInput = Console.ReadKey();

                    Console.ReadLine();
                    switch (userInput.KeyChar.ToString())
                    {
                        case "1":
                            Console.Clear();
                            for (int i = 0; i < entry.Count; i++)
                            {
                                Tickets[i] = entry[i]["tickets"]["type"];

                                if (Tickets[i].ToString() == "free")
                                {
                                    Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                                    Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                                    Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                                    Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                                    Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                                    Console.WriteLine("===========================================================\n\n\n");
                                }
                            }
                            break;
                        case "2":
                            Console.Clear();
                            for (int i = 0; i < entry.Count; i++)
                            {
                                Tickets[i] = entry[i]["tickets"]["type"];

                                if (Tickets[i].ToString() == "tickets")
                                {
                                    Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                                    Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                                    Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                                    Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                                    Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                                    Console.WriteLine("===========================================================\n\n\n");
                                }
                            }
                            break;
                        case "3":
                            Console.Clear();
                            for (int i = 0; i < entry.Count; i++)
                            {
                                Tickets[i] = entry[i]["tickets"]["type"];

                                if (Tickets[i].ToString() == "tickets" || Tickets[i].ToString() == "free")
                                {
                                    Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                                    Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                                    Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                                    Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                                    Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                                    Console.WriteLine("===========================================================\n\n\n");
                                }
                            }
                            break;
                        case "4":
                            Console.Clear();
                            for (int i = 0; i < entry.Count; i++)
                            {
                                Tickets[i] = entry[i]["tickets"]["type"];

                                if (Tickets[i].ToString() == "unknown")
                                {
                                    Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                                    Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                                    Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                                    Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                                    Console.WriteLine("\nDescription: " + entry[i]["descLong"]);
                                    Console.WriteLine("===========================================================\n\n\n");
                                }
                            }
                            break;
                        default:
                            Console.Clear();
                            //Console.WriteLine("\nNiema takiej opcji. Spróbuj jeszcze raz");
                            break;
                    }

                } while (userInput.Key != ConsoleKey.Q);

            }

        }

    }
}