using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
	public class PostRepository : Repository<Post>, IPostRepository
	{
		private readonly DataContext _context;
        public PostRepository(DataContext context) : base(context) 
        {
            _context = context;
        }
    }
}
