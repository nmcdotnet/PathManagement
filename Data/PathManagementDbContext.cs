using Microsoft.EntityFrameworkCore;
using PathManagement.Models.Domain;

namespace PathManagement.Data
{
    public class PathManagementDbContext : DbContext
    {
        public PathManagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        // Create tables
        public DbSet<PathModel> Paths { get; set; }
        public DbSet<GroupPathModel> Groups { get; set; }


    }
}
