namespace FootballLeagueManager.Models.Entities.Main;

public class Team : Entity<int>
{
    public string Name { get; set; }

    public string Country { get; set; }

    public ICollection<TeamSeasonStats> TeamSeasonsStats { get; set; }
}
