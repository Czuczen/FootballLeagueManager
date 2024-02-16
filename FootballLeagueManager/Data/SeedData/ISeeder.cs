using FootballLeagueManager.Configuration.Dependencies.DependencyLifecycleInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Data.SeedData;

public interface ISeeder : ITransientDependency
{
    int Order { get; }

    void Seed(ModelBuilder modelBuilder);
}
