namespace FootballLeagueManager.Models.Entities.Main;

public class FavoriteTeam : Entity<int>
{
    public string UserId { get; set; }

    public int TeamId { get; set; }

    public Team Team { get; set; }
}
