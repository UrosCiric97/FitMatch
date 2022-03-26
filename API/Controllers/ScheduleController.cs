using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ScheduleController(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}
