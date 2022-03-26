using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ScheduleDTO
    {
        public int ClientId { get; set; }
        public int TrainerId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
