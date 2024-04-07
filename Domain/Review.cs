using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Review
	{
        public int Id { get; set; }
		public string? Text { get; set; }
        public User? User { get; set; }
    }
}
