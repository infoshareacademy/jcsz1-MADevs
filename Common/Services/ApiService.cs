﻿using Common.Models;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Common.Services
{
    public class ApiService
    {
        public DataContext context = new DataContext();
        public List<EventsFields> _eventsApiList = new List<EventsFields>();
        public List<ViewsHistory> _viewsApiList = new List<ViewsHistory>();

        public List<EventsFields> EventsFromApi()
        {
            if (_eventsApiList.Count == 0)
            {
                var path = "https://localhost:44303/api/events";

                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString(path);
                        _eventsApiList = JsonConvert.DeserializeObject<List<EventsFields>>(json);
                    }
                }
                catch (Exception message)
                {
                    Log.Error(message.ToString());
                }
            }

            return _eventsApiList;
        }

        public IEnumerable<ReportStatViewModel> ViewsFromApi()
        {
            if (_eventsApiList.Count == 0)
            {
                var path = "https://localhost:44303/api/views";

                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString(path);
                        _viewsApiList = JsonConvert.DeserializeObject<List<ViewsHistory>>(json);
                    }
                }
                catch (Exception message)
                {
                    Log.Error(message.ToString());
                }
            }
            return null;
        }
        //    var dict = new Dictionary<int, int>();
        //    foreach(var el in _viewsApiList)
        //    {
        //        if (dict.ContainsKey(el.EventId))
        //        {
        //            dict[el.EventId] += 1;
        //        }
        //        else
        //        {
        //            dict.Add(el.EventId, 1);
        //        }
        //    }
        //    var returnList = new List<ReportStatViewModel>();
        //    foreach(var elDict in dict)
        //    {
        //        var myEvent = context.Events.FirstOrDefault(x => x.EventId == elDict.Key);
        //        if(myEvent != null)
        //        {
        //            returnList.Add(new ReportStatViewModel { EventName = myEvent.Name, ViewsCount = elDict.Value });
        //        }
        //    }

        //    return returnList;
        //    var countPerEvent = _viewsApiList.GroupBy(x => x.EventId).Select(x => new ReportStatViewModel { EventName = });

        //    var count = from item in _viewsApiList
        //                group item by item.EventId into eventid
        //                select new
        //                {
        //                    EventId = eventid.Key,
        //                    count = eventid.Count(),
        //                };
        //    foreach (var item in count) {
        //        var result = context.Events.Where(x => x.EventId == item.EventId);
        //        var test = count.Join(result,
        //            x => x.count,
        //            y => y.Name,
        //           (x, y) => new
        //           {
        //               Name = y.Name,
        //               Count = x.count
        //           }
        //            ).ToList();
        //            }
            

          
        //}
    };
}