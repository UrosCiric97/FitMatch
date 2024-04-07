using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly DataContext _context;
		public Repository(DataContext context) 
		{
			_context = context;
		}
		public async Task<List<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _context.Set<TEntity>().Where(expression).ToListAsync();
		}
		public async Task<List<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}
		public async Task<bool> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			return await _context.SaveChangesAsync() > 0;
		}
		public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().AddRange(entities);
			return await _context.SaveChangesAsync() > 0;
		}
		public async Task<bool> RemoveAsync(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
			return await _context.SaveChangesAsync() > 0;
		}
		public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().RemoveRange(entities);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
