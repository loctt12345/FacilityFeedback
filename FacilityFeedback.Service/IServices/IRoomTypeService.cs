using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface IRoomTypeService
    {
        public Task<List<RoomType>?> GetAll(PagingModel pagingModel);
        public Task<RoomType?> GetById(int id);
        public Task<RoomType?> Create(RoomType request);
        public Task<RoomType?> Update(RoomType request);
        public Task<bool> Delete(int id);
        public Task<List<RoomType>> GetAllNoPaging();
    }
}
