using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
	public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
	{
		private readonly DataContext _context;
        public UserRoleRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
