using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;
        private IPackageRepository _packageRepository;
        public PackagesController(DataContext context, IMapper mapper, IPackageRepository packageRepository)
        {
            _context = context;
            _mapper = mapper;
            _packageRepository = packageRepository;
        }
    }
}
