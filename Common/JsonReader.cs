using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public class JsonReader
    {
        private static readonly string _path = Directory.GetCurrentDirectory() + @"\Events.json";

        public bool JsonInsert()
        {
            if (File.Exists(_path))
            {
                return true;
            }
            else
            {
                if (File.Exists(@"C:\Events.json"))
                {
                    File.Copy(@"C:\Events.json", _path);
                    return true;                       
                }
                else
                {
                    return false;
                }                
            };           
        }

        public void JsonRead()
        {
                using (StreamReader jsonStream = new StreamReader("Events.json"))
                {
                    string jsonFile = jsonStream.ReadToEnd();

                    JObject events = JObject.Parse(jsonFile);
                    IList<JToken> entry = events["result"]["entry"].Children().ToList();
                }
         }

        public bool JsonUpdate()
        {
            if (File.Exists(@"C:\Events.json"))
            {
                if (File.GetCreationTime(@"C:\Events.json") > File.GetCreationTime(_path))
                {
                    File.Delete(_path);
                    File.Copy(@"C:\Events.Json", _path);
                    return true;
                }
                else
                {
                    Console.WriteLine("Twoja wersja pliku 'Events.json' jest starsza niż aktualnie używana wersja");
                    Console.WriteLine("Skopiuj nowszą wersję pliku 'Events.json' do katalogu C:");
                    return false;
                }
            }
            else
            {
               Console.WriteLine("Skopiuj aktualny plik 'Events.Json' do katalogu C:");
               return false;
            }
            
        }
    }
}
