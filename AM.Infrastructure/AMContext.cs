using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {

        //dBset
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staff
        { get; set; }
        public DbSet<Traveller> Travellers{ get; set; }

        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                       Initial Catalog=AirportManagementDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

        }
        private void ConfigureConventions(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetColumnType("date");
                    }
                }
            }
        }
    }
}
