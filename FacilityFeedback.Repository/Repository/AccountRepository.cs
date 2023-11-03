using FacilityFeedback.Data.Models;
using FacilityFeedback.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Repository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FacilityFeedbackContext _context;

        public AccountRepository(FacilityFeedbackContext context)
        {
            _context = context;
        }
        public Account Create(Account entity)
        {
            var result = _context.Account.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Account> CreateAsync(Account entity)
        {
            var result = await _context.Account.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Account entity)
        {
            var result = _context.Account.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Account entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Account> Get()
        {
            return _context.Account;
        }

        public IQueryable<Account> Get(Expression<Func<Account, bool>> predicate)
        {
            return _context.Account.Where(predicate);
        }

        public Account Get<TKey>(TKey id)
        {
            var result = _context.Account.Find(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public async Task<Account> GetAsync<TKey>(TKey id)
        {
            var result = await _context.Account.FindAsync(id);
            if (result == null)
                throw new Exception("Not found");
            return result;
        }

        public Account Update(Account entity)
        {
            var result = _context.Account.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Account> UpdateAsync(Account entity)
        {
            var result = _context.Account.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        bool IRepositoryBase<Account>.Delete(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
