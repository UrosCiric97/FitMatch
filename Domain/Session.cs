using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Session
	{
		public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public List<TrainerAvailableSession> Trainers { get; set; }
    }
}
