using Microsoft.EntityFrameworkCore;
using WebAPIDeploymentLab.Models;

namespace WebAPIDeploymentLab.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}