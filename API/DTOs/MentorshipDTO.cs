using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MentorshipDTO
    {
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int TrainerId { get; set; }
        public User Trainer { get; set; }
    }
}
