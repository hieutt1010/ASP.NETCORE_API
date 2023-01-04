using ASPNETCORE_API.Models.Domain;

namespace ASPNETCORE_API.Repositories
{
    public interface iWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetWalkByIdAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk> UpdateAsync(Guid id, Walk walk);
        Task<Walk> DeleteAsync(Guid id); 
    }
}