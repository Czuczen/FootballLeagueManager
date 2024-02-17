using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData;

public class MatchDataSeeder : ISeeder
{
    public int Order => 5;

    private readonly List<Match> _matches = new()
    {
        new Match
        {
            Id = 1,
            HomeTeamGoals = 1,
            AwayTeamGoals = 2,
            Date = new DateTime(2023, 11, 20),
            Queue = 1,
            HomeTeamId = 1,
            AwayTeamId = 2,
            SeasonId = 1
        },
        new Match
        {
            Id = 2,
            HomeTeamGoals = 3,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 2, 12),
            Queue = 1,
            HomeTeamId = 2,
            AwayTeamId = 3,
            SeasonId = 2
        },
        new Match
        {
            Id = 3,
            HomeTeamGoals = 1,
            AwayTeamGoals = 3,
            Date = new DateTime(2023, 6, 26),
            Queue = 2,
            HomeTeamId = 1,
            AwayTeamId = 3,
            SeasonId = 3
        }
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var match in _matches)
            modelBuilder.Entity<Match>().HasData(match);
    }
}
