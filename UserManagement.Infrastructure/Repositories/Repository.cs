using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Core;
using UserManagement.Infrastructure.DbConnection;

namespace UserManagement.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbConnect _db;
        public Repository(DbConnect db) 
        {
            _db = db;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == default)
            {
                throw new Exception("Object Not Found!");
            }
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }
    }
}
