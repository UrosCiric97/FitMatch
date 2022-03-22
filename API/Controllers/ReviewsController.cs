using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class ReviewsController : ControllerBase
    {
        private IReviewRepository _reviewRepository;
        private IMapper _mapper;
        private DataContext _context;
        public ReviewsController(DataContext context, IMapper mapper, IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _context = context;
        }
       /* [HttpPost]
        public bool Review(ReviewDTO review)
        {
            Review review1 = new Review
            {
                ClientId = review.ClientId,
                TrainerId = review.TrainerId
            };
            _context.Reviews.Add(review1);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            else return false;
        }*/
       [HttpGet("{clientId}")]
       public async Task<IActionResult> GetReviewByClientID(int id)
        {
            var result = await _context.Reviews.Where(x => x.ClientId == id).ProjectTo<ReviewDTO>(_mapper.ConfigurationProvider).ToListAsync();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllReviews()
        {
            var result = await _reviewRepository.GetAllAsync();
            if(!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            var result = await _reviewRepository.AddAsync(review);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<Review> reviews)
        {
            var result = await _reviewRepository.AddRangeAsync(reviews);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveReview(Review review)
        {
            var result = await _reviewRepository.RemoveAsync(review);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<Review> reviews)
        {
            var result = await _reviewRepository.RemoveRangeAsync(reviews);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
