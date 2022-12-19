using ASPNETCORE_API.Models.Domain;

namespace ASPNETCORE_API.Repositories
{
    public interface iRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }

}