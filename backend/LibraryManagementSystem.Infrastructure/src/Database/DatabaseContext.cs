using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
using LibraryManagementSystem.Domain.src;
using LibraryManagementSystem.Domain.src.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Infrastructure.src.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users{ get; set; }

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new Npgsql.NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DatabaseConnection"));
            optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(genre => genre.GenreName)
                .HasConversion<string>();

            modelBuilder.Entity<Loan>()
                .Property(loan => loan.Status)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .Property(user => user.Roles)
                .HasConversion<string>();
            
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique()
                .HasFilter("Email IS NOT NULL");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Admin",
                        LastName = "McAdmin",
                        Password = BCryptNet.HashPassword("Admin123"),
                        Email = "admin@test.com",
                        Address = "Admin Street 00100",
                        Roles = Roles.Admin
                    }
                );
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                entity.UpdatedAt = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}