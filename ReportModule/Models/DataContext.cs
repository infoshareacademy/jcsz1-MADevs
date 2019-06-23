using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReportModule.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Raport> Reports { get; set; }
    }

    public class Raport

    {
        [Key]
        public int ReportId { get; set; }
        public string ReportLevel { get; set; }
        public string ReportDecs { get; set; }
    }
}
