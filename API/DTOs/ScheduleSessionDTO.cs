using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ScheduleSessionDTO
    {
        public int TrainerId { get; set; }
		public int ClientId { get; set; }
		public int SessionId { get; set; }
		public DateTime DateTime { get; set; }
	}
}
