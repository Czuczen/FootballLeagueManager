using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData
{
    public class TeamSeasonStatsDataSeeder : ISeeder
    {
        public int Order => 4;

        private readonly List<TeamSeasonStats> _teamSeasonsStats = new()
        {
            // === Belgium start ===

            // === Jupiler League start ===
            new TeamSeasonStats
            {
                Id = 1,
                MatchesPlayed = 34,
                Wins = 23,
                Draws = 6,
                Losses = 5,
                Points = 75,
                TeamId = 1,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 2,
                MatchesPlayed = 34,
                Wins = 23,
                Draws = 6,
                Losses = 5,
                Points = 75,
                TeamId = 2,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 3,
                MatchesPlayed = 34,
                Wins = 22,
                Draws = 6,
                Losses = 6,
                Points = 72,
                TeamId = 3,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 4,
                MatchesPlayed = 34,
                Wins = 16,
                Draws = 11,
                Losses = 7,
                Points = 59,
                TeamId = 4,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 5,
                MatchesPlayed = 34,
                Wins = 16,
                Draws = 8,
                Losses = 10,
                Points = 56,
                TeamId = 5,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 6,
                MatchesPlayed = 34,
                Wins = 16,
                Draws = 7,
                Losses = 11,
                Points = 55,
                TeamId = 6,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 7,
                MatchesPlayed = 34,
                Wins = 14,
                Draws = 9,
                Losses = 11,
                Points = 51,
                TeamId = 7,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 8,
                MatchesPlayed = 34,
                Wins = 13,
                Draws = 11,
                Losses = 10,
                Points = 50,
                TeamId = 8,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 9,
                MatchesPlayed = 34,
                Wins = 14,
                Draws = 6,
                Losses = 14,
                Points = 48,
                TeamId = 9,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 10,
                MatchesPlayed = 34,
                Wins = 13,
                Draws = 9,
                Losses = 12,
                Points = 48,
                TeamId = 10,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 11,
                MatchesPlayed = 34,
                Wins = 13,
                Draws = 9,
                Losses = 12,
                Points = 46,
                TeamId = 11,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 12,
                MatchesPlayed = 34,
                Wins = 11,
                Draws = 9,
                Losses = 14,
                Points = 42,
                TeamId = 12,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 13,
                MatchesPlayed = 34,
                Wins = 11,
                Draws = 7,
                Losses = 16,
                Points = 40,
                TeamId = 13,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 14,
                MatchesPlayed = 34,
                Wins = 8,
                Draws = 7,
                Losses = 19,
                Points = 31,
                TeamId = 14,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 15,
                MatchesPlayed = 34,
                Wins = 7,
                Draws = 7,
                Losses = 20,
                Points = 28,
                TeamId = 15,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 16,
                MatchesPlayed = 34,
                Wins = 7,
                Draws = 6,
                Losses = 21,
                Points = 27,
                TeamId = 16,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 17,
                MatchesPlayed = 34,
                Wins = 6,
                Draws = 9,
                Losses = 19,
                Points = 27,
                TeamId = 17,
                SeasonId = 1
            },
            new TeamSeasonStats
            {
                Id = 18,
                MatchesPlayed = 34,
                Wins = 5,
                Draws = 5,
                Losses = 24,
                Points = 20,
                TeamId = 18,
                SeasonId = 1
            },
            // === Jupiler League end ===

            // === Challenger Pro League start ===
            new TeamSeasonStats
            {
                Id = 19,
                MatchesPlayed = 22,
                Wins = 14,
                Draws = 4,
                Losses = 4,
                Points = 46,
                TeamId = 19,
                SeasonId = 2
            },
            new TeamSeasonStats
            {
                Id = 20,
                MatchesPlayed = 22,
                Wins = 12,
                Draws = 7,
                Losses = 3,
                Points = 43,
                TeamId = 20,
                SeasonId = 2
            },
            // === Challenger Pro League end ===

            // === Belgium end ===



            // === England start ===
            // === Premier League start ===
            // season 2021/2022
            new TeamSeasonStats
            {
                Id = 21,
                MatchesPlayed = 38,
                Wins = 29,
                Draws = 6,
                Losses = 3,
                Points = 93,
                TeamId = 21,
                SeasonId = 3
            },
            new TeamSeasonStats
            {
                Id = 22,
                MatchesPlayed = 38,
                Wins = 28,
                Draws = 8,
                Losses = 2,
                Points = 92,
                TeamId = 22,
                SeasonId = 3
            },
            new TeamSeasonStats
            {
                Id = 23,
                MatchesPlayed = 38,
                Wins = 21,
                Draws = 11,
                Losses = 6,
                Points = 74,
                TeamId = 23,
                SeasonId = 3
            },
            new TeamSeasonStats
            {
                Id = 24,
                MatchesPlayed = 38,
                Wins = 22,
                Draws = 5,
                Losses = 11,
                Points = 71,
                TeamId = 24,
                SeasonId = 3
            },
            new TeamSeasonStats
            {
                Id = 25,
                MatchesPlayed = 38,
                Wins = 22,
                Draws = 3,
                Losses = 13,
                Points = 69,
                TeamId = 25,
                SeasonId = 3
            },
            new TeamSeasonStats
            {
                Id = 26,
                MatchesPlayed = 38,
                Wins = 16,
                Draws = 10,
                Losses = 12,
                Points = 58,
                TeamId = 26,
                SeasonId = 3
            },
            // season 2022/2023
            new TeamSeasonStats
            {
                Id = 27,
                MatchesPlayed = 38,
                Wins = 28,
                Draws = 5,
                Losses = 5,
                Points = 89,
                TeamId = 21,
                SeasonId = 4
            },
            new TeamSeasonStats
            {
                Id = 28,
                MatchesPlayed = 38,
                Wins = 19,
                Draws = 10,
                Losses = 9,
                Points = 67,
                TeamId = 22,
                SeasonId = 4
            },
            new TeamSeasonStats
            {
                Id = 29,
                MatchesPlayed = 38,
                Wins = 11,
                Draws = 11,
                Losses = 16,
                Points = 44,
                TeamId = 23,
                SeasonId = 4
            },
            new TeamSeasonStats
            {
                Id = 30,
                MatchesPlayed = 38,
                Wins = 18,
                Draws = 6,
                Losses = 14,
                Points = 60,
                TeamId = 24,
                SeasonId = 4
            },
            new TeamSeasonStats
            {
                Id = 31,
                MatchesPlayed = 38,
                Wins = 26,
                Draws = 6,
                Losses = 6,
                Points = 84,
                TeamId = 25,
                SeasonId = 4
            },
            new TeamSeasonStats
            {
                Id = 32,
                MatchesPlayed = 38,
                Wins = 23,
                Draws = 6,
                Losses = 9,
                Points = 75,
                TeamId = 26,
                SeasonId = 4
            },
             new TeamSeasonStats
            {
                Id = 33,
                MatchesPlayed = 38,
                Wins = 11,
                Draws = 7,
                Losses = 20,
                Points = 40,
                TeamId = 27,
                SeasonId = 4
            }
            // === Premier League end ===
            // === England end ===
        };

        public void Seed(ModelBuilder modelBuilder)
        {
            foreach (var teamSeasonStats in _teamSeasonsStats)
                modelBuilder.Entity<TeamSeasonStats>().HasData(teamSeasonStats);
        }
    }
}
