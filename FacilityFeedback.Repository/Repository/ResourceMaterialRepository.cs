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
    public class ResourceMaterialRepository : IResourceMaterialRepository
    {
        public ResourceMaterial Create(ResourceMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceMaterial> CreateAsync(ResourceMaterial entity)
        {
            throw new NotImplementedException();
        }

        public ResourceMaterial Delete(ResourceMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(ResourceMaterial entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ResourceMaterial> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ResourceMaterial> Get(Expression<Func<ResourceMaterial, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ResourceMaterial Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceMaterial> GetAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public ResourceMaterial Update(ResourceMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceMaterial> UpdateAsync(ResourceMaterial entity)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryBase<ResourceMaterial>.Delete(ResourceMaterial entity)
        {
            throw new NotImplementedException();
        }
    }
}
