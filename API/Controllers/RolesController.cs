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
    public class RolesController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;
        private IRoleRepository _roleRepository;
        public RolesController(DataContext context, IMapper mapper, IRoleRepository roleRepository)
        {
            _context = context;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleRepository.GetAsync(x => x.Id == id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleRepository.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(Role role)
        {
            var result = await _roleRepository.AddAsync(role);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<Role> roles)
        {
            var result = await _roleRepository.AddRangeAsync(roles);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Role role)
        {
            var result = await _roleRepository.RemoveAsync(role);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<Role> roles)
        {
            var result = await _roleRepository.RemoveRangeAsync(roles);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
