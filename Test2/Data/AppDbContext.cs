using Test2.Entities;
using Microsoft.EntityFrameworkCore;c

namespace Test2.Data
{

public class AppDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<ReservationService> ReservationServices { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Room>().HasKey(c => c.ID);
        modelBuilder.Entity<Guest>().HasKey(o => o.ID);
        modelBuilder.Entity<Reservation>().HasKey(p => p.ID);
        modelBuilder.Entity<Service>().HasKey(s => s.ID);
        modelBuilder.Entity<ReservationService>()
            .HasKey(po => new { po.ProductID, po.OrderID });
    }
}
}