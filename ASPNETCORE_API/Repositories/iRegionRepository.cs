using ASPNETCORE_API.Models.Domain;

namespace ASPNETCORE_API.Repositories
{
    public interface iRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionAsync();
        Task<Region> GetAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task<Region> DeleteAsync(Guid id);
        Task<Region> UpdateAsync(Guid id, Region region);
    }
}