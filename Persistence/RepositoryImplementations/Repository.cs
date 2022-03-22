using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _context;
        private IMapper _mapper;
        public Repository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
