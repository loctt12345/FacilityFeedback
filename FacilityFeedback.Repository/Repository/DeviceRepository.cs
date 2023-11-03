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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly FacilityFeedbackContext _context;

        public DeviceRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public Device Create(Device entity)
        {
            var result = _context.Device.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Device> CreateAsync(Device entity)
        {
            var result = await _context.Device.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Device entity)
        {
            var result = _context.Device.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Device entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Device> Get()
        {
            return _context.Device;
        }

        public IQueryable<Device> Get(Expression<Func<Device, bool>> predicate)
        {
            return _context.Device.Where(predicate);
        }

        public Device Get<TKey>(TKey id)
        {
            var result = _context.Device.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Device> GetAsync<TKey>(TKey id)
        {
            var result = await _context.Device.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public Device Update(Device entity)
        {
            var result = _context.Device.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Device> UpdateAsync(Device entity)
        {
            var result = _context.Device.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<Device>.Delete(Device entity)
        {
            throw new NotImplementedException();
        }
    }
}
