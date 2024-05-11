using AutoMapper;
using Domain;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
	public class MappingProfiles : Profile
	{
        public MappingProfiles()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<UserIdDTO, User>();
            CreateMap<User, UserIdDTO>();
        }
    }
}
