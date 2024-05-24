using Imtahan.Models;
using Microsoft.EntityFrameworkCore;

namespace Imtahan.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Lumia> Lumias { get; set; }
        public DbSet<LoginRegister> loginRegisters { get; set; }
    }
}
