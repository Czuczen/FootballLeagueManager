using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData
{
    public class TeamSeasonDataSeeder : ISeeder
    {
        public int Order => 4;

        private readonly List<TeamSeason> _teamSeasons = new()
        {
            new TeamSeason
            {
                Id = 1,
                MatchesPlayed = 9,
                Wins = 5,
                Draws = 1,
                Losses = 3,
                Points = 20,
                TeamId = 1,
                SeasonId = 1
            },
            new TeamSeason
            {
                Id = 2,
                MatchesPlayed = 10,
                Wins = 6,
                Draws = 1,
                Losses = 3,
                Points = 45,
                TeamId = 1,
                SeasonId = 1
            },
            new TeamSeason
            {
                Id = 3,
                MatchesPlayed = 10,
                Wins = 6,
                Draws = 2,
                Losses = 2,
                Points = 5,
                TeamId = 1,
                SeasonId = 1
            }
        };

        public void Seed(ModelBuilder modelBuilder)
        {
            foreach (var teamSeason in _teamSeasons)
                modelBuilder.Entity<TeamSeason>().HasData(teamSeason);
        }
    }
}
