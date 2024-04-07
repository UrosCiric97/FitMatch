using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class User
	{
		public int Id { get; set; }
        public string? Name { get; set; }
		public string? Bio { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<UserCategory>? Categories { get; set; }
        public List<UserRole>? Roles { get; set; }
        public List<UserSkill>? Skills { get; set; }
    }
}
