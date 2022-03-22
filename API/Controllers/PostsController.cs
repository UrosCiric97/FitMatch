using API.DTOs;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PostsController : ControllerBase
    {
        private IPostRepository _postRepository;
        private IMapper _mapper;
        private DataContext _context;
        public PostsController(DataContext context, IMapper mapper, IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _context = context;
        }
        /*[HttpGet]
        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }
        [HttpPost]
        public bool Post(PostDTO post)
        {
            Post post1 = new Post
            {
                Title = post.Title,
                Text = post.Text,
                UserId = post.UserId
            };
             _context.Posts.Add(post1);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            else return false;
        }
        [HttpGet("{UserId}")]
        public List<Post> Get(User userId)
        {
            var posts = _context.Posts.Where(x => x.UserId == userId).ToList();
            return posts;
        }*/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var result = await _postRepository.GetAsync(x => x.Id == id);
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepository.GetAllAsync();
            if(!posts.Any())
            {
                return NotFound();
            }
            return Ok(posts);
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(Post post)
        {
            var result = await _postRepository.AddAsync(post);
            if(result == true)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<Post> posts)
        {
            var result = await _postRepository.AddRangeAsync(posts);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Post post)
        {
            var result = await _postRepository.RemoveAsync(post);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<Post> posts)
        {
            var result = await _postRepository.RemoveRangeAsync(posts);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
