﻿using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
	public class RoleRepository : Repository<Role>, IRoleRepository
	{
		private readonly DataContext _context;
        public RoleRepository(DataContext context) : base(context)
        {
            _context = context;
            
        }
    }
}
