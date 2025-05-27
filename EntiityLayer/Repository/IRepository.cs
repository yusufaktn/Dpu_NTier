using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntiityLayer.Repository
{
    public  interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id ,CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity,CancellationToken cancellationToken=default);
        Task RemoveAsync(T entity ,CancellationToken cancellationToken= default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetWhere(Expression<Func<T, bool>> expression ,CancellationToken cancellationToken = default);
        Task <List<T>>GetWhereList(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    }
   
}
