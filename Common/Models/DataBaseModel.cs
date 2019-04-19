using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Models
{
    public class DataBaseModel
    {
        
        public int id { get; set; }
        public string place { get; set; }
        public DateTime endDate { get; set; }
        public string name { get; set; }
        public string urls { get; set; }
        public List<object> attachments { get; set; }
        public string descLong { get; set; }
        public int categoryId { get; set; }
        public DateTime startDate { get; set; }
        public string organizer { get; set; }
        public int active { get; set; }
        public string tickets { get; set; }
        public string descShort { get; set; }
        public string recurrence { get; set; }
        public string schedule { get; set; }
    }

    public class EventsBase : IEntityTypeConfiguration<DataBaseModel>
    {
        public void Configure(EntityTypeBuilder<DataBaseModel> builder)
        {
            builder
                .ToTable("Event")
                .Property(x => x.id)
                .IsRequired()
                .HasColumnName("Id");

            builder
                .Property(x => x.place)
                .HasMaxLength(50)
                .HasColumnName("Place");
            builder
                .Property(x => x.endDate)
                .HasColumnName("EndData");

            builder
                .Property(x => x.name)
                .HasMaxLength(100)
                .HasColumnName("Name");

            builder
                .Property(x => x.urls)
                .HasColumnName("Url");

            builder
                .Property(x => x.attachments)
                .HasColumnName("Attachments");

            builder
                .Property(x => x.descLong)
                .HasMaxLength(1000)
                .HasColumnName("DescLong");

            builder
                .Property(x => x.categoryId)
                .HasColumnName("CategoryId");

            builder
                .Property(x => x.startDate)
                .HasColumnName("startData");

            builder
                .Property(x => x.organizer)
                .HasMaxLength(50)
                .HasColumnName("Organizer");

            builder
                .Property(x => x.active)
                .HasColumnName("Active");

            builder
                .Property(x => x.tickets)
                .HasColumnName("Tickets");

            builder
                .Property(x => x.descShort)
                .HasColumnName("DescShort");

            builder
                .Property(x => x.recurrence)
                .HasColumnName("Recurrence");

            builder
                .Property(x => x.schedule)
                .HasColumnName("Schedule");

        }
    }
}
