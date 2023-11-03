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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _AccountRepository;
        public AccountService(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }

        public Task<List<Account>?> GetAll()
        {
            return (Task<List<Account>?>)_AccountRepository.Get();
        }
        public async Task<List<Account>> GetAllNoPaging()
        {
            return await _AccountRepository.Get()
                .ToListAsync();
        }

        public async Task<Account?> Create(Account request)
        {
            var AccountCreate = await _AccountRepository.CreateAsync(request);
            return AccountCreate;
        }

        public async Task<bool> Delete(string email)
        {
            var entity = await _AccountRepository.GetAsync(email);
            if (entity == null)
                throw new Exception("Not found");
            await _AccountRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<Account?> GetByEmail(string email)
        {
            var result = await _AccountRepository.GetAsync(email);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Account?> Update(Account request)
        {
            return await _AccountRepository.UpdateAsync(request);

        }

        public Task<List<Account>?> GetAll(PagingModel pagingModel)
        {
            throw new NotImplementedException();
        }
    }
}
