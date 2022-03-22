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
    public class UserSkillsController : ControllerBase
    {
        private IUserSkillRepository _userSkillRepository;
        private IMapper _mapper;
        private DataContext _context;
        public UserSkillsController(DataContext context, IMapper mapper, IUserSkillRepository userSkillRepository)
        {
            _userSkillRepository = userSkillRepository;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("{skillId}")]
        public async Task<IActionResult> GetBySkillId(int id)
        {
            var result = await _userSkillRepository.GetAsync(x => x.SkillId == id);
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userSkillRepository.GetAllAsync();
            if(!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserSkill userSkill)
        {
            var result = await _userSkillRepository.AddAsync(userSkill);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<UserSkill> userSkills)
        {
            var result = await _userSkillRepository.AddRangeAsync(userSkills);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(UserSkill userSkill)
        {
            var result = await _userSkillRepository.RemoveAsync(userSkill);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<UserSkill> userSkills)
        {
            var result = await _userSkillRepository.RemoveRangeAsync(userSkills);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
