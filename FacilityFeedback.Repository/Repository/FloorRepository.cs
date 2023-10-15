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

        public Floor Delete(Floor entity)
        {
            var result = _context.Floor.Remove(entity);
            _context.SaveChanges();
            return result.Entity;
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
            return _context.Floor.Find(id);
        }

        public async Task<Floor> GetAsync<TKey>(TKey id)
        {
            return await _context.Floor.FindAsync(id);
        }

        public Floor Update(Floor entity)
        {
            var result = _context.Floor.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
