using API.DTOs;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repositories;
using Persistence.RepositoryImplementations;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UsersController(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var result = await _userRepository.GetAllAsync();
			if (result.Any())
			{
				return Ok(result);
			}
			return NotFound("No users found");
		}
		[HttpGet("filtered")]
		public async Task<ActionResult> GetById(int userId)
		{
			var users = await _userRepository.GetFilteredAsync(x => x.Id == userId);
			var user = users.FirstOrDefault();
			if (user != null)
			{
				return Ok(user);
			}
			return BadRequest("No user with this id");
		}
		[HttpPost]
		public async Task<ActionResult> AddUser(UserDTO user)
		{
			var result = await _userRepository.AddAsync(_mapper.Map<User>(user));
			if (result == true)
			{
				return Ok("User succesfully added");
			}
			return BadRequest("User is not added succesfully");
		}
		[HttpPost("addRange")]
		public async Task<ActionResult> AddRange(IEnumerable<UserDTO> users)
		{
			foreach (var user in users)
			{
				var mappedUser = _mapper.Map<User>(user);
				await _userRepository.AddAsync(mappedUser);
			}
			if (users.Any())
			{
				return Ok("Users added succesfully");
			}
			return BadRequest("Users not added, wrong input");
		}
		[HttpDelete]
		public async Task<ActionResult> RemoveUser(UserIdDTO user)
		{
			var result = await _userRepository.RemoveAsync(_mapper.Map<User>(user));
			if (result == true)
			{
				return Ok("User removed");
			}
			return BadRequest("User not removed");
		}
		[HttpDelete("removeRange")]
		public async Task<ActionResult> RemoveRange(IEnumerable<UserIdDTO> users)
		{
			foreach (var user in users)
			{
				var mappedUser = _mapper.Map<User>(user);
				await _userRepository.RemoveAsync(mappedUser);
			}
			if (users.Any())
			{
				return Ok("Users succesfully deleted");
			}
			return BadRequest("Users are not deleted, wrong input");
		}
	}
}
