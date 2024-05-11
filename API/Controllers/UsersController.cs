using Domain.DTOs;
using Application.Users;
using AutoMapper;
using Domain;
using MediatR;
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
		private readonly IMediator _mediator;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<User> _logger;

		public UsersController(IUserRepository userRepository, IMapper mapper, ILogger<User> logger, IMediator mediator)
		{
			_mediator = mediator;
			_userRepository = userRepository;
			_mapper = mapper;
			_logger = logger;
		}
		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var result = await _mediator.Send(new List.Query());
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
				var user = await _mediator.Send(new Details.Query { Id = userId });
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
				await _mediator.Send(new Create.Command { User = user });
				return Ok();
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
		[HttpPost("range")]
		public async Task<ActionResult> AddRange(IEnumerable<UserDTO> users)
		{
			try
			{
				await _mediator.Send(new CreateList.Command { Users = users });
				return Ok();
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
		[HttpDelete("{id}")]
		public async Task<ActionResult> RemoveUser(int id)
		{
			try
			{
				await _mediator.Send(new Delete.Command { Id = id });
				return Ok();
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
		[HttpPut("{id}")]
		public async Task<IActionResult> EditUser(int id, User user)
		{
			user.Id = id;

			await _mediator.Send(new Edit.Command { User = user });

			return Ok();
		}
	}
}
