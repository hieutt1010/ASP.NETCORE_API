using ASPNETCORE_API.Data;
using ASPNETCORE_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE_API.Repositories
{
    public class RegionRepository : iRegionRepository
    {
        private readonly My_DbContext my_DbContext;

        public RegionRepository(My_DbContext my_DbContext)
        {
            this.my_DbContext = my_DbContext;
        }

        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
            return await my_DbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await my_DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await my_DbContext.AddAsync(region);
            await my_DbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await my_DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
                return null;

            my_DbContext.Remove(region);
            await my_DbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await my_DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
                return null;

            existingRegion.Code = region.Code;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Name = region.Name;
            existingRegion.Population = region.Population;

            await my_DbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}