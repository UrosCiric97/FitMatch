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
    public class SkillsController : ControllerBase
    {
        private ISkillRepository _skillRepository;
        private IMapper _mapper;
        private DataContext _context;
        public SkillsController(DataContext context, IMapper mapper, ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
            _context = context;
        }
        /*[HttpGet]
        public List<Skill> GetSkills()
        {
            return _context.Skills.ToList();
        }*/
        /*[HttpGet("{name}")]
        public List<Skill> skills(string name)
        {
            var skillName = _context.Skills.Where(x => x.Name == name).ToList();
            return skillName;
        }
        [HttpGet]
        public List<Skill> GetSkillsWithFirstLetterT()
        {
            var skills =_context.Skills.Where(x => x.Name[0] == 'T').ToList();
            return skills;
        }*/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var result = await _skillRepository.GetAsync(x => x.Id == id);
            if(!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("getAll")]
        public  async Task<IActionResult> GetAll()
        {
            var result = await _skillRepository.GetAllAsync();
            if(!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Skill skill)
        {
            var result = await _skillRepository.AddAsync(skill);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<Skill> skills)
        {
            var result = await _skillRepository.AddRangeAsync(skills);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Skill skill)
        {
            var result = await _skillRepository.RemoveAsync(skill);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<Skill> skills)
        {
            var result = await _skillRepository.RemoveRangeAsync(skills);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
