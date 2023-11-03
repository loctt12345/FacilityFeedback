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
    public class ProblemService : IProblemService
    {
        private readonly IProblemRepository _ProblemRepository;
        public ProblemService(IProblemRepository ProblemRepository)
        {
            _ProblemRepository = ProblemRepository;
        }

        public Task<List<Problem>?> GetAll()
        {
            return (Task<List<Problem>?>)_ProblemRepository.Get();
        }
        public async Task<List<Problem>> GetAllNoPaging()
        {
            return await _ProblemRepository.Get()
                .Include(tp => tp.Tasks)
                .Include(d => d.Device).ThenInclude(r => r.Room)
                .ToListAsync();
        }

        public async Task<Problem?> Create(Problem request)
        {
            var ProblemCreate = await _ProblemRepository.CreateAsync(request);
            return ProblemCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _ProblemRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Not found");
            await _ProblemRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<Problem?> GetById(int id)
        {
            var result = await _ProblemRepository.GetAsync(id);
            
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Problem?> Update(Problem request)
        {
            return await _ProblemRepository.UpdateAsync(request);

        }

        public Task<List<Problem>?> GetAll(PagingModel pagingModel)
        {
            throw new NotImplementedException();
        }
    }
}
