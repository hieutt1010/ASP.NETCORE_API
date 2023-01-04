using ASPNETCORE_API.Data;
using ASPNETCORE_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE_API.Repositories
{
    public class WalkRepository : iWalkRepository
    {
        private readonly My_DbContext my_DbContext;

        public WalkRepository(My_DbContext my_DbContext)
        {
            this.my_DbContext = my_DbContext;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await my_DbContext.Walks
            .Include(x => x.Region)
            .Include(x => x.walkDifficulty)
            .ToListAsync();
        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            return await my_DbContext.Walks
            .Include(x => x.Region)
            .Include(x => x.walkDifficulty)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await my_DbContext.Walks.AddAsync(walk);
            await my_DbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await my_DbContext.Walks.FindAsync(id);

            if (existingWalk != null)
            {
                existingWalk.Length = walk.Length;
                existingWalk.Name = walk.Name;
                existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
                existingWalk.RegionId = walk.RegionId;
                await my_DbContext.SaveChangesAsync();
                return existingWalk;
            }
            return null;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var exitingWalk = await my_DbContext.Walks.FindAsync(id);
            if (exitingWalk == null)
            {
                return null;
            }
            my_DbContext.Walks.Remove(exitingWalk);
            await my_DbContext.SaveChangesAsync();
            return exitingWalk;
        }
    }
}