using AM.ApplicationCore.Domain; // For your Passenger and FullName classes
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            // Configure the FullName property as an owned entity
            builder.OwnsOne(p => p.Name, nameBuilder =>
            {
                // Configure FirstName property
                nameBuilder.Property(n => n.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("PassFirstName");

                // Configure LastName property
                nameBuilder.Property(n => n.LastName)
                    .IsRequired()
                    .HasColumnName("PassLastName");
            });

            // Other configurations for Passenger can go here
            // For example, if you have any other properties
        }
    }
}
