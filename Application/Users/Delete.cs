using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
	public class Delete
	{
		public class Command : IRequest
		{
			public int Id { get; set; }
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
				var user = await _context.Users.FindAsync(request.Id);

				_context.Remove(user);

				await _context.SaveChangesAsync();
			}
		}
	}
}
