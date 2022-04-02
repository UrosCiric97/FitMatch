using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DTOs;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
    public class MentorshipRepository : Repository<Mentorship>, IMentorshipRepository
    {
        private DataContext _context;
        private IMapper _mapper;

        public MentorshipRepository(DataContext context, IMapper mapper) : base (context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> IncrementFinishedSessions(MentorshipDTO mentorshipDTO)
        {
			var mentorship = await _context.Mentorships
				.FirstOrDefaultAsync(x => x.ClientId == mentorshipDTO.ClientId && x.TrainerId == mentorshipDTO.TrainerId);
			mentorship.NumberOfFinishedSessions++;
            return await _context.SaveChangesAsync() > 0;
		}
	}
}
