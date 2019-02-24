using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;

namespace CultureInGdansk
{
    class Program
    {
        

        static void Main(string[] args)
        {
            JsonReader ReadJson = new JsonReader();
            GetTickets CheckTickets = new GetTickets();

            while (!ReadJson.JsonInsert())
            {
                Console.WriteLine("Nie znaleziono pliku 'Events.Json'. Wgraj plik 'Events.Json' do katalogu C:");
                Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować ...");
                Console.ReadKey();
                Console.Clear();
            }

            ConsoleKeyInfo userInput;

            do
            {
                DisplayMenu();

                userInput = Console.ReadKey();
                Console.ReadLine();
                switch (userInput.KeyChar.ToString())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\nWcisnieto 1");
                        //var EventsList = new JsonReadLinq();

                        //IEnumerable<Events.Entry> Events = JsonReadLinq.GetEvents();

                        //var event1 = Events.Where(e => e.name == "Sztuka" );
                        //Console.WriteLine($"{event1}");

                        break;
                    case "2":
                        string userChooseEvent;
                        do
                        {
                            Console.Clear();

                            Console.WriteLine("\n================LISTA WYDARZEŃ=========================");
                            Console.WriteLine("\n");

                            GetListOfAllEvents ListEvents = new GetListOfAllEvents();
                            var List = ListEvents.Events();

                            for (int i = 0; i < List.Count; i++)
                            {
                                Console.WriteLine($"____WYDARZENIE {i}____");
                                Console.WriteLine("Nazwa: " + List[i]["name"]);
                                Console.WriteLine("Miejsce wydrzenia: " + List[i]["place"]["name"]);
                                Console.WriteLine("===============================");
                                Console.WriteLine("\n");
                            }

                            Console.WriteLine("\n");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Wybierz numer wydarzenia aby wyświetlić szczegóły");
                            Console.WriteLine("Wybierz Q aby wyjść z listy");
                            Console.WriteLine("\n");
                            Console.Write("Twój wybór: ");
                            Console.ResetColor();
                            userChooseEvent = Console.ReadLine();

                            while (!(userChooseEvent.All(char.IsDigit)) && userChooseEvent != "Q" && userChooseEvent != "q" || String.IsNullOrEmpty(userChooseEvent))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\nWybierz numer wydarzenia albo Q żeby wyjść z listy.");
                                Console.Write("Twój wybór: ");
                                Console.ResetColor();
                                userChooseEvent = Console.ReadLine();
                            }

                            if (userChooseEvent != "Q" && userChooseEvent != "q")
                            {
                                Console.Clear();

                                var index = Convert.ToInt32(userChooseEvent);

                                Console.WriteLine("Szczegóły wydarzenia o nazwie: " + List[index]["name"]);
                                Console.WriteLine("--------------------");
                                Console.WriteLine("\nMiejsce: " + List[index]["place"]["name"]);
                                Console.WriteLine("\nKiedy: " + List[index]["startDate"]);
                                Console.WriteLine("\nOpis: " + List[index]["descLong"]);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\nNaciśnij ENTER aby wrócic do listy wydarzeń");
                                Console.ResetColor();
                                Console.ReadLine();
                            }
                            Console.Clear();
                        } while (userChooseEvent != "Q" && userChooseEvent != "q");

                        break;
                    case "3":
                        Console.Clear();
                        CheckTickets.TicketInfo();
                        break;
                    case "4":
                        Console.Clear();                        
                        while (!ReadJson.JsonUpdate())
                        {                            
                            Console.ReadKey();
                            Console.Clear();
                        }
                        Console.WriteLine("Baza wydarzeń została zaktualizowana !!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nNiema takiej opcji. Spróbuj jeszcze raz");
                        break;
                }

            } while (userInput.Key != ConsoleKey.Q);


        }


        static public void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Witamy w aplikacji Gdańska Kultura");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Wyszukaj wydarzenie");
            Console.WriteLine("2. Wyświetl szczegóły wydarzenia");
            Console.WriteLine("3. Wyświetl informacje o biletach");
            Console.WriteLine("4. Zaktualizuj bazę wydarzeń");
            Console.WriteLine("Q. Aby zamknąć aplikację");
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Twój wybór: ");
            Console.ResetColor();

            //string result = Console.ReadLine();

            //return Convert.ToInt32(result);

         //  var jsonReaderLinq = new JsonReadLinq();
         // 
         //  IEnumerable<Events.Entry> events = jsonReaderLinq.GetEvents();
         // 
         //  var event1 = events.Where(n => n.name == "wystawa");
        }

        
        


        
    }
}
