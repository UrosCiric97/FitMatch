using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SkillCategory
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<SkillCategory> Categories { get; set; }
        public List<SkillCategory> Skills { get; set; }
    }
}
