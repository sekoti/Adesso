using AdessoDraw.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdessoDraw.Domain.Context;
public class DrawContext : DbContext
{
    public DrawContext(DbContextOptions<DrawContext> options) : base(options) { }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Draw> Draws { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupTeam> GroupTeams { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Team>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Draw>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Group>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<GroupTeam>()
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


        modelBuilder.Entity<Team>().HasData(
    // Türkiye
    new Team { Name = "Adesso İstanbul", Id = 1, CountryId = 1 },
    new Team { Name = "Adesso Ankara", Id = 2, CountryId = 1 },
    new Team { Name = "Adesso İzmir", Id = 3, CountryId = 1 },
    new Team { Name = "Adesso Antalya", Id = 4, CountryId = 1 },

    // Almanya
    new Team { Name = "Adesso Berlin", Id = 5, CountryId = 2 },
    new Team { Name = "Adesso Frankfurt", Id = 6, CountryId = 2 },
    new Team { Name = "Adesso Münih", Id = 7, CountryId = 2 },
    new Team { Name = "Adesso Dortmund", Id = 8, CountryId = 2 },

    // Fransa
    new Team { Name = "Adesso Paris", Id = 9, CountryId = 3 },
    new Team { Name = "Adesso Marsilya", Id = 10, CountryId = 3 },
    new Team { Name = "Adesso Nice", Id = 11, CountryId = 3 },
    new Team { Name = "Adesso Lyon", Id = 12, CountryId = 3 },

    // Hollanda
    new Team { Name = "Adesso Amsterdam", Id = 13, CountryId = 4 },
    new Team { Name = "Adesso Rotterdam", Id = 14, CountryId = 4 },
    new Team { Name = "Adesso Lahey", Id = 15, CountryId = 4 },
    new Team { Name = "Adesso Eindhoven", Id = 16, CountryId = 4 },

    // Portekiz
    new Team { Name = "Adesso Lisbon", Id = 17, CountryId = 5 },
    new Team { Name = "Adesso Porto", Id = 18, CountryId = 5 },
    new Team { Name = "Adesso Braga", Id = 19, CountryId = 5 },
    new Team { Name = "Adesso Coimbra", Id = 20, CountryId = 5 },

    // İtalya
    new Team { Name = "Adesso Roma", Id = 21, CountryId = 6 },
    new Team { Name = "Adesso Milano", Id = 22, CountryId = 6 },
    new Team { Name = "Adesso Venedik", Id = 23, CountryId = 6 },
    new Team { Name = "Adesso Napoli", Id = 24, CountryId = 6 },

    // İspanya
    new Team { Name = "Adesso Sevilla", Id = 25, CountryId = 7 },
    new Team { Name = "Adesso Madrid", Id = 26, CountryId = 7 },
    new Team { Name = "Adesso Barselona", Id = 27, CountryId = 7 },
    new Team { Name = "Adesso Granada", Id = 28, CountryId = 7 },

    // Belçika
    new Team { Name = "Adesso Brüksel", Id = 29, CountryId = 8 },
    new Team { Name = "Adesso Brugge", Id = 30, CountryId = 8 },
    new Team { Name = "Adesso Gent", Id = 31, CountryId = 8 },
    new Team { Name = "Adesso Anvers", Id = 32, CountryId = 8 }
        );

    }



}
