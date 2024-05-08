using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
	public class Create
	{
		public class Command : IRequest
		{
            public User User { get; set; }
        }

		public class Handler : IRequestHandler<Command>
		{
			private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
			{
				_context.Users.Add(request.User);

				await _context.SaveChangesAsync();	
			}
		}
	}
}
