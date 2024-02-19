using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData;

public class TeamDataSeeder : ISeeder
{
    public int Order => 2;

    private readonly List<Team> _teams = new()
    {
        // === Belgium start ===

        // === Jupiler League start ===
        new Team
        {
            Id = 1,
            Name = "Genk",
            Country = "Belgia"
        },
        new Team
        {
            Id = 2,
            Name = "Royale Union SG",
            Country = "Belgia"
        },
        new Team
        {
            Id = 3,
            Name = "Antwerp",
            Country = "Belgia"
        },
        new Team
        {
            Id = 4,
            Name = "Club Brugge",
            Country = "Belgia"
        },
        new Team
        {
            Id = 5,
            Name = "Gent",
            Country = "Belgia"
        },
        new Team
        {
            Id = 6,
            Name = "St. Liege",
            Country = "Belgia"
        },
        new Team
        {
            Id = 7,
            Name = "Westerlo",
            Country = "Belgia"
        },
        new Team
        {
            Id = 8,
            Name = "Cercle Brugge",
            Country = "Belgia"
        },
        new Team
        {
            Id = 9,
            Name = "Charleroi",
            Country = "Belgia"
        },
        new Team
        {
            Id = 10,
            Name = "Leuven",
            Country = "Belgia"
        },
        new Team
        {
            Id = 11,
            Name = "Anderlecht",
            Country = "Belgia"
        },
        new Team
        {
            Id = 12,
            Name = "St. Truiden",
            Country = "Belgia"
        },
        new Team
        {
            Id = 13,
            Name = "KV Mechelen",
            Country = "Belgia"
        },
        new Team
        {
            Id = 14,
            Name = "Kortrijk",
            Country = "Belgia"
        },
        new Team
        {
            Id = 15,
            Name = "Eupen",
            Country = "Belgia"
        },
        new Team
        {
            Id = 16,
            Name = "Oostende",
            Country = "Belgia"
        },
        new Team
        {
            Id = 17,
            Name = "Waregem",
            Country = "Belgia"
        },
        new Team
        {
            Id = 18,
            Name = "Seraing",
            Country = "Belgia"
        },
        // === Jupiler League end ===

        // === Challenger Pro League start ===
        new Team
        {
            Id = 19,
            Name = "RWDM",
            Country = "Belgia"
        },
        new Team
        {
            Id = 20,
            Name = "Beveren",
            Country = "Belgia"
        },
        // === Challenger Pro League end ===
        // === Belgium end ===



        // === England start ===
        // === Premier League start ===
        new Team
        {
            Id = 21,
            Name = "Manchester City",
            Country = "Anglia"
        },
        new Team
        {
            Id = 22,
            Name = "Liverpool",
            Country = "Anglia"
        },
        new Team
        {
            Id = 23,
            Name = "Chelsea",
            Country = "Anglia"
        },
        new Team
        {
            Id = 24,
            Name = "Tottenham",
            Country = "Anglia"
        },
        new Team
        {
            Id = 25,
            Name = "Arsenal",
            Country = "Anglia"
        },
        new Team
        {
            Id = 26,
            Name = "Manchester Utd",
            Country = "Anglia"
        },
        new Team
        {
            Id = 27,
            Name = "West Ham",
            Country = "Anglia"
        }
        // === Premier League end ===
        // === England end ===
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var team in _teams)
            modelBuilder.Entity<Team>().HasData(team);
    }
}
