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
        public DeviceType Create(DeviceType entity)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceType> CreateAsync(DeviceType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(DeviceType entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(DeviceType entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DeviceType> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<DeviceType> Get(Expression<Func<DeviceType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DeviceType Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceType> GetAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public DeviceType Update(DeviceType entity)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceType> UpdateAsync(DeviceType entity)
        {
            throw new NotImplementedException();
        }
    }
}
