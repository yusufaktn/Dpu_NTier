using DataAccessLayer.Context;
using EntiityLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal  class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
           await _context.Set<T>().AddAsync(entity ,cancellationToken);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return _context.Set<T>().AnyAsync(expression, cancellationToken);
        }

       

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
          return  await _context.Set<T>().ToListAsync(cancellationToken);
        }

        

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
          return  await _context.Set<T>().FindAsync(new object[] {id},cancellationToken ); 
        }

       

        public async Task<T> GetWhere(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<List<T>> GetWhereList(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
             _context.Set<T>().Remove(entity);  
            await Task.CompletedTask;
        }

        

        public  Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(entity);     
            return Task.CompletedTask;
        }
    }
}



