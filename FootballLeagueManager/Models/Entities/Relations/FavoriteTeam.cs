namespace FootballLeagueManager.Models.Entities.Relations;

public class FavoriteTeam : Entity<int>
{
    public string UserId { get; set; }

    public int TeamId { get; set; }
}
