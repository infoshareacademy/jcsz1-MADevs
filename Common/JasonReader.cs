using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                Console.WriteLine($"File does not exist. Please copy the file Events.json into {Directory.GetCurrentDirectory()} directory");
            }
        }

        public void JsonUpdate()
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Upload");
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Upload" + @"\Events.json"))
            {
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                }
                File.Copy(Directory.GetCurrentDirectory()+@"\Upload"+@"\Events.json",Path);
                Console.WriteLine("Events database updated !!");
            }
            else
            {
                Console.WriteLine($"Please copy the file Events.json into {Directory.GetCurrentDirectory()}{@"\Upload"} directory");
            }
        }
    }
}
