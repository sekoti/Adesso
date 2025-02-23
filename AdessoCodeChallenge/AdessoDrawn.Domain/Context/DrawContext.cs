using AdessoDraw.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdessoDraw.Domain.Context;
public class DrawContext : DbContext
{
    public DrawContext(DbContextOptions<DrawContext> options) : base(options) { }

    public DbSet<Country> Countries { get; set; }
    //public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Country>().HasData(
            new Country { Name = "Türkiye", Id = 1 },
            new Country { Name = "Almanya", Id = 2 },
            new Country { Name = "Fransa", Id = 3 },
            new Country { Name = "Hollanda", Id = 4 },
            new Country { Name = "Portekiz", Id = 5 },
            new Country { Name = "İtalya", Id = 6 },
            new Country { Name = "İspanya", Id = 7 },
            new Country { Name = "Belçika", Id = 8 }
        );
    }
}
