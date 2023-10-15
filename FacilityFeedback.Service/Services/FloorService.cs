using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacilityFeedback.Repository.IRepository;
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
        public List<Floor> GetAll1()
        {
            return _floorRepository.Get().ToList();
        }

        public Task<Floor?> Create(Floor request)
        {
            throw new NotImplementedException();
        }

        public Task<Floor?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Floor?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Floor?> Update(Floor request)
        {
            throw new NotImplementedException();
        }
    }
}
