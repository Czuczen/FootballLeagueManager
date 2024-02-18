using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData
{
    public class SeasonDataSeeder : ISeeder
    {
        public int Order => 3;

        private readonly List<Season> _seasons = new()
        {
            new Season 
            { 
                Id = 1,
                Name = "2022/2023",
                StartDate = new DateTime(2022, 11, 20),
                EndDate = new DateTime(2023, 10, 20),
                LeagueId = 1
            },
            new Season
            {
                Id = 2,
                Name = "2022/2023",
                StartDate = new DateTime(2022, 11, 20),
                EndDate = new DateTime(2023, 8, 20),
                LeagueId = 2
            },
            new Season
            {
                Id = 3,
                Name = "2022/2023",
                StartDate = new DateTime(2022, 11, 20),
                EndDate = new DateTime(2023, 11, 20),
                LeagueId = 3
            }
        };

        public void Seed(ModelBuilder modelBuilder)
        {
            foreach (var season in _seasons)
                modelBuilder.Entity<Season>().HasData(season);
        }
    }
}
