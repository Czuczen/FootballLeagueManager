namespace FootballLeagueManager.Models.Entities.Main
{
    public class TeamSeason
    {
        public int MatchesPlayed { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public int Points { get; set; }

        public int TeamId { get; set; }

        public int SeasonId { get; set; }

        public int LeagueId { get; set; }
    }
}
