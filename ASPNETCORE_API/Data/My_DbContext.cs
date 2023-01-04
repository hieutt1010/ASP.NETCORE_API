using ASPNETCORE_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE_API.Data
{
    public class My_DbContext : DbContext
    {
        public My_DbContext(DbContextOptions<My_DbContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficuties { get; set; }
    }
}