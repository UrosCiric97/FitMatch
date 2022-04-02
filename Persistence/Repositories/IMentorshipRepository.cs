using Domain;
using Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IMentorshipRepository : IRepository<Mentorship>
    {
        Task<bool> IncrementFinishedSessions(MentorshipDTO mentorship);
    }
}
