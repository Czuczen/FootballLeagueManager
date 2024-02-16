using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData;

public class LeagueDataSeeder : ISeeder
{
    public int Order => 1;

    private readonly List<League> _leagues = new()
    {
        new League 
        { 
            Id = 1,
            Name = "Aa",
            Season = "Aa"
        },
        new League
        {
            Id = 2,
            Name = "Bb",
            Season = "Bb"
        },
        new League
        {
            Id = 3,
            Name = "Cc",
            Season = "Cc"
        }
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var league in _leagues)
            modelBuilder.Entity<League>().HasData(league);
    }
}
