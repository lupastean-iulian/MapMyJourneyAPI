using Microsoft.EntityFrameworkCore;
using MapMyJourneyAPI.Domain.Entities;

namespace MapMyJourneyAPI.DataAccess;

public class MapMyJourneyContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    
    public MapMyJourneyContext(DbContextOptions<MapMyJourneyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
