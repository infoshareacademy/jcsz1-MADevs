using System;
using System.IO;
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
                // Read the stream to a string, and write the string to the console.
                string JsonFile = JasonStream.ReadToEnd();
                Console.WriteLine(JsonFile);
                // ... tutaj odbieramy string pokazany wczesniej
                // i zapisujemy go do zmiennej data ...
                JObject jsonObject = JObject.Parse(JsonFile);
                Console.WriteLine("Id: " + jsonObject["id"]);
                Console.WriteLine("Text: " + jsonObject["Events"]);
                Console.ReadLine();
            }
            
        }

        
    }
}
