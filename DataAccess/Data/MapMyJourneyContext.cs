using Microsoft.EntityFrameworkCore;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.DataAccess.EntityConfigurations;

public class MapMyJourneyContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Identity> Identities { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationGeometry> LocationGeometries { get; set; }
    public DbSet<LocationAddress> LocationAddresses { get; set; }
    public DbSet<LocationPhotoReference> LocationPhotoReferences { get; set; }

    public MapMyJourneyContext(DbContextOptions<MapMyJourneyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
    }
}
