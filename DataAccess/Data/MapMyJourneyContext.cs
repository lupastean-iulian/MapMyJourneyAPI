using Microsoft.EntityFrameworkCore;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.DataAccess.EntityConfigurations;

namespace MapMyJourneyAPI.DataAccess;

public class MapMyJourneyContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Identity> Identities { get; set; }

    public MapMyJourneyContext(DbContextOptions<MapMyJourneyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());
    }
}
