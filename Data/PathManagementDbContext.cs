using Microsoft.EntityFrameworkCore;
using PathManagement.Models;
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
        //public DbSet<User> tbSYS_Users { get; set; } // nếu muón liên kết với bảng có sẵn thì tên này cần giống tên của bảng trong Database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the User entity to the existing table in the database
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tbSYS_Users");
            });
        }
    }
}
