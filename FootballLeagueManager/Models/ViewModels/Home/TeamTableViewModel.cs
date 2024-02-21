using FootballLeagueManager.Models.Entities.Main;

namespace FootballLeagueManager.Models.ViewModels.Home;

public class TeamTableViewModel
{
    public Team Team { get; set; }

    public bool Favorite { get; set; }

    public TeamSeasonStats TeamSeasonStats { get; set; }

    public IEnumerable<MatchViewModel> Matches { get; set; }
}