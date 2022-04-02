using API.DTOs;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SchedulesController : ControllerBase
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		private IScheduleRepository _scheduleRepository;

		public SchedulesController(DataContext context, IMapper mapper, IScheduleRepository scheduleRepository)
		{
			_context = context;
			_mapper = mapper;
			_scheduleRepository = scheduleRepository;
		}
		[HttpPost("addScheduleByTrainer")]
		public async Task<IActionResult> TrainerAddSchedule(ScheduleSessionDTO session)
        {
			_context.TrainerAvailableSessions.Add(_mapper.Map<TrainerAvailableSession> (session));
            if (await _context.SaveChangesAsync() > 0)
            {
				return Ok();
            }
			return NotFound();
        }
		[HttpPost("addScheduleByClient")]
		public async Task<IActionResult> ClientCreateSession(ScheduleSessionDTO sessionsDTO)
        {
			if (_context.TrainerAvailableSessions.Contains(_mapper.Map<TrainerAvailableSession>(sessionsDTO)))
            {
				_context.Schedules.Add(_mapper.Map<Schedule>(sessionsDTO));
                if (await _context.SaveChangesAsync() > 0)
                {
					return Ok();
                }
            }
			return NotFound();
        }
		[HttpGet("client/{id}")]
		public async Task<IActionResult> GetByClientId(int id)
        {
			var result = await _scheduleRepository.GetAsync(x => x.ClientId == id);
            if (result.Any())
            {
				return Ok(result);
            }
			return NotFound();
        }
		[HttpGet("trainer/{id}")]
		public async Task<IActionResult> GetByTrainerId(int id)
		{
			var result = await _scheduleRepository.GetAsync(x => x.TrainerId == id);
			if (result.Any())
			{
				return Ok(result);
			}
			return NotFound();
		}
		[HttpGet("getAll")]
		public async Task<IActionResult> GetAllSchedules()
        {
			var result = await _scheduleRepository.GetAllAsync();
            if (result.Any())
            {
				return Ok(result);
            }
			return NotFound();
        }
		[HttpPost("add")]
		public async Task<IActionResult> Add(Schedule schedule)
        {
			var result = await _scheduleRepository.AddAsync(schedule);
            if (result)
            {
				return Ok();
            }
			return NotFound();
        }
		[HttpPost("addRange")]
		public async Task<IActionResult> AddRange(IEnumerable<Schedule> schedules)
        {
			var result = await _scheduleRepository.AddRangeAsync(schedules);
            if (result)
            {
				return Ok();
            }
			return NotFound();
        }
		[HttpDelete("remove")]
		public async Task<IActionResult> Remove(Schedule schedule)
        {
			var result = await _scheduleRepository.RemoveAsync(schedule);
            if (result)
            {
				return Ok();
            }
			return NotFound();
        }
		[HttpDelete("removeRange")]
		public async Task<IActionResult> RemoveRange(IEnumerable<Schedule> schedules)
        {
			var result = await _scheduleRepository.RemoveRangeAsync(schedules);
            if (result)
            {
				return Ok();
            }
			return NotFound();
        }
	}
}
