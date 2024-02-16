﻿using FootballLeagueManager.Models.Entities;

namespace FootballLeagueManager.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey>
      where TEntity : class, IEntity<TPrimaryKey>, new()
      where TPrimaryKey : struct
    {
        public TEntity GetById(TPrimaryKey id);

        public Task<TEntity> GetByIdAsync(TPrimaryKey id);

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
}
