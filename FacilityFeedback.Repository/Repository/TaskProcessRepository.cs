using FacilityFeedback.Data.Models;
using FacilityFeedback.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Repository.Repository
{
    public class TaskProcessRepository : ITaskProcessRepository
    {
        public TaskProcess Create(TaskProcess entity)
        {
            throw new NotImplementedException();
        }

        public Task<TaskProcess> CreateAsync(TaskProcess entity)
        {
            throw new NotImplementedException();
        }

        public TaskProcess Delete(TaskProcess entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TaskProcess entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaskProcess> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaskProcess> Get(Expression<Func<TaskProcess, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TaskProcess Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskProcess> GetAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public TaskProcess Update(TaskProcess entity)
        {
            throw new NotImplementedException();
        }

        public Task<TaskProcess> UpdateAsync(TaskProcess entity)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryBase<TaskProcess>.Delete(TaskProcess entity)
        {
            throw new NotImplementedException();
        }
    }
}
