using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface IDeviceTypeService
    {
        public Task<List<DeviceType>?> GetAll(PagingModel pagingModel);
        public Task<DeviceType?> GetById(int id);
        public Task<DeviceType?> Create(DeviceType request);
        public Task<DeviceType?> Update(DeviceType request);
        public Task<bool> Delete(int id);
        public Task<List<DeviceType>> GetAllNoPaging();
    }
}
