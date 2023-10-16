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
    public class FloorRepository : IFloorRepository
    {
        private readonly FacilityFeedbackContext _context;

        public FloorRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public Floor Create(Floor entity)
        {
            var result = _context.Floor.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Floor> CreateAsync(Floor entity)
        {
            var result = await _context.Floor.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Floor entity)
        {
            var result = _context.Floor.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Floor entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Floor> Get()
        {
            return _context.Floor;
        }

        public IQueryable<Floor> Get(Expression<Func<Floor, bool>> predicate)
        {
            return _context.Floor.Where(predicate);
        }

        public Floor Get<TKey>(TKey id)
        {
            var result = _context.Floor.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Floor> GetAsync<TKey>(TKey id)
        {
            var result = await _context.Floor.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public Floor Update(Floor entity)
        {
            var result = _context.Floor.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Floor> UpdateAsync(Floor entity)
        {
            var result = _context.Floor.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<Floor>.Delete(Floor entity)
        {
            throw new NotImplementedException();
        }
    }
}
