using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(DbContextOptions<MiDbContext> options)
            : base(options)
        {
        }
        public DbSet<TableOfVehicles> Vehicles { get; set; }
        public DbSet<TableOfUser> Users { get; set; }
        public DbSet<VehiclePrice> VehiclePrice { get; set; }
        public DbSet<SalesTable> Sales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableOfVehicles>()
                .HasOne(v => v.User) 
                .WithMany(u => u.Vehicles) 
                .HasForeignKey(v => v.UserId); 
        }
    }
}
