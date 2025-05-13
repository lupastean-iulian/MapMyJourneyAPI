namespace MapMyJourneyAPI.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MapMyJourneyAPI.DataAccess;
    using MapMyJourneyAPI.Domain.Interfaces;
    using MapMyJourneyAPI.Domain.Pagination;
    using MapMyJourneyAPI.Domain.Entities;

    public class ProfileRepository : IProfileRepository
    {
        private readonly MapMyJourneyContext _context;

        public ProfileRepository(MapMyJourneyContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Profile>> GetAllAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profile?> GetByIdAsync(Guid id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<PaginatedResponse<Profile>> GetPaginatedAsync(int page, int pageSize)
        {
            var totalCount = await _context.Profiles.CountAsync();
            var items = await _context.Profiles
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResponse<Profile>(items, totalCount, pageSize, page);
        }

        public async Task UpdateAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
        }
    }
}