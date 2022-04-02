using Persistence.DTOs;
using AutoMapper;
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
	public class MentorshipsController : ControllerBase
	{
		private IMapper _mapper;
		private IMentorshipRepository _mentorshipRepository;
		public MentorshipsController(IMapper mapper, IMentorshipRepository mentorshipRepository)
		{
			_mapper = mapper;
			_mentorshipRepository = mentorshipRepository;
		}
		[HttpPut]
		public async Task<IActionResult> Increment(MentorshipDTO mentorshipDTO)
		{
			var result = await _mentorshipRepository.IncrementFinishedSessions(mentorshipDTO);
			if (result)
			{
				return Ok();
			}
			return NotFound();
		}
	}
}
