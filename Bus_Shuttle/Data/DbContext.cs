using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DomainModel;

namespace DomainModel
{
    public class DataContext : DbContext
    {
        public DbSet<DomainModel.Bus> Buses { get; set; }
        public DbSet<DomainModel.Driver> Drivers { get; set; }
        public DbSet<DomainModel.Entry> BusEntries { get; set; }
        public DbSet<DomainModel.Loop> Loops { get; set; }
        public DbSet<DomainModel.Route> Routes { get; set; }
        public DbSet<DomainModel.Stop> Stops { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            DbPath = "Bus_Shuttle.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}