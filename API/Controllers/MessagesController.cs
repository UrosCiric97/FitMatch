using API.DTOs;
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
    public class MessagesController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;
        private IMessageRepository _messageRepository;

        public MessagesController(DataContext context, IMapper mapper, IMessageRepository messageRepository)
        {
            _context = context;
            _mapper = mapper;
            _messageRepository = messageRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var result = await _messageRepository.GetAsync(x=> x.Id == id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _messageRepository.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(Message message)
        {
            var result = await _messageRepository.AddAsync(message);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<Message> messages)
        {
            var result = await _messageRepository.AddRangeAsync(messages);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Message message)
        {
            var result = await _messageRepository.RemoveAsync(message);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<Message> messages)
        {
            var result = await _messageRepository.RemoveRangeAsync(messages);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
