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
		private readonly ILogger<User> _logger;

		public UsersController(IUserRepository userRepository, IMapper mapper, ILogger<User> logger)
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_logger = logger;
		}
		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var result = await _userRepository.GetAllAsync();
				if (result.Any())
				{
					return Ok(result);
				}
			return NotFound("No users found");
			}
			catch (Exception ex)
			{
				var currentUser = HttpContext.User;
				var method = HttpContext.Request.Method;
				var message = ex.Message;
				_logger.LogError("The user {currentUser} triggered a {method} method and got the following exception message: {exception.Message}“", currentUser, method, message);
				return StatusCode(500, ex.Message);
			}
		}
		[HttpGet("filtered")]
		public async Task<ActionResult> GetById(int userId)
		{
			try
			{
				var users = await _userRepository.GetFilteredAsync(x => x.Id == userId);
				var user = users.FirstOrDefault();
				if (user != null)
				{
					return Ok(user);
				}
			}
			catch (Exception ex)
			{
				var currentUser = HttpContext.User;
				var method = HttpContext.Request.Method;
				var message = ex.Message;
				_logger.LogError("The user {currentUser} triggered a {method} method and got the following exception message: {exception.Message}“", currentUser, method, message);
				return StatusCode(500, ex.Message);
			}
			return BadRequest("No user with this id");
		}
		[HttpPost]
		public async Task<ActionResult> AddUser(UserDTO user)
		{
			try
			{
				var result = await _userRepository.AddAsync(_mapper.Map<User>(user));
				if (result == true)
				{
					return Ok("User succesfully added");
				}
			}
			catch (Exception ex)
			{
				var currentUser = HttpContext.User;
				var method = HttpContext.Request.Method;
				var message = ex.Message;
				_logger.LogError("The user {currentUser} triggered a {method} method and got the following exception message: {exception.Message}“", currentUser, method, message);
				return StatusCode(500, ex.Message);
			}
			return BadRequest("User is not added succesfully");
		}
		[HttpPost("range")]
		public async Task<ActionResult> AddRange(IEnumerable<UserDTO> users)
		{
			try
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
			}
			catch (Exception ex)
			{
				var currentUser = HttpContext.User;
				var method = HttpContext.Request.Method;
				var message = ex.Message;
				_logger.LogError("The user {currentUser} triggered a {method} method and got the following exception message: {exception.Message}“", currentUser, method, message);
				return StatusCode(500, ex.Message);
			}
			return BadRequest("Users not added, wrong input");
		}
		[HttpDelete]
		public async Task<ActionResult> RemoveUser(UserIdDTO user)
		{
			try
			{
				var result = await _userRepository.RemoveAsync(_mapper.Map<User>(user));
				if (result == true)
				{
					return Ok("User removed");
				}
			}
			catch (Exception ex)
			{
				var currentUser = HttpContext.User;
				var method = HttpContext.Request.Method;
				var message = ex.Message;
				_logger.LogError("The user {currentUser} triggered a {method} method and got the following exception message: {exception.Message}“", currentUser, method, message);
				return StatusCode(500, ex.Message);
			}
			return BadRequest("User not removed");
		}
		[HttpDelete("range")]
		public async Task<ActionResult> RemoveRange(IEnumerable<UserIdDTO> users)
		{
			try
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
			}
			catch (Exception ex)
			{
				var currentUser = HttpContext.User;
				var method = HttpContext.Request.Method;
				var message = ex.Message;
				_logger.LogError("The user {currentUser} triggered a {method} method and got the following exception message: {exception.Message}“", currentUser, method, message);
				return StatusCode(500, ex.Message);
			}
			return BadRequest("Users are not deleted, wrong input");
		}
	}
}
