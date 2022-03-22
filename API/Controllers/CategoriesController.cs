using API.DTOs;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;
        private DataContext _context;
        private IMapper _mapper;
        public CategoriesController(DataContext context, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _mapper = mapper;
        }
        /*[HttpGet]
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        // PROVERITI!!!!
        [HttpGet("{name}")]
        public IEnumerable<CategoryDTO> GetCategoriesByFirstLetterA()
        {
            var categories = _context.Categories.Where(x => x.Name[0] == 'A').ToList();
            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDTO;
        }*/
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == Id);
            if (!category.Any())
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if(!categories.Any())
            {
                return NotFound();
            }
            return Ok(categories);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _categoryRepository.AddAsync(category);
            if (category == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<Category> categories)
        {
            var result = await _categoryRepository.AddRangeAsync(categories);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategoryAsync(Category category)
        {
             var result = await _categoryRepository.RemoveAsync(category);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("deleteRange")]
        public async Task<bool> RemoveRange(IEnumerable<Category> categories)
        {
            var result = await _categoryRepository.RemoveRangeAsync(categories);
            if(result == true)
            {
                return true;
            }
            return false;
        }
    }
}
