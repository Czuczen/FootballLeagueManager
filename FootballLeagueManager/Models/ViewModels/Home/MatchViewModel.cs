namespace FootballLeagueManager.Models.ViewModels.Home
{
    public class MatchViewModel
    {
        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime Date { get; set; }

        public int Queue { get; set; }
    }
}
