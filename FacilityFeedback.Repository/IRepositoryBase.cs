using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        public IQueryable<TEntity> Get();
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        public TEntity Get<TKey>(TKey id);
        public Task<TEntity> GetAsync<TKey>(TKey id);
        public TEntity Create(TEntity entity);
        public Task<TEntity> CreateAsync(TEntity entity);
        public TEntity Update(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public bool Delete(TEntity entity);
        public Task<bool> DeleteAsync(TEntity entity);
    }
}
