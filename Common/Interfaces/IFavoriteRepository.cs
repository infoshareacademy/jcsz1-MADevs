using System;
using System.Collections.Generic;
using System.Text;
using Common.Models;

namespace Common.Interfaces
{
    public interface IFavoriteRepository
    {
        void Add(Favorite oneEvent);
        void DeleteByEventId(int id);
        Favorite ViueSingelFavorite(int id);
        List<Favorite> ViueAllFavorite();
        List<EventsFields> Test();
    }
}