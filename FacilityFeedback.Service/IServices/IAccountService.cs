using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.IServices
{
    public interface IAccountService
    {
        public Task<List<Account>?> GetAll(PagingModel pagingModel);
        public Task<Account?> GetByEmail(string email);
        public Task<Account?> Create(Account request);
        public Task<Account?> Update(Account request);
        public Task<bool> Delete(int id);
        public Task<List<Account>> GetAllNoPaging();
    }
}
