namespace FootballLeagueManager.Models.Entities.Main;

public class Season : Entity<int>
{
    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int LeagueId { get; set; }

    public League League { get; set; }

    public ICollection<Match> Matches { get; set; }

    public ICollection<TeamSeasonStats> TeamsSeasonStats { get; set; }
}
