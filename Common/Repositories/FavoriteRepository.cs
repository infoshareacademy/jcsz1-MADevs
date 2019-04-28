using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace Common.Repositories
{
    

    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly DataContext _context;
        public FavoriteRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Favorite Add(Favorite oneEvent)
        {
            return _context.Favorites.Add(oneEvent).Entity;
        }
        public void  DeleteByEventId(int id)
        {
            var favorite = _context.Favorites.Single(x => x.EventId == id);
            _context.Favorites.Remove(favorite);
            _context.SaveChanges();
            
          }
        
    }

    
}
