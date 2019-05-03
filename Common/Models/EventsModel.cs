using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class EventsFields

    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("place.name")]
        [Required]
        public string PlaceName { get; set; }

        [JsonProperty("startDate")]
        [Required]
        [CustomDate]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        [Required]
        [CustomDate]
        public DateTime EndDate { get; set; }

        [JsonProperty("descShort")]
        public string DescShort { get; set; }

        [JsonProperty("descLong")]
        public string DescLong { get; set; }

        [JsonProperty("urls.www")]
        public string UrlsWww { get; set; }

        [JsonProperty("tickets.type")]
        [Required]
        public string TicketsType { get; set; }
    }

    class JsonPathConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            object targetObj = Activator.CreateInstance(objectType);
            foreach (PropertyInfo prop in objectType.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                JsonPropertyAttribute att = prop.GetCustomAttributes(true).OfType<JsonPropertyAttribute>().FirstOrDefault();
                string jsonPath = (att != null ? att.PropertyName : prop.Name);
                JToken token = jo.SelectToken(jsonPath);
                if (token != null && token.Type != JTokenType.Null)
                {
                    object value = token.ToObject(prop.PropertyType, serializer);
                    prop.SetValue(targetObj, value, null);
                }
            }
            return targetObj;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

