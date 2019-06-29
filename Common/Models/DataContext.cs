using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Common.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace Common.Models
{
    public class DataContext : DbContext
    {
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\Testbase;Database=Eventlist;Trusted_Connection=True;");
        public DbSet<Event> Events { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<ViewsHistory> ViewsHistory { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<LogTable> LogTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\Testbase;Database=EventList;Trusted_Connection=True;");
        }
    }

    //public class DataContext : DbContext
    //{
    //    public DataContext(DbContextOptions<DataContext> options)
    //  : base(options)
    //    {
    //    }

    //    public DbSet<Event> Events { get; set; }
    //    public DbSet<Favorite> Favorites { get; set; }
    //    public DbSet<ViewsHistory> ViewsHistory { get; set; }
    //    public DbSet<LoginHistory> LoginHistory { get; set; }
    //    public DbSet<LogTable> LogTable { get; set; }
    //}

    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }

        public int EventId { get; set; }
        public Event Events { get; set; }
    }

    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string PlaceName { get; set; }
        public string Urls { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DescShort { get; set; }
        public string DescLong { get; set; }
        public string TicketsType { get; set; }

        public Favorite Favorites { get; set; }
    }

    public class ViewsHistory
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }

        public Event Events { get; set; }
    }

    public class LoginHistory
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
    }

    public class LogTable
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public string LogEvent { get; set; }
    }
}


