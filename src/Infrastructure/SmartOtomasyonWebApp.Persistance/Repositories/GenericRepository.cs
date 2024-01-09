using Microsoft.EntityFrameworkCore;
using SmartOtomasyonWebApp.Application.Aspects;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Domain.Common;
using SmartOtomasyonWebApp.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace SmartOtomasyonWebApp.Persistance.Repositories
{
    public class GenericRepository<T,TContext> : IGenericRepositoryAsync<T> where T : BaseEntity where TContext : Microsoft.EntityFrameworkCore.DbContext, new()
    {
        

        [SecuredOperation("Admin")]
        public async Task<T> AddAsync(T entity)
        {
            using (TContext context = new TContext())
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return  entity;

            }
            
        }

        [SecuredOperation("Admin")]
        public async Task DeleteAsync(T entity)
        {
            using (TContext context = new())
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

            }
           
        }

        [SecuredOperation("Admin")]
        public async Task<List<T>> GetAllAsync()
        {
            using (TContext context = new())
            {
                return context.Set<T>().ToList();
            }
           
        }

        [SecuredOperation("Admin")]
        public async Task<T> GetByIdAsync(Guid id)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
           

        }

        [SecuredOperation("Admin")]
        public async Task UpdateAsync(T entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            
            
        }
    }
}
