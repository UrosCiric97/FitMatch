using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
	public class UserRepository : Repository<User> , IUserRepository
	{
        protected readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
