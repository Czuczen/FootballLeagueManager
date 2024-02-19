using FootballLeagueManager.Models.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData;

public class MatchDataSeeder : ISeeder
{
    public int Order => 5;

    private readonly List<Match> _matches = new()
    {
        // === Belgium start ===
        // === Jupiler League start ===
        //   == Genk start ==
        new Match
        {
            Id = 1,
            HomeTeamGoals = 2,
            AwayTeamGoals = 2,
            Date = new DateTime(2023, 4, 23, 18, 30, 0),
            Queue = 1,
            HomeTeamId = 9,
            AwayTeamId = 1,
            SeasonId = 1
        },
        new Match
        {
            Id = 2,
            HomeTeamGoals = 5,
            AwayTeamGoals = 2,
            Date = new DateTime(2023, 4, 16, 13, 30, 0),
            Queue = 1,
            HomeTeamId = 1,
            AwayTeamId = 11,
            SeasonId = 1
        },
        new Match
        {
            Id = 3,
            HomeTeamGoals = 2,
            AwayTeamGoals = 0,
            Date = new DateTime(2023, 4, 9, 18, 30, 0),
            Queue = 2,
            HomeTeamId = 6,
            AwayTeamId = 1,
            SeasonId = 1
        },
        new Match
        {
            Id = 4,
            HomeTeamGoals = 2,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 4, 2, 13, 30, 0),
            Queue = 2,
            HomeTeamId = 1,
            AwayTeamId = 10,
            SeasonId = 1
        },
        new Match
        {
            Id = 5,
            HomeTeamGoals = 1,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 3, 17, 20, 45, 0),
            Queue = 2,
            HomeTeamId = 8,
            AwayTeamId = 1,
            SeasonId = 1
        },
        //   == Genk end ==


        //   == Royale Union SG start ==
        new Match
        {
            Id = 6,
            HomeTeamGoals = 2,
            AwayTeamGoals = 4,
            Date = new DateTime(2023, 4, 23, 18, 30, 0),
            Queue = 1,
            HomeTeamId = 14,
            AwayTeamId = 2,
            SeasonId = 1
        },
        new Match
        {
            Id = 7,
            HomeTeamGoals = 2,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 4, 16, 19, 15, 0),
            Queue = 1,
            HomeTeamId = 2,
            AwayTeamId = 18,
            SeasonId = 1
        },
        new Match
        {
            Id = 8,
            HomeTeamGoals = 1,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 4, 8, 20, 45, 0),
            Queue = 1,
            HomeTeamId = 1,
            AwayTeamId = 2,
            SeasonId = 1
        },
        new Match
        {
            Id = 9,
            HomeTeamGoals = 2,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 4, 2, 19, 15, 0),
            Queue = 2,
            HomeTeamId = 2,
            AwayTeamId = 12,
            SeasonId = 1
        },
        new Match
        {
            Id = 10,
            HomeTeamGoals = 2,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 3, 19, 18, 30, 0),
            Queue = 2,
            HomeTeamId = 2,
            AwayTeamId = 13,
            SeasonId = 1
        },
        //   == Royale Union SG end ==
        
        //    == Antwerp start ==
        new Match
        {
            Id = 11,
            HomeTeamGoals = 0,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 4, 23, 13, 30, 0),
            Queue = 1,
            HomeTeamId = 12,
            AwayTeamId = 3,
            SeasonId = 1
        },
        new Match
        {
            Id = 12,
            HomeTeamGoals = 1,
            AwayTeamGoals = 0,
            Date = new DateTime(2023, 4, 16, 18, 30, 0),
            Queue = 1,
            HomeTeamId = 3,
            AwayTeamId = 14,
            SeasonId = 1
        },
        new Match
        {
            Id = 13,
            HomeTeamGoals = 2,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 4, 9, 16, 00, 0),
            Queue = 1,
            HomeTeamId = 3,
            AwayTeamId = 8,
            SeasonId = 1
        },
        new Match
        {
            Id = 14,
            HomeTeamGoals = 0,
            AwayTeamGoals = 2,
            Date = new DateTime(2023, 3, 31, 20, 45, 0),
            Queue = 2,
            HomeTeamId = 17,
            AwayTeamId = 3,
            SeasonId = 1
        },
        new Match
        {
            Id = 15,
            HomeTeamGoals = 0,
            AwayTeamGoals = 1,
            Date = new DateTime(2023, 3, 19, 13, 30, 0),
            Queue = 1,
            HomeTeamId = 3,
            AwayTeamId = 9,
            SeasonId = 1
        },
        //   == Antwerp end ==

        //   == Club Brugge start ==
        new Match
        {
            Id = 16,
            HomeTeamGoals = 7,
            AwayTeamGoals = 0,
            Date = new DateTime(2023, 4, 23, 18, 30, 0),
            Queue = 1,
            HomeTeamId = 4,
            AwayTeamId = 15,
            SeasonId = 1
        },
        //  == Club Brugge end ==
        // === Jupiler League end ===

        // === Challenger Pro League start ===
        //  == RWDM start ==
        new Match
        {
            Id = 17,
            HomeTeamGoals = 1,
            AwayTeamGoals = 0,
            Date = new DateTime(2023, 2, 12, 19, 15, 0),
            Queue = 1,
            HomeTeamId = 19,
            AwayTeamId = 20,
            SeasonId = 2
        },
        //  == RWDM end ==
        // === Challenger Pro League end ===
        // === Belgium end ===



        // === England start ===
        // === Premier League start ===

        //  == Manchester City start ==
        // season 2021/2022 start
        new Match
        {
            Id = 18,
            HomeTeamGoals = 1,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 21,
            AwayTeamId = 22,
            SeasonId = 3
        },
        new Match
        {
            Id = 19,
            HomeTeamGoals = 1,
            AwayTeamGoals = 2,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 23,
            AwayTeamId = 21,
            SeasonId = 3
        },
        //  == Manchester City end ==


        //  == Liverpool start ==
        new Match
        {
            Id = 20,
            HomeTeamGoals = 2,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 4, 22, 18, 00, 0),
            Queue = 1,
            HomeTeamId = 22,
            AwayTeamId = 23,
            SeasonId = 3
        },
        new Match
        {
            Id = 21,
            HomeTeamGoals = 1,
            AwayTeamGoals = 2,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 24,
            AwayTeamId = 22,
            SeasonId = 3
        },
        //  == Liverpool end ==


        //  == Chelsea start ==
        new Match
        {
            Id = 22,
            HomeTeamGoals = 3,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 23,
            AwayTeamId = 24,
            SeasonId = 3
        },
        new Match
        {
            Id = 23,
            HomeTeamGoals = 1,
            AwayTeamGoals = 2,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 25,
            AwayTeamId = 23,
            SeasonId = 3
        },
        //  == Chelsea end ==


        //  == Arsenal start ==
        new Match
        {
            Id = 24,
            HomeTeamGoals = 2,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 2,
            HomeTeamId = 25,
            AwayTeamId = 26,
            SeasonId = 3
        },
        new Match
        {
            Id = 25,
            HomeTeamGoals = 3,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 5, 11, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 24,
            AwayTeamId = 25,
            SeasonId = 3
        },
        //  == Arsenal end ==
        // season 2021/2022 end


        // season 2022/2023 start
        new Match
        {
            Id = 26,
            HomeTeamGoals = 2,
            AwayTeamGoals = 1,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 21,
            AwayTeamId = 22,
            SeasonId = 4
        },
        new Match
        {
            Id = 27,
            HomeTeamGoals = 1,
            AwayTeamGoals = 3,
            Date = new DateTime(2022, 5, 22, 13, 00, 0),
            Queue = 1,
            HomeTeamId = 23,
            AwayTeamId = 21,
            SeasonId = 4
        },
        //  == Manchester City end ==


        //  == Liverpool start ==
        new Match
        {
            Id = 28,
            HomeTeamGoals = 1,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 4, 22, 11, 00, 0),
            Queue = 1,
            HomeTeamId = 22,
            AwayTeamId = 23,
            SeasonId = 4
        },
        new Match
        {
            Id = 29,
            HomeTeamGoals = 1,
            AwayTeamGoals = 3,
            Date = new DateTime(2022, 5, 22, 19, 00, 0),
            Queue = 1,
            HomeTeamId = 24,
            AwayTeamId = 22,
            SeasonId = 4
        },
        //  == Liverpool end ==


        //  == Chelsea start ==
        new Match
        {
            Id = 30,
            HomeTeamGoals = 3,
            AwayTeamGoals = 1,
            Date = new DateTime(2022, 6, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 23,
            AwayTeamId = 24,
            SeasonId = 4
        },
        new Match
        {
            Id = 31,
            HomeTeamGoals = 5,
            AwayTeamGoals = 2,
            Date = new DateTime(2022, 5, 23, 17, 00, 0),
            Queue = 2,
            HomeTeamId = 25,
            AwayTeamId = 23,
            SeasonId = 4
        },
        //  == Chelsea end ==


        //  == Arsenal start ==
        new Match
        {
            Id = 32,
            HomeTeamGoals = 2,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 5, 22, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 25,
            AwayTeamId = 26,
            SeasonId = 4
        },
        new Match
        {
            Id = 33,
            HomeTeamGoals = 2,
            AwayTeamGoals = 0,
            Date = new DateTime(2022, 5, 11, 17, 00, 0),
            Queue = 1,
            HomeTeamId = 24,
            AwayTeamId = 25,
            SeasonId = 4
        },
        //  == Arsenal end ==

        //  == West Ham start ==
        new Match
        {
            Id = 34,
            HomeTeamGoals = 1,
            AwayTeamGoals = 3,
            Date = new DateTime(2022, 11, 11, 18, 15, 0),
            Queue = 1,
            HomeTeamId = 27,
            AwayTeamId = 26,
            SeasonId = 4
        }
        //  == West Ham end ==
        // season 2022/2023 end
        
        // === Premier League end ===
        // === England end ===
    };

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var match in _matches)
            modelBuilder.Entity<Match>().HasData(match);
    }
}
