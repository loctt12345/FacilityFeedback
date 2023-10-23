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
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository;
        public DeviceTypeService(IDeviceTypeRepository DeviceTypeRepository)
        {
            _deviceTypeRepository = DeviceTypeRepository;
        }

        public Task<List<DeviceType>?> GetAll()
        {
            return (Task<List<DeviceType>?>)_deviceTypeRepository.Get();
        }
        public async Task<List<DeviceType>> GetAllNoPaging()
        {
            return await _deviceTypeRepository.Get().ToListAsync();
        }

        public async Task<DeviceType?> Create(DeviceType request)
        {
            var DeviceTypeCreate = await _deviceTypeRepository.CreateAsync(request);
            return DeviceTypeCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _deviceTypeRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Not found");
            await _deviceTypeRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<DeviceType?> GetById(int id)
        {
            var result = await _deviceTypeRepository.GetAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<DeviceType?> Update(DeviceType request)
        {
            return await _deviceTypeRepository.UpdateAsync(request);

        }

        public Task<List<DeviceType>?> GetAll(PagingModel pagingModel)
        {
            throw new NotImplementedException();
        }
    }
}
