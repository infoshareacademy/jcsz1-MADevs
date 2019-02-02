using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;


namespace CultureInGdansk
{
    class Program
    {

        static void Main(string[] args)
        {


            //JsonReader ReadJson = new JsonReader{};
            Tickets CheckTickets = new Tickets {};



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
                        //ReadJson.JsonRead();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nWcisnieto 2");
                        break;
                    case "3":
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
                            Console.WriteLine("Wybierz numer wydarzenia aby wyświetlić szczegóły");
                            Console.WriteLine("Wybierz Q aby wyjść z listy");
                            Console.WriteLine("\n");
                            Console.Write("Twój wybór: ");
                            userChooseEvent = Console.ReadLine();

                            while (!(userChooseEvent.All(char.IsDigit)) && userChooseEvent != "Q" && userChooseEvent != "q")
                            {
                                Console.WriteLine("\nWybierz numer wydarzenia albo Q żeby wyjść z listy.");
                                Console.Write("Twój wybór: ");
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

                                Console.WriteLine("\nNaciśnij ENTER aby wrócic do listy wydarzeń");
                                Console.ReadLine();
                            }
                            Console.Clear();
                        } while (userChooseEvent != "Q" && userChooseEvent != "q");

                        break;
                    case "4":
                        Console.Clear();
                        CheckTickets.TicketInfo();
                        break;
                    case "5":
                        Console.Clear();
                        //ReadJson.JsonUpdate();
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
            Console.WriteLine("1. Wczytaj dane z pliku");
            Console.WriteLine("2. Wyszukaj wydarzenie");
            Console.WriteLine("3. Wyświetl szczegóły wydarzenia");
            Console.WriteLine("4. Wyświetl informacje o biletach");
            Console.WriteLine("5. Zaktualizuj plik");
            Console.WriteLine("Q. Aby zamknąć aplikację");
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.Write("Twój wybór: ");
        }

         
    }
}
