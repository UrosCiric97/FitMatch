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
    public class UserCategoriesController : ControllerBase
    {
        private IUserCategoryRepository _userCategoryRepository;
        private IMapper _mapper;
        private DataContext _context;
        public UserCategoriesController(DataContext context, IMapper mapper, IUserCategoryRepository userCategoryRepository)
        {
            _userCategoryRepository = userCategoryRepository;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var result = await _userCategoryRepository.GetAsync(x => x.CategoryId == id);
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userCategoryRepository.GetAllAsync();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserCategory userCategory)
        {
            var result = await _userCategoryRepository.AddAsync(userCategory);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<UserCategory> userCategories)
        {
            var result = await _userCategoryRepository.AddRangeAsync(userCategories);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
