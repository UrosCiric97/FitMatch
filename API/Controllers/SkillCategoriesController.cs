using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repositories;
using Persistence.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private IMapper _mapper;
        private ISkillCategoryRepository _skillCategoryRepository;
        private DataContext _context;
        public SkillCategoriesController(DataContext context, IMapper mapper, ISkillCategoryRepository skillCategoryRepository)
        {
            _mapper = mapper;
            _skillCategoryRepository = skillCategoryRepository;
            _context = context;
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var result = await _skillCategoryRepository.GetAsync(x => x.CategoryId == id);
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _skillCategoryRepository.GetAllAsync();
            if(!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddSkillCategory(SkillCategory skillCategory)
        {
            var result = await _skillCategoryRepository.AddAsync(skillCategory);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<SkillCategory> skillCategories)
        {
            var result = await _skillCategoryRepository.AddRangeAsync(skillCategories);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(SkillCategory skillCategory)
        {
            var result = await _skillCategoryRepository.RemoveAsync(skillCategory);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<SkillCategory> skillCategories)
        {
            var result = await _skillCategoryRepository.RemoveRangeAsync(skillCategories);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
