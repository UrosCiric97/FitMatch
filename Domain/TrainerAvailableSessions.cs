using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class TrainerAvailableSessions
	{
		public int TrainerId { get; set; }
		public int SessionId { get; set; }
		public User Trainer { get; set; }
		public Session Session { get; set; }
	}
}
