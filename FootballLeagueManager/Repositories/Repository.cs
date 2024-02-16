using FootballLeagueManager.Data;
using FootballLeagueManager.Exceptions;
using FootballLeagueManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManager.Repositories
{
    public class Repository<TEntity, TPrimaryKey> :
        IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
        private readonly ApplicationDbContext _ctx;

        public Repository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public TEntity GetById(TPrimaryKey id)
        {
            var entity = _ctx.Set<TEntity>().Find(id);
            if (entity == null)
                throw new EntityNotFoundException($"Entity of type {typeof(TEntity).FullName} with ID {id} was not found.");

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            var entity = await _ctx.Set<TEntity>().FindAsync(id);
            if (entity == null)
                throw new EntityNotFoundException($"Entity of type {typeof(TEntity).FullName} with ID {id} was not found.");

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public TEntity Create(TEntity entity)
        {
            var entityEntry = _ctx.Set<TEntity>().Add(entity);
            _ctx.SaveChanges();

            return entityEntry.Entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entityEntry = await _ctx.Set<TEntity>().AddAsync(entity);
            await _ctx.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var entityEntry = _ctx.Set<TEntity>().Update(entity);
            _ctx.SaveChanges();

            return entityEntry.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityEntry = _ctx.Set<TEntity>().Update(entity);
            await _ctx.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = _ctx.Set<TEntity>().Find(id);
            if (entity == null)
                throw new EntityNotFoundException($"Entity of type {typeof(TEntity).FullName} with ID {id} was not found.");

            _ctx.Set<TEntity>().Remove(entity);
            _ctx.SaveChanges();
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            var entity = await _ctx.Set<TEntity>().FindAsync(id);
            if (entity == null)
                throw new EntityNotFoundException($"Entity of type {typeof(TEntity).FullName} with ID {id} was not found.");

            _ctx.Set<TEntity>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _ctx.Set<TEntity>().Remove(entity);
            _ctx.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _ctx.Set<TEntity>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}
