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
            Name = "Aa"
        },
        new League
        {
            Id = 2,
            Name = "Bb"
        },
        new League
        {
            Id = 3,
            Name = "Cc"
        }
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var league in _leagues)
            modelBuilder.Entity<League>().HasData(league);
    }
}
