using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // Configurer la relation many-to-many entre Flight et Passenger
            builder
                .HasMany(f => f.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(j => j.ToTable("FlightPassengers"));

            // Configurer la relation one-to-many entre Flight et Plane
            builder
                .HasOne(f => f.Plane)
                .WithMany()
                .HasForeignKey(f => f.PlaneId);
        }
    }
}
