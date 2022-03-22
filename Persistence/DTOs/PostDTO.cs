using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DTOs
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public User UserId { get; set; }
    }
}
