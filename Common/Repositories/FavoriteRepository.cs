using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;


namespace Common.Repositories
{
    

    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly IEventsFromJson _eventsList;
        private readonly DataContext _context;
        public FavoriteRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Favorite oneEvent)
        {
             _context.Favorites.Add(oneEvent);
             _context.SaveChanges();
        }


        public void DeleteByEventId(int id)
        {
            var favorite = _context.Favorites.Single(x => x.EventId == id);
            _context.Favorites.Remove(favorite);
            _context.SaveChanges();

        }

        public Favorite ViueSingelFavorite(int id)
        {
            return _context.Favorites.Single(x => x.EventId == id);
        }

        public List<Favorite> ViueAllFavorite()
        {
            return _context.Favorites.ToList();
        }

        public List<EventsFields> Test()
        {
            var events = _eventsList.GetJson();
            var favorites = events.Where(x => ViueAllFavorite().Any(y => y.EventId == x.Id));
            return favorites.ToList();
        }
    }

    
}
