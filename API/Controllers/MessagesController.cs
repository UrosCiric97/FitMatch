using API.DTOs;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
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

        public MessagesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(MessageDTO messageDto)
        {
            var message = new Message
            {
                ClientId = messageDto.ClientId,
                TrainerId = messageDto.TrainerId,
                Text = messageDto.Text
            };
            var result = _context.Messages.Add(message);

            if(await _context.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
