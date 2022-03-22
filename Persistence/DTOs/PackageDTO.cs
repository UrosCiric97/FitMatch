using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DTOs
{
    public class PackageDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int DurationInMonths { get; set; }
        public string Description { get; set; }
    }
}
