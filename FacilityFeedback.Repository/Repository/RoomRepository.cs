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
    public class RoomRepository : IRoomRepository
    {
        private readonly FacilityFeedbackContext _context;

        public RoomRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public Room Create(Room entity)
        {
            var result = _context.Room.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Room> CreateAsync(Room entity)
        {
            var result = await _context.Room.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Room entity)
        {
            var result = _context.Room.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Room entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Room> Get()
        {
            return _context.Room;
        }

        public IQueryable<Room> Get(Expression<Func<Room, bool>> predicate)
        {
            return _context.Room.Where(predicate);
        }

        public Room Get<TKey>(TKey id)
        {
            var result = _context.Room.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Room> GetAsync<TKey>(TKey id)
        {
            var result = await _context.Room.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public Room Update(Room entity)
        {
            var result = _context.Room.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Room> UpdateAsync(Room entity)
        {
            var result = _context.Room.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<Room>.Delete(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
