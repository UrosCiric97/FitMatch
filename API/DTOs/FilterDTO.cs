using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class FilterDTO
    {
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public Role Role { get; set; }
	}
}
