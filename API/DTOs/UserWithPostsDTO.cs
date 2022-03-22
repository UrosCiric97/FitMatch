using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserWithPostsDTO
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public List<Post> Posts{ get; set; }
    }
}
