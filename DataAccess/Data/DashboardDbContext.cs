using Dashboard.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.DataAccess.Data
{
    public class DashboardDbContext : DbContext
    {
        public DashboardDbContext(DbContextOptions<DashboardDbContext> options) : base(options) { }

        public DbSet<Movie> Movies => Set<Movie>();

    }
}
