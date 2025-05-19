using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapMyJourneyAPI.DataAccess.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MapMyJourneyContext _context;

        public LocationRepository(MapMyJourneyContext context)
        {
            _context = context;
        }
        public Task<Location?> GetLocationByPlaceIdAsync(string placeId)
        {
            return _context.Locations.FirstOrDefaultAsync(l => l.PlaceId == placeId);
        }
        public async Task<Location> AddLocationAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return location;
        }
        public async Task DeleteLocationAsync(string placeId)
        {
            var location = await GetLocationByPlaceIdAsync(placeId);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateLocationAsync(Location location)
        {
            await _context.Locations.Where(l => l.PlaceId == location.PlaceId).ExecuteUpdateAsync(
                l => l.SetProperty(x => x.Name, location.Name)
                      .SetProperty(x => x.Address, location.Address)
                      .SetProperty(x => x.Geometry, location.Geometry)
                      .SetProperty(x => x.PhotoReferences, location.PhotoReferences)
            );
        }
    }
}