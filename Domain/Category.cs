using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        public List<UserCategory> Users { get; set; }
        public List<SkillCategory> Skills { get; set; }
    }
}
