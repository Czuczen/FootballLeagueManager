namespace FootballLeagueManager.Models.Entities.Main;

public class League : Entity<int>
{
    public string Name { get; set; }

    public string Season { get; set; }

    public ICollection<Team> Teams { get; set; }

    public ICollection<Match> Matches { get; set; }
}