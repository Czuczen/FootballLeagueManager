using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData
{
    public class SeasonDataSeeder : ISeeder
    {
        public int Order => 3;

        private readonly List<Season> _seasons = new()
        {
            // === Belgium start ===
            // === Jupiler League start ===
            new Season 
            { 
                Id = 1,
                Name = "2022/2023",
                StartDate = new DateTime(2022, 7, 22),
                EndDate = new DateTime(2023, 6, 4),
                LeagueId = 1
            },
            // === Jupiler League end ===
            // === Challenger Pro League start ===
            new Season
            {
                Id = 2,
                Name = "2022/2023",
                StartDate = new DateTime(2022, 7, 22),
                EndDate = new DateTime(2023, 6, 4),
                LeagueId = 2
            },
            // === Challenger Pro League end ===
            // === Belgium end ===

            // === England start ===
            // === Premier League start ===
            new Season
            {
                Id = 3,
                Name = "2021/2022",
                StartDate = new DateTime(2021, 8, 14),
                EndDate = new DateTime(2022, 5, 22),
                LeagueId = 3
            },
            new Season
            {
                Id = 4,
                Name = "2022/2023",
                StartDate = new DateTime(2022, 8, 5),
                EndDate = new DateTime(2023, 5, 28),
                LeagueId = 3
            }
            // === Premier League end ===
            // === England end ===
        };

        public void Seed(ModelBuilder modelBuilder)
        {
            foreach (var season in _seasons)
                modelBuilder.Entity<Season>().HasData(season);
        }
    }
}
