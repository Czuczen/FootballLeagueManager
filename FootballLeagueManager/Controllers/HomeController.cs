using FootballLeagueManager.Models.Entities.Main;
using FootballLeagueManager.Models.ViewModels;
using FootballLeagueManager.Models.ViewModels.Home;
using FootballLeagueManager.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FootballLeagueManager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository<League, int> _leagueRepository;
    private readonly IRepository<Team, int> _teamRepository;
    private readonly IRepository<Match, int> _matchRepository;
    private readonly IRepository<TeamSeason, int> _teamSeasonRepository;
    private readonly IRepository<Season, int> _seasonRepository;

    public HomeController(
        ILogger<HomeController> logger,
        IRepository<League, int> leagueRepository,
        IRepository<Team, int> teamRepository,
        IRepository<Match, int> matchRepository,
        IRepository<TeamSeason, int> teamSeasonRepository,
        IRepository<Season, int> seasonRepository
        )
    {
        _logger = logger;
        _leagueRepository = leagueRepository;
        _teamRepository = teamRepository;
        _matchRepository = matchRepository;
        _teamSeasonRepository = teamSeasonRepository;
        _seasonRepository = seasonRepository;
    }

    public async Task<IActionResult> Index(int? seasonId = null, int? leagueId = null, int? queue = null)
    {
        seasonId = seasonId ?? 1;
        leagueId = leagueId ?? 1;
        queue = queue ?? 1;

        var allSeasons = await _seasonRepository.GetAllAsync();
        var allTeams = await _teamRepository.GetAllAsync();

        var teamsSeasonStats = await _teamSeasonRepository.GetWhereAsync(item => item.SeasonId == seasonId);
        var availableSeasons = allSeasons.Where(item => item.LeagueId == leagueId);
        var availableTeams = allTeams.Where(item => teamsSeasonStats.Any(stats => stats.TeamId == item.Id));

        var availableMatches = await _matchRepository.GetWhereAsync(item => item.SeasonId == seasonId);

        return View(new TeamsTableViewModel
        {
            SeasonId = (int) seasonId,
            LeagueId = (int) leagueId,
            Queue = (int) queue,
            Seasons = availableSeasons,
            Leagues = await _leagueRepository.GetAllAsync(),
            Teams = availableTeams,
            Matches = availableMatches
        });
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