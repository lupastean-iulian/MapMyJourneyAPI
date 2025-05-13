using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Pagination;

namespace MapMyJourneyAPI.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task<Profile?> GetByIdAsync(Guid id);
        Task<List<Profile>> GetAllAsync();
        Task<PaginatedResponse<Profile>> GetPaginatedAsync(int page, int pageSize);
        Task AddAsync(Profile profile);
        Task UpdateAsync(Profile profile);
        Task DeleteAsync(Guid id);
    }
}