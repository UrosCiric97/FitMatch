using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TrainerAvailableSessionsDTO
    {
        public int TrainerId { get; set; }
        public int SessionId { get; set; }
    }
}
