using FootballLeagueManager.Attributes;
using FootballLeagueManager.Configuration.Dependencies.DependencyLifecycleInterfaces;
using FootballLeagueManager.Models.Entities;
using System.Linq.Expressions;

namespace FootballLeagueManager.Repositories;

[RegisterOpenGenericInterfaceInDi(typeof(IRepository<,>))]
public interface IRepository<TEntity, TPrimaryKey> : IPerWebRequestDependency
    where TEntity : class, IEntity<TPrimaryKey>, new()
    where TPrimaryKey : struct
{
    public TEntity GetById(TPrimaryKey id);

    public Task<TEntity> GetByIdAsync(TPrimaryKey id);

    public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);

    public Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);

    public IEnumerable<TEntity> GetAll();

    public Task<IEnumerable<TEntity>> GetAllAsync();

    public TEntity Create(TEntity entity);

    public Task<TEntity> CreateAsync(TEntity entity);

    public TEntity Update(TEntity entity);

    public Task<TEntity> UpdateAsync(TEntity entity);

    public void Delete(TPrimaryKey id);

    public Task DeleteAsync(TPrimaryKey id);

    public void Delete(TEntity entity);

    public Task DeleteAsync(TEntity entity);
}