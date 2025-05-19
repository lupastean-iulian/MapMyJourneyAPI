namespace MapMyJourneyAPI.DataAccess.EntityConfigurations
{
    using MapMyJourneyAPI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(l => l.PlaceId);

            builder.Property(l => l.Name)
                .IsRequired();
            builder.HasOne(l => l.Address).WithOne(a => a.Location)
                .HasForeignKey<LocationAddress>(a => a.PlaceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.Geometry).WithOne(g => g.Location)
                .HasForeignKey<LocationGeometry>(g => g.PlaceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(l => l.PhotoReferences)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.PlaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}