using AutoMapper;
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
    public class FollowRepository : Repository<UserFollowing>, IFollowRepository
    {
        private DbContext _context;
        private IMapper _mapper;
        private FollowRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
