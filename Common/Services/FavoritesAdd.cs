using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Services
{
    public class FavoritesAdd
    {
        public DataContext context = new DataContext();

        public bool FavCheck(int EventId)
        {
            var check = context.Favorites
                .Where(x=>x.EventId == EventId)
                .Any(x => x.Status.Equals(1));
                return check;
        }
    }
}
