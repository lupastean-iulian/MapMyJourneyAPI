namespace MapMyJourneyAPI.Domain.Interfaces
{
    using MapMyJourneyAPI.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationRepository
    {
        Task<Location?> GetLocationByPlaceIdAsync(string placeId);
        Task<Location> AddLocationAsync(Location location);
        Task UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(string placeId);
    }
}