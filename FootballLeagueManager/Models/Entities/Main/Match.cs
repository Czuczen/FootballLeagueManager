namespace FootballLeagueManager.Models.Entities.Main;

public class Match : Entity<int>
{
    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }

    public DateTime Date { get; set; }

    public int Queue { get; set; }

    public int LeagueId { get; set; }
}