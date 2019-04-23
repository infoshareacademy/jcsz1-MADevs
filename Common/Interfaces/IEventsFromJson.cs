using System.Collections.Generic;
using Common.Models;

namespace Common.Services
{
    public interface IEventsFromJson
    {
        List<RootObject> GetJson();
        RootObject Create(RootObject oneEvent);        
        List<RootObject> GetEventsByTicketType(string type);
        RootObject GetEventById(int id);
        bool UpdateEvent(int id, RootObject eventToUpdate);
    }
}