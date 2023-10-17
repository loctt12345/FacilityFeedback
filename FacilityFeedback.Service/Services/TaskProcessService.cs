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
    public class TaskProcessService : ITaskProcessService
    {
        private readonly ITaskProcessRepository _taskProcessRepository;
        public TaskProcessService(ITaskProcessRepository TaskProcessRepository)
        {
            _taskProcessRepository = TaskProcessRepository;
        }

        public Task<List<TaskProcess>?> GetAll()
        {
            return (Task<List<TaskProcess>?>)_taskProcessRepository.Get();
        }
        public async Task<List<TaskProcess>> GetAllNoPaging()
        {
            return await _taskProcessRepository.Get().ToListAsync();
        }

        public async Task<TaskProcess?> Create(TaskProcess request)
        {
            var TaskProcessCreate = await _taskProcessRepository.CreateAsync(request);
            return TaskProcessCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _taskProcessRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Not found");
            await _taskProcessRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<TaskProcess?> GetById(int id)
        {
            var result = await _taskProcessRepository.GetAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<TaskProcess?> Update(TaskProcess request)
        {
            return await _taskProcessRepository.UpdateAsync(request);

        }
        
        public Task<List<TaskProcess>?> GetAll(PagingModel pagingModel)
        {
            throw new NotImplementedException();
        }
    }
}
