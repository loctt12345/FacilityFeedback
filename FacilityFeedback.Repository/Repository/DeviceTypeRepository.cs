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
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly FacilityFeedbackContext _context;

        public DeviceTypeRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public DeviceType Create(DeviceType entity)
        {
            var result = _context.DeviceType.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<DeviceType> CreateAsync(DeviceType entity)
        {
            var result = await _context.DeviceType.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(DeviceType entity)
        {
            var result = _context.DeviceType.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(DeviceType entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<DeviceType> Get()
        {
            return _context.DeviceType;
        }

        public IQueryable<DeviceType> Get(Expression<Func<DeviceType, bool>> predicate)
        {
            return _context.DeviceType.Where(predicate);
        }

        public DeviceType Get<TKey>(TKey id)
        {
            var result = _context.DeviceType.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<DeviceType> GetAsync<TKey>(TKey id)
        {
            var result = await _context.DeviceType.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public DeviceType Update(DeviceType entity)
        {
            var result = _context.DeviceType.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<DeviceType> UpdateAsync(DeviceType entity)
        {
            var result = _context.DeviceType.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<DeviceType>.Delete(DeviceType entity)
        {
            throw new NotImplementedException();
        }
    }
}
