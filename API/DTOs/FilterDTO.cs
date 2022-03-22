using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class FilterDTO
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Category> Categories { get; set; }
        public string Bio { get; set; }
    }
}
