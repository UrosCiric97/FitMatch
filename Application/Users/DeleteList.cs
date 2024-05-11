using AutoMapper;
using Domain;
using Domain.DTOs;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
	public class DeleteList
	{
		public class Command : IRequest
		{
			public IEnumerable<UserIdDTO> Users { get; set; }
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
				foreach (var user in request.Users)
				{
					_context.Users.Remove(_mapper.Map<User>(user));
				}
				await _context.SaveChangesAsync();
			}
		}
	}
}
