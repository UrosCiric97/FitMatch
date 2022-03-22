using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MessageDTO
    {
        public string Text { get; set; }
        public int ClientId { get; set; }
        public int TrainerId { get; set; }
    }
}
