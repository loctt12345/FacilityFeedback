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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly FacilityFeedbackContext _context;

        public RoomTypeRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public RoomType Create(RoomType entity)
        {
            var result = _context.RoomType.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<RoomType> CreateAsync(RoomType entity)
        {
            var result = await _context.RoomType.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(RoomType entity)
        {
            var result = _context.RoomType.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(RoomType entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<RoomType> Get()
        {
            return _context.RoomType;
        }

        public IQueryable<RoomType> Get(Expression<Func<RoomType, bool>> predicate)
        {
            return _context.RoomType.Where(predicate);
        }

        public RoomType Get<TKey>(TKey id)
        {
            var result = _context.RoomType.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<RoomType> GetAsync<TKey>(TKey id)
        {
            var result = await _context.RoomType.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public RoomType Update(RoomType entity)
        {
            var result = _context.RoomType.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<RoomType> UpdateAsync(RoomType entity)
        {
            var result = _context.RoomType.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<RoomType>.Delete(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
