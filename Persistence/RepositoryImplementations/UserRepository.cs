using Microsoft.EntityFrameworkCore;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Repositories;
using AutoMapper;
using Persistence.DTOs;
using System.Linq.Expressions;

namespace Persistence.RepositoryImplementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private IMapper _mapper;
        protected readonly DataContext _context;
        public UserRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> GetUserWithPostsAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).Include(x=> x.Posts).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersPaginatedAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).ToListAsync();
        }
    }
}
