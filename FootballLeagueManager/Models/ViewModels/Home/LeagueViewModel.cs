using FootballLeagueManager.Models.Entities.Main;
using Microsoft.AspNetCore.Html;

namespace FootballLeagueManager.Models.ViewModels.Home;

public class LeagueViewModel
{
    public League League {  get; set; }

    public IEnumerable<Season> Seasons { get; set; }

    public string SeasonTagId => "season-" + League.Id;

    public HtmlString RenderSeasons
    {
        get
        {
            var ret = "";
            var latestSeason = Seasons.MaxBy(item => item.StartDate);

            foreach (var season in Seasons)
            {
                var isSelected = latestSeason?.Id == season.Id ? "selected" : "";
                ret += $@"<option value=""{season.Id}"" {isSelected}>{season.Name}</option>";
            }

            return new HtmlString(ret);
        }
    }
}