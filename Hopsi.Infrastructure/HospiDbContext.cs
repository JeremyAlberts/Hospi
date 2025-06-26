using Hospi.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hopsi.Infrastructure
{
    public class HospiDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public HospiDbContext(DbContextOptions<HospiDbContext> options)
            : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Room> Rooms{ get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
