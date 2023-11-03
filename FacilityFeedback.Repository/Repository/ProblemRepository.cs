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
        private readonly FacilityFeedbackContext _context;

        public ProblemRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public Problem Create(Problem entity)
        {
            var result = _context.Problem.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Problem> CreateAsync(Problem entity)
        {
            var result = await _context.Problem.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Problem entity)
        {
            var result = _context.Problem.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Problem entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Problem> Get()
        {
            return _context.Problem;
        }

        public IQueryable<Problem> Get(Expression<Func<Problem, bool>> predicate)
        {
            return _context.Problem.Where(predicate);
        }

        public Problem Get<TKey>(TKey id)
        {
            var result = _context.Problem.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Problem> GetAsync<TKey>(TKey id)
        {
            var result = await _context.Problem.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public Problem Update(Problem entity)
        {
            var result = _context.Problem.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Problem> UpdateAsync(Problem entity)
        {
            var result = _context.Problem.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<Problem>.Delete(Problem entity)
        {
            throw new NotImplementedException();
        }
    }
}
