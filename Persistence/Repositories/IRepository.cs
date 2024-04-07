using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task <List<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> expression);
		Task<List<TEntity>> GetAllAsync();
		Task<bool> AddAsync(TEntity entity);
		Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);
		Task<bool> RemoveAsync(TEntity entity);
		Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
	}
}
