using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FootballLeagueManager.Data.SeedData;

public class MatchDataSeeder : ISeeder
{
    public int Order => 3;

    private readonly List<Match> _matches = new()
    {
        new Match
        {
            Id = 1,
            HomeTeamId = 1,
            AwayTeamId = 2,
            Date = new DateTime(2023, 11, 20),
            Queue = 1,
            LeagueId = 1
        },
        new Match
        {
            Id = 2,
            HomeTeamId = 2,
            AwayTeamId = 3,
            Date = new DateTime(2023, 2, 12),
            Queue = 1,
            LeagueId = 2
        },
        new Match
        {
            Id = 3,
            HomeTeamId = 1,
            AwayTeamId = 3,
            Date = new DateTime(2023, 6, 26),
            Queue = 1,
            LeagueId = 3
        },
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var match in _matches)
            modelBuilder.Entity<Match>().HasData(match);
    }
}
