using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CultureInGdansk
{
    public class JsonReader
    {

        private string Path = Directory.GetCurrentDirectory() + @"\Events.json";
        private string PathRoot = Directory.GetCurrentDirectory();



        public void JsonRead()
        {
            if (File.Exists(Path))
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
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("File does not exist. Please copy the file Events.json into C: directory");
                if (File.Exists(@"C:\Events.Json"))
                {
                    File.Copy(@"C:\Events.Json", Path);
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
        File.Delete(Path);
        File.Copy(@"C:\Events.Json", Path);

        }
    }
}
