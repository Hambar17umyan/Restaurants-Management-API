using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL.Db;

public class AppDbContext : DbContext
{
    public DbSet<AddressEntity> Addresses { get; set; }

    public DbSet<RestaurantEntity> Restaurants { get; set; }

    public DbSet<PlayerEntity> Players { get; set; }

    public DbSet<RestaurantMembershipEntity> RestaurantMemberships { get; set; }

    public DbSet<PlayerFavoriteRestaurantEntity> PlayerFavoriteRestaurants { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder = this.BuildAddress(modelBuilder);
        _ = modelBuilder = this.BuildPlayer(modelBuilder);
        _ = modelBuilder = this.BuildRestaurant(modelBuilder);
        _ = modelBuilder = this.BuildRestaurantMembership(modelBuilder);
        _ = modelBuilder = this.BuildPlayerFavoriteRestaurant(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private ModelBuilder BuildRestaurant(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RestaurantEntity>()
            .HasKey(r => r.Id)
            .HasName("Restaurants");

        modelBuilder.Entity<RestaurantEntity>()
            .HasOne(r => r.Address)
            .WithOne()
            .HasForeignKey<RestaurantEntity>(r => r.AddressId);

        return modelBuilder;
    }

    private ModelBuilder BuildPlayer(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerEntity>()
            .HasKey(p => p.Id)
            .HasName("Players");

        modelBuilder.Entity<PlayerEntity>()
            .HasOne(p => p.PrimaryAddress)
            .WithMany()
            .HasForeignKey(p => p.PrimaryAddressId);

        modelBuilder.Entity<PlayerEntity>()
            .HasOne(p => p.AlternateAddress)
            .WithMany()
            .HasForeignKey(p => p.AlternateAddressId);

        modelBuilder.Entity<PlayerEntity>()
            .HasOne(p => p.OfficeAddress)
            .WithMany()
            .HasForeignKey(p => p.OfficeAddressId);

        return modelBuilder;
    }

    private ModelBuilder BuildAddress(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressEntity>()
            .HasKey(a => a.Id)
            .HasName("Addresses");

        return modelBuilder;
    }

    private ModelBuilder BuildRestaurantMembership(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RestaurantMembershipEntity>()
            .HasKey(rm => new { rm.RestaurantId, rm.PlayerId });

        modelBuilder.Entity<RestaurantMembershipEntity>()
            .HasOne(rm => rm.Restaurant)
            .WithMany()
            .HasForeignKey(rm => rm.RestaurantId);

        modelBuilder.Entity<RestaurantMembershipEntity>()
            .HasOne(rm => rm.Player)
            .WithMany()
            .HasForeignKey(rm => rm.PlayerId);

        return modelBuilder;
    }

    private ModelBuilder BuildPlayerFavoriteRestaurant(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerFavoriteRestaurantEntity>()
            .HasKey(rm => new { rm.RestaurantId, rm.PlayerId });

        modelBuilder.Entity<PlayerFavoriteRestaurantEntity>()
            .HasOne(rm => rm.Restaurant)
            .WithMany()
            .HasForeignKey(rm => rm.RestaurantId);

        modelBuilder.Entity<PlayerFavoriteRestaurantEntity>()
            .HasOne(rm => rm.Player)
            .WithMany()
            .HasForeignKey(rm => rm.PlayerId);

        return modelBuilder;
    }
}
