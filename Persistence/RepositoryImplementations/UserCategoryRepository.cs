using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
	public class UserCategoryRepository : Repository<UserCategory>, IUserCategoryRepository
	{
		private readonly DataContext _context;
		public UserCategoryRepository(DataContext context) : base(context)
		{
			_context = context;
		}
	}
}
