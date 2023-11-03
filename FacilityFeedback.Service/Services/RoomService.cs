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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository RoomRepository)
        {
            _roomRepository = RoomRepository;
        }

        public Task<List<Room>?> GetAll()
        {
            return (Task<List<Room>?>)_roomRepository.Get();
        }
        public async Task<List<Room>> GetAllNoPaging()
        {
            return await _roomRepository.Get()
                .Include(f => f.Floor)
                .Include(rt => rt.RoomType)
                .ToListAsync();
        }

        public async Task<Room?> Create(Room request)
        {
            var RoomCreate = await _roomRepository.CreateAsync(request);
            return RoomCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _roomRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Not found");
            await _roomRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<Room?> GetById(int id)
        {
            var result = await _roomRepository.GetAsync(id);

            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Room?> Update(Room request)
        {
            return await _roomRepository.UpdateAsync(request);

        }

        public Task<List<Room>?> GetAll(PagingModel pagingModel)
        {
            throw new NotImplementedException();
        }
    }
}
