using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            // Configurer PlaneId comme clé primaire
            builder.HasKey(p => p.PlaneID);

            // Configurer le nom de la table
            builder.ToTable("MyPlanes");

            // Configurer le nom de la colonne Capacity
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
        }
    }
}
