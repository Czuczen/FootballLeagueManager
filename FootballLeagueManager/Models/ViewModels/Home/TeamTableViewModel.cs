using FootballLeagueManager.Models.Entities.Main;
using Microsoft.AspNetCore.Html;

namespace FootballLeagueManager.Models.ViewModels.Home
{
    public class TeamTableViewModel
    {
        public Team Team { get; set; }

        public bool Favorite { get; set; }

        public TeamSeason TeamSeasonStats { get; set; }

        public IEnumerable<MatchViewModel> Matches { get; set; }
    }
}
