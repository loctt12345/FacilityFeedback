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
    public class ProblemRepository : IProblemRepository
    {
        public Problem Create(Problem entity)
        {
            throw new NotImplementedException();
        }

        public Task<Problem> CreateAsync(Problem entity)
        {
            throw new NotImplementedException();
        }

        public Problem Delete(Problem entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Problem> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Problem> Get(Expression<Func<Problem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Problem Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Problem> GetAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Problem Update(Problem entity)
        {
            throw new NotImplementedException();
        }
    }
}
