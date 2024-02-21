using FootballLeagueManager.Models.Entities.Main;
using FootballLeagueManager.Models.ViewModels;
using FootballLeagueManager.Models.ViewModels.Home;
using FootballLeagueManager.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace FootballLeagueManager.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<League, int> _leagueRepository;
    private readonly IRepository<Season, int> _seasonRepository;
    private readonly IRepository<FavoriteTeam, int> _favoriteTeamRepository;

    public HomeController(
        IRepository<League, int> leagueRepository,
        IRepository<Season, int> seasonRepository,
        IRepository<FavoriteTeam, int> favoriteTeamRepository
        )
    {
        _leagueRepository = leagueRepository;
        _seasonRepository = seasonRepository;
        _favoriteTeamRepository = favoriteTeamRepository;
    }

    public async Task<IActionResult> Index()
    {
        var ret = new List<LeagueViewModel>();

        var allLeaguesWithSeasons = await _leagueRepository.GetQuery(q => q.Include(l => l.Seasons)).ToListAsync();

        foreach (var league in allLeaguesWithSeasons)
        {
            ret.Add(new LeagueViewModel
            {
                League = league,
                Seasons = league.Seasons,
            });
        }

        return View(ret);
    }

    public async Task<IActionResult> LeagueTable(int seasonId)
    {
        var ret = new List<TeamTableViewModel>();
        var favoriteTeams = new List<FavoriteTeam>();

        var season = await _seasonRepository.GetQuery(q => q.Where(s => s.Id == seasonId)
            .Include(s => s.League).Include(s => s.Matches).Include(s => s.TeamsSeasonStats).ThenInclude(t => t.Team))
            .SingleAsync();

        var leagueSeasonTeams = season.TeamsSeasonStats.Select(stats => stats.Team).ToList();

        var isAuthenticated = User?.Identity?.IsAuthenticated ?? false;
        if (isAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            favoriteTeams = (await _favoriteTeamRepository.GetWhereAsync(item => item.UserId == userId)).ToList();
        }
        
        foreach (var teamSeasonStats in season.TeamsSeasonStats)
        {
            var matches = new List<MatchViewModel>();
            var teamId = teamSeasonStats.TeamId;

            foreach (var match in season.Matches.Where(item => item.HomeTeamId == teamId || item.AwayTeamId == teamId))
            {
                matches.Add(new MatchViewModel
                {
                    HomeTeamName = leagueSeasonTeams.Single(item => item.Id == match.HomeTeamId).Name,
                    AwayTeamName = leagueSeasonTeams.Single(item => item.Id == match.AwayTeamId).Name,
                    HomeTeamGoals = match.HomeTeamGoals,
                    AwayTeamGoals = match.AwayTeamGoals,
                    Date = match.Date,
                    Queue = match.Queue,
                    SeasonName = season.Name
                });
            }

            ret.Add(new TeamTableViewModel
            {
                Team = teamSeasonStats.Team,
                Favorite = favoriteTeams.FirstOrDefault(item => item.TeamId == teamSeasonStats.TeamId) != null,
                TeamSeasonStats = teamSeasonStats,
                Matches = matches
            });
        }

        ViewBag.LeagueName = season.League.Name;
        ViewBag.SeasonName = season.Name;

        return View(ret);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddOrRemoveFavoriteTeam(int teamId, bool isFavorite)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        if (isFavorite)
        {
            var existingFavoriteTeamRelation = await _favoriteTeamRepository.GetWhereAsync(item =>
                item.UserId == userId && item.TeamId == teamId);

            await _favoriteTeamRepository.DeleteAsync(existingFavoriteTeamRelation.Single());
        }
        else
        {
            var favoriteTeamRelation = await _favoriteTeamRepository.CreateAsync(new FavoriteTeam
            {
                UserId = userId,
                TeamId = teamId,
            });
        }

        return Ok();
    }

    [Authorize]
    public async Task<IActionResult> GetFavoriteTeams()
    {
        var ret = new List<TeamTableViewModel>();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var favoriteTeams = await _favoriteTeamRepository.GetQuery(q => q.Where(item => item.UserId == userId)
            .Include(r => r.Team)
                .ThenInclude(t => t.TeamSeasonsStats)
                    .ThenInclude(ts => ts.Season)
                        .ThenInclude(s => s.Matches)
                            .ThenInclude(m => m.HomeTeam)
            .Include(r => r.Team)
                .ThenInclude(t => t.TeamSeasonsStats)
                    .ThenInclude(ts => ts.Season)
                        .ThenInclude(s => s.Matches)
                            .ThenInclude(m => m.AwayTeam))
            .ToListAsync();

        foreach (var favoriteTeam in favoriteTeams)
        {
            var matches = new List<MatchViewModel>();
            var teamMatches = new List<Match>();
            var teamSeasons = new List<Season>();

            foreach (var item in favoriteTeam.Team.TeamSeasonsStats)
            {
                teamSeasons.Add(item.Season);
                teamMatches.AddRange(item.Season.Matches.Where(m =>
                    m.HomeTeamId == favoriteTeam.TeamId || m.AwayTeamId == favoriteTeam.TeamId));
            }
            
            foreach (var match in teamMatches)
            {
                matches.Add(new MatchViewModel
                {
                    HomeTeamName = match.HomeTeam.Name,
                    AwayTeamName = match.AwayTeam.Name,
                    HomeTeamGoals = match.HomeTeamGoals,
                    AwayTeamGoals = match.AwayTeamGoals,
                    Date = match.Date,
                    Queue = match.Queue,
                    SeasonName = teamSeasons.Single(ts => ts.Id == match.SeasonId).Name
                });
            }

            ret.Add(new TeamTableViewModel
            {
                Team = favoriteTeam.Team,
                Favorite = favoriteTeams.FirstOrDefault(item => item.TeamId == favoriteTeam.TeamId) != null,
                Matches = matches
            });
        }

        ViewBag.IsFavoriteTeamsTab = true;

        return View("LeagueTable", ret);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}