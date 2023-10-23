using FacilityFeedback.Data.Models;
using FacilityFeedback.Repository.IRepository;
using FacilityFeedback.Service.Configuration;
using FacilityFeedback.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _DeviceRepository;
        public DeviceService(IDeviceRepository DeviceRepository)
        {
            _DeviceRepository = DeviceRepository;
        }

        public Task<List<Device>?> GetAll()
        {
            return (Task<List<Device>?>)_DeviceRepository.Get();
        }
        public async Task<List<Device>> GetAllNoPaging()
        {
            return await _DeviceRepository.Get()
                .Include(r => r.Room)
                .Include(dt => dt.DeviceType)
                .ToListAsync();
        }

        public async Task<Device?> Create(Device request)
        {
            var DeviceCreate = await _DeviceRepository.CreateAsync(request);
            return DeviceCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _DeviceRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Not found");
            await _DeviceRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<Device?> GetById(int id)
        {
            var result = await _DeviceRepository.GetAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Device?> Update(Device request)
        {
            return await _DeviceRepository.UpdateAsync(request);

        }

        public Task<List<Device>?> GetAll(PagingModel pagingModel)
        {
            throw new NotImplementedException();
        }
    }
}
