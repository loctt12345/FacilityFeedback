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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        public RoomTypeService(IRoomTypeRepository RoomTypeRepository)
        {
            _roomTypeRepository = RoomTypeRepository;
        }

        public Task<List<RoomType>?> GetAll()
        {
            return (Task<List<RoomType>?>)_roomTypeRepository.Get();
        }
        public async Task<List<RoomType>> GetAllNoPaging()
        {
            return await _roomTypeRepository.Get().ToListAsync();
        }

        public async Task<RoomType?> Create(RoomType request)
        {
            var RoomTypeCreate = await _roomTypeRepository.CreateAsync(request);
            return RoomTypeCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _roomTypeRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Not found");
            await _roomTypeRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<RoomType?> GetById(int id)
        {
            var result = await _roomTypeRepository.GetAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<RoomType?> Update(RoomType request)
        {
            return await _roomTypeRepository.UpdateAsync(request);

        }

        public Task<List<RoomType>?> GetAll(PagingModel pagingModel)
        {
            throw new NotImplementedException();
        }
    }
}
