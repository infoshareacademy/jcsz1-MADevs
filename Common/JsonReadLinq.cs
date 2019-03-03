using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using static Common.Events;

namespace Common
{
    public class JsonReadLinq
    {
        public async Task <Entry> JsonDeserialize()
        {
            Entry getData = new Entry();
            getData = JsonConvert.DeserializeObject<Entry>(await JsonGet());
            return getData;
        }
        
        public async Task <string> JsonGet()
        {
            string responseGet = "";

                var request = HttpWebRequest.CreateHttp("https://planerkulturalny.pl/api/rest/events.json");
                request.Method = WebRequestMethods.Http.Get;
                request.ContentType = "application/json";

                await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                    .ContinueWith(task =>
                    {
                        var response = (HttpWebResponse)task.Result;

                        StreamReader responseReader = new StreamReader(response.GetResponseStream());

                        string responseData = responseReader.ReadToEnd();

                        responseGet = responseData.ToString();

                        responseReader.Close();
                        response.Close();

                     });

            return responseGet;
        }
    }
}
