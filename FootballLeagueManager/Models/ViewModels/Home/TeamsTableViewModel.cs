using FootballLeagueManager.Models.Entities.Main;
using Microsoft.AspNetCore.Html;

namespace FootballLeagueManager.Models.ViewModels.Home
{
    public class TeamsTableViewModel
    {
        public int SeasonId { get; set; }

        public int LeagueId { get; set; }

        public int Queue { get; set; }

        public IEnumerable<League> Leagues { get; set; }

        public IEnumerable<Team> Teams { get; set; }

        public IEnumerable<Match> Matches { get; set; }

        public IEnumerable<Season> Seasons { get; set; }


        public HtmlString RenderSeasons
        {
            get
            {
                var ret = "";
                foreach (var season in Seasons)
                {
                    var isSelected = SeasonId == season.Id ? "selected" : "";
                    ret += $@"<option value=""{season.Id}"" {isSelected}>{season.Name}</option>";
                }

                return new HtmlString(ret);
            }
        }

        public HtmlString RenderLeagues
        {
            get
            {
                var ret = "";
                foreach (var league in Leagues)
                {
                    var isSelected = LeagueId == league.Id ? "selected" : "";
                    ret += $@"<option value=""{league.Id}"" {isSelected}>{league.Name}</option>";
                }

                return new HtmlString(ret);
            }
        }

        public HtmlString RenderQueues
        {
            get
            {
                var ret = "";
                for (int i = 0; i < Matches.MaxBy(item => item.Queue).Queue; i++)
                {
                    var index = i + 1;
                    var isSelected = Queue == index ? "selected" : "";
                    ret += $@"<option value=""{index}"" {isSelected}>{index}</option>";
                }
     
                return new HtmlString(ret);
            }
        }
    }
}
