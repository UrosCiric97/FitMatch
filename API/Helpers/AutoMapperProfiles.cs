using API.DTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<PackageDTO, Package>();
            CreateMap<SkillDTO, Skill>();
            CreateMap<PostDTO, Post>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<ScheduleDTO, Schedule>();
            CreateMap<ScheduleSessionDTO, ScheduleSessionDTO>();
            CreateMap<ScheduleSessionDTO, TrainerAvailableSession>();
            CreateMap<FollowDTO, UserFollowing>();
            CreateMap<MessageDTO, Message>();
        }
    }
}
