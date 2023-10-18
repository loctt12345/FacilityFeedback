using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface IRoomService
    {
        public Task<List<Room>?> GetAll(PagingModel pagingModel);
        public Task<Room?> GetById(int id);
        public Task<Room?> Create(Room request);
        public Task<Room?> Update(Room request);
        public Task<bool> Delete(int id);
        public Task<List<Room>> GetAllNoPaging();
    }
}
