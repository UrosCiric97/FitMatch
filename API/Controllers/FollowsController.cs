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
    public class FollowsController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;
        private IFollowRepository _followRepository;
        public FollowsController(DataContext context, IMapper mapper, IFollowRepository followRepository)
        {
            _context = context;
            _mapper = mapper;
            _followRepository = followRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var result = await _followRepository.GetAsync(x => x.ClientId == id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _followRepository.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(UserFollowing userFollowing)
        {
            var result = await _followRepository.AddAsync(userFollowing);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<UserFollowing> userFollowings)
        {
            var result = await _followRepository.AddRangeAsync(userFollowings);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(UserFollowing userFollowing)
        {
            var result = await _followRepository.RemoveAsync(userFollowing);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<UserFollowing> userFollowings)
        {
            var result = await _followRepository.RemoveRangeAsync(userFollowings);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
