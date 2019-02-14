using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public class JsonReader
    {
        private readonly string _path = Directory.GetCurrentDirectory() + @"\Events.json";
        //private string PathRoot = Directory.GetCurrentDirectory(); // It's never used, remove if not needed

        public void JsonRead()
        {
            if (File.Exists(_path))
            {

                using (StreamReader jsonStream = new StreamReader("Events.json"))
                {
                    string jsonFile = jsonStream.ReadToEnd();

                    JObject events = JObject.Parse(jsonFile);
                    IList<JToken> entry = events["result"]["entry"].Children().ToList();

                    for (int i = 0; i < entry.Count; i++)
                    {
                        Console.WriteLine("Place: " + entry[i]["place"]["name"]);
                        Console.WriteLine("\nDetailed place: " + entry[i]["place"]["subname"]);
                        Console.WriteLine("\nDate of event: " + entry[i]["startDate"]);
                        Console.WriteLine("\nDate of event end: " + entry[i]["endDate"]);
                        Console.WriteLine("\nDescription: " + entry[i]["descShort"]);
                        Console.WriteLine("=====================================================================");
                    }


                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("File does not exist. Please copy the file Events.json into C: directory");
                if (File.Exists(@"C:\Events.Json"))
                {
                    File.Copy(@"C:\Events.Json", _path);
                }
                else
                {
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }

        public void JsonUpdate()
        {
            File.Delete(_path);
            File.Copy(@"C:\Events.Json", _path);

        }
    }
}
