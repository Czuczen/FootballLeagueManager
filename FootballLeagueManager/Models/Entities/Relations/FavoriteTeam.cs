namespace FootballLeagueManager.Models.Entities.Relations
{
    public class FavoriteTeam : Entity<int>
    {
        public int UserId { get; set; }

        public int TeamId { get; set; }
    }
}
