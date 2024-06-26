﻿using AutoMapper;
using Domain;
using Domain.DTOs;
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
            public UserDTO User { get; set; }
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
				_context.Users.Add(_mapper.Map<User>(request.User));

				await _context.SaveChangesAsync();	
			}
		}
	}
}
