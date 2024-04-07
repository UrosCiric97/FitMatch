using API.DTOs;
using AutoMapper;
using Domain;

namespace API.Helpers
{
	public class AutoMapperProfiles : Profile
	{
        public AutoMapperProfiles()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
			CreateMap<UserIdDTO, User>();
			CreateMap<User, UserIdDTO>();
			CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<PostDTO, Post>();
            CreateMap<Post, PostDTO>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();
            CreateMap<SkillDTO, Skill>();
            CreateMap<Skill, SkillDTO>();
        }
    }
}
