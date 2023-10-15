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
    public class RoomRepository : IRoomRepository
    {
        public Room Create(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<Room> CreateAsync(Room entity)
        {
            throw new NotImplementedException();
        }

        public Room Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Room> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Room> Get(Expression<Func<Room, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Room Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Room Update(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
