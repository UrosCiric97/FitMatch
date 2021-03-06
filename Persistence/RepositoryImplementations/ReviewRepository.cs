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
    public class ReviewRepository : Repository<Review> , IReviewRepository
    {
        private DbContext _context;
        private IMapper _mapper;
        public ReviewRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
