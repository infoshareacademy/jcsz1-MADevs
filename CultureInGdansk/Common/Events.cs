using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public class Events
    {

        public class Entry
        {
            public string id { get; set; }
            public Place place { get; set; }
            public DateTime endDate { get; set; }
            public string name { get; set; }
            public Urls urls { get; set; }
            public Attachments attachments { get; set; }
            public string descLong { get; set; }
            public string categoryId { get; set; }
            public DateTime startDate { get; set; }
            public Organizer organizer { get; set; }
            public string active { get; set; }
            public string descShort { get; set; }
            public Tickets tickets { get; set; }
            public Schedule schedule { get; set; }
        }

        public class Place
        {
            public string id { get; set; }
            public string subname { get; set; }
            public string name { get; set; }
        }

        public class Urls
        {
            public string www { get; set; }
            public object fb { get; set; }
            public Twitter twitter { get; set; }
            public object tickets { get; set; }
        }

        public class Twitter
        {
            public string _xsinil { get; set; }
        }

        public class Attachments
        {
            public object attachment { get; set; }
        }

        public class Organizer
        {
            public string id { get; set; }
            public string designation { get; set; }
        }

        public class Tickets
        {
            public string type { get; set; }
            public string startTicket { get; set; }
            public string endTicket { get; set; }
        }

        public class Schedule
        {
            public Monday monday { get; set; }
            public Tuesday tuesday { get; set; }
            public Wednesday wednesday { get; set; }
            public Thursday thursday { get; set; }
            public Friday friday { get; set; }
            public Saturday saturday { get; set; }
            public Sunday sunday { get; set; }
        }

        public class Monday
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Tuesday
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Wednesday
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Thursday
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Friday
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Saturday
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Sunday
        {
            public string start { get; set; }
            public string end { get; set; }
        }

    }

    
}
