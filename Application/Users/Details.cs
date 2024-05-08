using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
	public class Details
	{
		public class Query : IRequest<User>
		{
            public int Id { get; set; }
        }

		public class Handler : IRequestHandler<Query, User>
		{
			private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _context.Users.FindAsync(request.Id);
			}
		}
	}
}
