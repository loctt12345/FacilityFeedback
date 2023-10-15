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
        public Device Create(Device entity)
        {
            throw new NotImplementedException();
        }

        public Task<Device> CreateAsync(Device entity)
        {
            throw new NotImplementedException();
        }

        public Device Delete(Device entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Device> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Device> Get(Expression<Func<Device, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Device Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Device Update(Device entity)
        {
            throw new NotImplementedException();
        }
    }
}
