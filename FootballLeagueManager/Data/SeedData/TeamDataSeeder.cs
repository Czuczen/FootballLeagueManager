using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData;

public class TeamDataSeeder : ISeeder
{
    public int Order => 2;

    private readonly List<Team> _teams = new()
    {
        new Team
        {
            Id = 1,
            Name = "Aa",
            Country = "Aa",
            LeagueId = 1
        },
        new Team
        {
            Id = 2,
            Name = "Bb",
            Country = "Bb",
            LeagueId = 2
        },
        new Team
        {
            Id = 3,
            Name = "Cc",
            Country = "Cc",
            LeagueId = 3
        }
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var team in _teams)
            modelBuilder.Entity<Team>().HasData(team);
    }
}
