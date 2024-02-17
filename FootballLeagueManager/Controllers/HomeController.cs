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

    public HomeController(
        ILogger<HomeController> logger,
        IRepository<League, int> leagueRepository,
        IRepository<Team, int> teamRepository,
        IRepository<Match, int> matchRepository
        )
    {
        _logger = logger;
        _leagueRepository = leagueRepository;
        _teamRepository = teamRepository;
        _matchRepository = matchRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(new LeagueTablesViewModel
        {
            Leagues = await _leagueRepository.GetAllAsync(),
            Teams = await _teamRepository.GetAllAsync(),
            Matches = await _matchRepository.GetAllAsync()
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