using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface IFloorService
    {
        public Task<List<Floor>?> GetAll(PagingModel pagingModel);
        public Task<Floor?> GetById(int id);
        public Task<Floor?> Create(Floor request);
        public Task<Floor?> Update(Floor request);
        public Task<bool> Delete(int id);
        public Task<List<Floor>> GetAllNoPaging();
    }
}
