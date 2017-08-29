using System;
using DotnetVideo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotnetVideo
{
    public partial class videosdbContext : DbContext
    {
        public DbSet<GenreModel> Genres {get;set;}
        public DbSet<RentalRecordModel> RentalRecords {get;set;}
        public DbSet<MovieModel> Movies {get;set;}
        public DbSet<CustomerModel> Customers {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=videosdb;Username=dev;Password=dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }
}
