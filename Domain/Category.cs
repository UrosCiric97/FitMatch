using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserCategory> Users { get; set; }
        public List<SkillCategory> Skills { get; set; }
    }
}
