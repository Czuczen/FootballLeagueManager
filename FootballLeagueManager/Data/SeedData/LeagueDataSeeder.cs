using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData;

public class LeagueDataSeeder : ISeeder
{
    public int Order => 1;

    private readonly List<League> _leagues = new()
    {
        // === Belgium start ===
        new League 
        { 
            Id = 1,
            Name = "Jupiler League",
            ImageUrl = "https://assets.skor.id/crop/0x0:0x0/x/photo/2020/04/02/574196038.jpg"
        },
        new League
        {
            Id = 2,
            Name = "Challenger Pro League",
            ImageUrl = "https://statics-maker.llt-services.com/prl/images/2023/09/28/xlarge/deac0d81-f6a8-41ed-bdd8-794da335dd68.png"
        },
        // === Belgium end ===

        // === England start ===
        new League
        {
            Id = 3,
            Name = "Premier League",
            ImageUrl = "https://static.vecteezy.com/system/resources/previews/010/994/451/non_2x/premier-league-logo-symbol-with-name-design-england-football-european-countries-football-teams-illustration-with-purple-background-free-vector.jpg"
        }
        // === England end ===
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var league in _leagues)
            modelBuilder.Entity<League>().HasData(league);
    }
}
