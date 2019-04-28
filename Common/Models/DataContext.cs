using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Common.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Models
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Favorite> Favorites { get; set; }
    }

    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
    }
}