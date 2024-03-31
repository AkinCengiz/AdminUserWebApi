using Microsoft.EntityFrameworkCore;

namespace AdminUserWebApi.Models;

public class AdminUserContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=AKINCENGIZ;Database=AdminUserDB;Trusted_Connection=True;TrustServerCertificate=True");
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().Property(a => a.Id).HasColumnOrder(1);
        modelBuilder.Entity<Admin>().OwnsOne(a => a.Person, a =>
        {
            a.Property(p => p.FirstName).HasColumnName("FirstName").HasColumnOrder(2);
            a.Property(p => p.LastName).HasColumnName("LastName").HasColumnOrder(3);
            a.Property(p => p.Email).HasColumnName("Email").HasColumnOrder(4);
            a.Property(p => p.Phone).HasColumnName("Phone").HasColumnOrder(5);
        });
        modelBuilder.Entity<User>().Property(a => a.Id).HasColumnOrder(1);
        modelBuilder.Entity<User>().OwnsOne(u => u.Person, u =>
        {
            u.Property(p => p.FirstName).HasColumnName("FirstName").HasColumnOrder(2);
            u.Property(p => p.LastName).HasColumnName("LastName").HasColumnOrder(3);
            u.Property(p => p.Email).HasColumnName("Email").HasColumnOrder(4);
            u.Property(p => p.Phone).HasColumnName("Phone").HasColumnOrder(5);
        });

        base.OnModelCreating(modelBuilder);
    }
}
