using System.Collections.Generic;
using Common.Models;

namespace Common.Services
{
    public interface IEventsFromJson
    {
        List<RootObject> GetJson();
        RootObject Create(RootObject oneEvent);
    }
}