using System;
using System.Collections.Generic;
using System.Text;
using Common.Models;

namespace Common.Interfaces
{
    public interface IFavoriteRepository
    {
        
            Favorite Add(Favorite oneEvent);
            void DeleteByEventId(int id);
        
    }
}
