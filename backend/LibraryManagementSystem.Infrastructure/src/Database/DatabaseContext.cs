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
        private readonly string _adminPassword;
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users{ get; set; }

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _adminPassword = _configuration["AdminPassword"]!;
        }

        static DatabaseContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new Npgsql.NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DatabaseConnection"));
            builder.MapEnum<Role>();
            optionsBuilder.AddInterceptors(new TimeStampInterceptor());
            optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.HasPostgresEnum<Role>();

            modelBuilder.Entity<Genre>()
                .Property(genre => genre.GenreName)
                .HasConversion<string>();

            modelBuilder.Entity<Loan>()
                .Property(loan => loan.Status)
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
                        Password = BCryptNet.HashPassword(_adminPassword),
                        Email = "admin@test.com",
                        Address = "Admin Street 00100",
                        Role = Role.Admin
                    }
                );
        }
    }
}