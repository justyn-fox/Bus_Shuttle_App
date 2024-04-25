using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DomainModel;

namespace DomainModel
{
    public class DataContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Entry> BusEntries { get; set; }
        public DbSet<Loop> Loops { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Stop> Stops { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            DbPath = "Bus_Shuttle.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}