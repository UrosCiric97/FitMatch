using Domain;
using Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserWithPostsAsync(Expression<Func<User, bool>> expression);
        Task<IEnumerable<User>> GetUsersPaginatedAsync(Expression<Func<User, bool>> expression);
    }
}
