using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
	public class SkillRepository : Repository<Skill>, ISkillRepository
	{
		private readonly DataContext _context;
		public SkillRepository(DataContext context) : base(context)
		{
			_context = context;
		}
	}
}
