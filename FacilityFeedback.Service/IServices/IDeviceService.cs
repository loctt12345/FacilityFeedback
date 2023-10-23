using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface IDeviceService
    {
        public Task<List<Device>?> GetAll(PagingModel pagingModel);
        public Task<Device?> GetById(int id);
        public Task<Device?> Create(Device request);
        public Task<Device?> Update(Device request);
        public Task<bool> Delete(int id);
        public Task<List<Device>> GetAllNoPaging();
    }
}
