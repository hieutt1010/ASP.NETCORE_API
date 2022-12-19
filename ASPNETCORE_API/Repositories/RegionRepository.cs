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

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await my_DbContext.Regions.ToListAsync();
        }
    }
}