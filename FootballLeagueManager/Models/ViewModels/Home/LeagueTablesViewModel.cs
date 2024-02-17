using FootballLeagueManager.Models.Entities.Main;

namespace FootballLeagueManager.Models.ViewModels.Home
{
    public class LeagueTablesViewModel
    {
        public IEnumerable<League> Leagues { get; set; }

        public IEnumerable<Team> Teams { get; set; }

        public IEnumerable<Match> Matches { get; set; }
    }
}
