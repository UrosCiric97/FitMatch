using AutoMapper;
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
	public class Edit
	{
		public class Command : IRequest
		{
			public User User { get; set; }
		}

		public class Handler : IRequestHandler<Command>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;
			public Handler(DataContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}
			public async Task Handle(Command request, CancellationToken cancellationToken)
			{
				var user = await _context.Users.FindAsync(request.User.Id);

				_mapper.Map(request.User, user);

				await _context.SaveChangesAsync();
			}
		}
	}
}
