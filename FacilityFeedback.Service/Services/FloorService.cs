using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacilityFeedback.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FacilityFeedback.Service.Services
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _floorRepository;
        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public Task<List<Floor>?> GetAll()
        {
            return (Task<List<Floor>?>)_floorRepository.Get();
        }
        public async Task<List<Floor>> GetAllNoPaging()
        {
            return await _floorRepository.Get().ToListAsync();
        }

        public async Task<Floor?> Create(Floor request)
        {
            var FloorCreate = await _floorRepository.CreateAsync(request);
            return FloorCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _floorRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Not found");
            await _floorRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<Floor?> GetById(int id)
        {
            var result = await _floorRepository.GetAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Floor?> Update(Floor request)
        {
            return await _floorRepository.UpdateAsync(request);

        }
    }
}
