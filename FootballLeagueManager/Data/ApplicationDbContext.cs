using FootballLeagueManager.Data.SeedData;
using FootballLeagueManager.Models.Entities.Main;
using FootballLeagueManager.Models.Entities.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly IEnumerable<ISeeder>? _seeders;



    public DbSet<League> Leagues { get; set; }

    public DbSet<Match> Matches { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<FavoriteTeam> FavoriteTeams { get; set; }
    


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IEnumerable<ISeeder>? seeders = null)
        : base(options)
    {
        _seeders = seeders?.OrderBy(seeder => seeder.Order);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!base.Database.GetAppliedMigrations().Any() && _seeders != null)
            foreach (var seeder in _seeders)
                seeder.Seed(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
}
