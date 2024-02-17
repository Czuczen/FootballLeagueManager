namespace FootballLeagueManager.Models.Entities.Main;

public class Team : Entity<int>
{
    public string Name { get; set; }

    public string Country { get; set; }

    public int MatchesPlayed { get; set; }

    public int Wins { get; set; }

    public int Draws { get; set; }

    public int Losses { get; set; }

    public int Points { get; set; }

    public int LeagueId { get; set; }
}