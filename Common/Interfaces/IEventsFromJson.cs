using System.Collections.Generic;
using Common.Models;

namespace Common.Services
{
    public interface IEventsFromJson
    {
        List<EventsFields> GetJson();
        EventsFields Create(EventsFields oneEvent);
        List<EventsFields> GetEventsByTicketType(string type);
        EventsFields GetEventById(int id);
        bool UpdateEvent(int id, EventsFields eventToUpdate);
    }
}