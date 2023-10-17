using FacilityFeedback.Data.Models;
using FacilityFeedback.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
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
        private readonly FacilityFeedbackContext _context;
        public TaskProcessRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public TaskProcess Create(TaskProcess entity)
        {
            var result = _context.TaskProcess.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<TaskProcess> CreateAsync(TaskProcess entity)
        {
            var result = await _context.TaskProcess.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(TaskProcess entity)
        {
            var result = _context.TaskProcess.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(TaskProcess entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<TaskProcess> Get()
        {
            return _context.TaskProcess;
        }

        public IQueryable<TaskProcess> Get(Expression<Func<TaskProcess, bool>> predicate)
        {
            return _context.TaskProcess.Where(predicate);
        }

        public TaskProcess Get<TKey>(TKey id)
        {
            var result = _context.TaskProcess.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<TaskProcess> GetAsync<TKey>(TKey id)
        {
            var result = await _context.TaskProcess.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public TaskProcess Update(TaskProcess entity)
        {
            var result = _context.TaskProcess.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<TaskProcess> UpdateAsync(TaskProcess entity)
        {
            var result = _context.TaskProcess.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<TaskProcess>.Delete(TaskProcess entity)
        {
            throw new NotImplementedException();
        }
    }
}
