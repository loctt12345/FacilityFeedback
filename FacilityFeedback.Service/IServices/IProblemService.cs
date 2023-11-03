using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface IProblemService
    {
        public Task<List<Problem>?> GetAll(PagingModel pagingModel);
        public Task<Problem?> GetById(int id);
        public Task<Problem?> Create(Problem request);
        public Task<Problem?> Update(Problem request);
        public Task<bool> Delete(int id);
        public Task<List<Problem>> GetAllNoPaging();
    }
}
