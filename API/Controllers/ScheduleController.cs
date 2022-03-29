using API.DTOs;
using AutoMapper;
using Domain;
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
		[HttpPost]
		public async Task<IActionResult> TrainerAddSchedule(ScheduleSessionDTO session)
        {
			_context.TrainerAvailableSessions.Add(_mapper.Map<TrainerAvailableSessions> (session));
            if (await _context.SaveChangesAsync() > 0)
            {
				return Ok();
            }
			return NotFound();
        }
		[HttpPost("add")]
		public async Task<IActionResult> ClientCreateSession(ScheduleSessionDTO sessionsDTO)
        {
			if (_context.TrainerAvailableSessions.Contains(_mapper.Map<TrainerAvailableSessions>(sessionsDTO)))
            {
				_context.Schedules.Add(_mapper.Map<Schedule>(sessionsDTO));
                if (await _context.SaveChangesAsync() > 0)
                {
					return Ok();
                }
            }
			return NotFound();
        }
	}
}
