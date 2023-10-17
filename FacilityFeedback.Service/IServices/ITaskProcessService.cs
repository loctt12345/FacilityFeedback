using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface ITaskProcessService
    {
        public Task<List<TaskProcess>?> GetAll(PagingModel pagingModel);
        public Task<TaskProcess?> GetById(int id);
        public Task<TaskProcess?> Create(TaskProcess request);
        public Task<TaskProcess?> Update(TaskProcess request);
        public Task<bool> Delete(int id);
        public Task<List<TaskProcess>> GetAllNoPaging();
    }
}
