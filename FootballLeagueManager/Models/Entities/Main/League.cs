namespace FootballLeagueManager.Models.Entities.Main;

public class League : Entity<int>
{
    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public ICollection<Season> Seasons { get; set; }
}
