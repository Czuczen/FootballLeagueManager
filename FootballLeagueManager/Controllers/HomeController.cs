using FootballLeagueManager.Models.Entities.Main;
using FootballLeagueManager.Models.ViewModels;
using FootballLeagueManager.Models.ViewModels.Home;
using FootballLeagueManager.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

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
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/leagues"),
            Headers =
            {
                { "X-RapidAPI-Key", "1ab69a4398msh52d9d4f8deb99bep1d50cdjsn127048b73f66" },
                { "X-RapidAPI-Host", "api-football-v1.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            //response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }

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