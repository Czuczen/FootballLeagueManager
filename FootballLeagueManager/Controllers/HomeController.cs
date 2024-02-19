using FootballLeagueManager.Models.Entities.Main;
using FootballLeagueManager.Models.ViewModels;
using FootballLeagueManager.Models.ViewModels.Home;
using FootballLeagueManager.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FootballLeagueManager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository<League, int> _leagueRepository;
    private readonly IRepository<Team, int> _teamRepository;
    private readonly IRepository<Match, int> _matchRepository;
    private readonly IRepository<TeamSeasonStats, int> _teamSeasonStatsRepository;
    private readonly IRepository<Season, int> _seasonRepository;
    private readonly IRepository<FavoriteTeam, int> _favoriteTeamRepository;

    public HomeController(
        ILogger<HomeController> logger,
        IRepository<League, int> leagueRepository,
        IRepository<Team, int> teamRepository,
        IRepository<Match, int> matchRepository,
        IRepository<TeamSeasonStats, int> teamSeasonStatsRepository,
        IRepository<Season, int> seasonRepository,
        IRepository<FavoriteTeam, int> favoriteTeamRepository
        )
    {
        _logger = logger;
        _leagueRepository = leagueRepository;
        _teamRepository = teamRepository;
        _matchRepository = matchRepository;
        _teamSeasonStatsRepository = teamSeasonStatsRepository;
        _seasonRepository = seasonRepository;
        _favoriteTeamRepository = favoriteTeamRepository;
    }

    public async Task<IActionResult> Index()
    {
        var ret = new List<LeagueViewModel>();

        var allLeagues = await _leagueRepository.GetAllAsync();
        var allSeasons = await _seasonRepository.GetAllAsync();

        foreach (var league in allLeagues)
        {
            ret.Add(new LeagueViewModel
            {
                League = league,
                Seasons = allSeasons.Where(item => item.LeagueId == league.Id),
            });
        }

        return View(ret);
    }

    public async Task<IActionResult> LeagueTable(int seasonId)
    {
        var ret = new List<TeamTableViewModel>();
        var favoriteTeams = new List<FavoriteTeam>();

        var season = await _seasonRepository.GetByIdAsync(seasonId);
        var league = await _leagueRepository.GetByIdAsync(season.LeagueId);
        var allTeams = await _teamRepository.GetAllAsync();
        var teamsSeasonStats = await _teamSeasonStatsRepository.GetWhereAsync(item => item.SeasonId == seasonId);   
        var availableTeams = allTeams.Where(item => teamsSeasonStats.Any(stats => stats.TeamId == item.Id));
        var availableMatches = await _matchRepository.GetWhereAsync(item => item.SeasonId == seasonId);

        var isAuthenticated = User?.Identity?.IsAuthenticated ?? false;
        if (isAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            favoriteTeams = (await _favoriteTeamRepository.GetWhereAsync(item => item.UserId == userId)).ToList();
        }
        
        foreach (var team in availableTeams)
        {
            var matches = new List<MatchViewModel>();

            foreach (var match in availableMatches.Where(item => item.HomeTeamId == team.Id || item.AwayTeamId == team.Id))
            {
                matches.Add(new MatchViewModel
                {
                    HomeTeamName = availableTeams.Single(item => item.Id == match.HomeTeamId).Name,
                    AwayTeamName = availableTeams.Single(item => item.Id == match.AwayTeamId).Name,
                    HomeTeamGoals = match.HomeTeamGoals,
                    AwayTeamGoals = match.AwayTeamGoals,
                    Date = match.Date,
                    Queue = match.Queue,
                    SeasonName = season.Name
                });
            }

            ret.Add(new TeamTableViewModel
            {
                Team = team,
                Favorite = favoriteTeams.FirstOrDefault(item => item.TeamId == team.Id) != null,
                TeamSeasonStats = teamsSeasonStats.Single(item => item.TeamId == team.Id),
                Matches = matches
            });
        }

        ViewBag.LeagueName = league.Name;
        ViewBag.SeasonName = season.Name;

        return View(ret);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrRemoveFavoriteTeam(int teamId, bool isFavorite)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

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

    public async Task<IActionResult> GetFavoriteTeams()
    {
        var ret = new List<TeamTableViewModel>();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var allSeasons = await _seasonRepository.GetAllAsync();
        var allTeams = await _teamRepository.GetAllAsync();
        var allTeamsSeasonStats = await _teamSeasonStatsRepository.GetAllAsync();
        var allMatches = await _matchRepository.GetAllAsync();
        var favoriteTeamsRelations = await _favoriteTeamRepository.GetWhereAsync(item => item.UserId == userId);
        var favoriteTeams = allTeams.Where(item => favoriteTeamsRelations.Any(rel => rel.TeamId == item.Id));

        foreach (var team in favoriteTeams)
        {
            var matches = new List<MatchViewModel>();

            foreach (var match in allMatches.Where(item => item.HomeTeamId == team.Id || item.AwayTeamId == team.Id))
            {
                var season = allSeasons.Single(item => item.Id == match.SeasonId);
                matches.Add(new MatchViewModel
                {
                    HomeTeamName = allTeams.Single(item => item.Id == match.HomeTeamId).Name,
                    AwayTeamName = allTeams.Single(item => item.Id == match.AwayTeamId).Name,
                    HomeTeamGoals = match.HomeTeamGoals,
                    AwayTeamGoals = match.AwayTeamGoals,
                    Date = match.Date,
                    Queue = match.Queue,
                    SeasonName = season.Name
                });
            }

            ret.Add(new TeamTableViewModel
            {
                Team = team,
                Favorite = favoriteTeamsRelations.FirstOrDefault(item => item.TeamId == team.Id) != null,
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