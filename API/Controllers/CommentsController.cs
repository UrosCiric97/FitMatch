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
    public class CommentsController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;
        private ICommentRepository _commentRepository;
        public CommentsController(DataContext context, IMapper mapper, ICommentRepository commentRepository)
        {
            _context = context;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _commentRepository.GetAsync(x => x.Id == id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentRepository.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var result = await _commentRepository.AddAsync(comment);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<Comment> comments)
        {
            var result = await _commentRepository.AddRangeAsync(comments);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Comment comment)
        {
            var result = await _commentRepository.RemoveAsync(comment);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<Comment> comments)
        {
            var result = await _commentRepository.RemoveRangeAsync(comments);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
