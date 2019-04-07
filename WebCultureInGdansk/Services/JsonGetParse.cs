using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;
using WebCultureInGdansk.Models;

namespace WebCultureInGdansk
{
    public class JsonGetParse
    {
       public List <RootObject> JsonGet()
           { 
            var path = "https://planerkulturalny.pl/api/rest/events.json";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(path);
                List<RootObject> getData = JsonConvert.DeserializeObject<List<RootObject>>(json);
                return getData;
            }
        }
    }

}
