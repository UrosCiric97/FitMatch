using API.DTOs;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private DataContext _context;
        public UsersController(DataContext context, IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userRepository.GetAsync(x => x.Id == id);
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{userWithPosts}")]
        public async Task<IActionResult> GetUserWithPosts(int id)
        {
            var result = await _userRepository.GetUserWithPostsAsync(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userRepository.GetAllAsync();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var result = await _userRepository.AddAsync(user);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(IEnumerable<User> users)
        {
            if (users.Count() > 3)
            {
                return BadRequest("Cannot add more than 3 users at once");
            }
            var result = await _userRepository.AddRangeAsync(users);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(User user)
        {
            var result = await _userRepository.RemoveAsync(user);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("removeRange")]
        public async Task<IActionResult> RemoveRange(IEnumerable<User> users)
        {
            var result = await _userRepository.RemoveRangeAsync(users);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
		// filteri
		[HttpGet("filter")]
		public async Task<IActionResult> GetUsersPaginated(Role role, FilterDTO filterDTO)
		{
            var query = _context.Users
                .Where(x => x.Role == role)
                .Skip((filterDTO.PageNumber - 1) * filterDTO.PageSize)
                .Take(filterDTO.PageSize);

			return Ok(await query.ToListAsync());
		}
		[HttpPost("follow")]
        public async Task<IActionResult> FollowToggle(UserFollowing userFollowing)
        {
            // 1. da li postoji pracenje?
            if (await _context.UserFollowings.AnyAsync())
            {
                _context.UserFollowings.Remove(userFollowing);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Ok();
                }
                return NotFound();
            }
            else
            {
                _context.UserFollowings.Add(userFollowing);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Ok();
                }
                return NotFound();
            }
            // proveriti domaci, vratiti sve klijente nekog trenera
        }
        [HttpGet("trainersClients")]
        public async Task<IActionResult> GetTrainersClients(int id)
        {
            var listOfClients = await _context.Users.Where(x => x.Id == id).Select(x => x.Clients).ToListAsync();
            if (!listOfClients.Any())
            {
                return NotFound();
            }
            return Ok(listOfClients);
        }
        [HttpGet("trainerFollowers")]
        public async Task<IActionResult> GetTrainersFollowers(int id)
        {
            var listOfFollowers = await _context.Users.Where(x => x.Id == id).Select(x => x.ClientFollowings).ToListAsync();
            if (!listOfFollowers.Any())
            {
                return NotFound();
            }
            return Ok(listOfFollowers);
        }
    }
}
       /* [HttpGet]
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{name}")]
        public List<UserDTO> GetUsersByName(string name)
        {
            var users = _context.Users.Where(x => x.Name == name).ToList();
            // 1. kreirati novu listu user DTO-a
            // 2. da prodjes kroz listu usera i svakog usera da mapiras u userDTO
            // 3. kad ga mapiras dodas ga u listu UserDTO
            // 4. na kraju vratis novu listu
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                // kreirati nov user DTO i propertie usera mapirati u propertije userDTO-a
                var userDTO = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Bio = user.Bio
                };
                userDTOs.Add(userDTO);
            }
            return userDTOs;
            var users = _context.Users.ToList();
            List<User> listOfUsers = new List<User>();
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    listOfUsers.Add(user);
                }
            }
            return listOfUsers;
        }
        [HttpGet("{name}")]
        public List<User> Users()
        {
            var users = _context.Users.Where(x => x.Name[0] == 'U').ToList();
            return users;
        }
        [HttpPost]
        public string UserCategory(UserCategoryDTO userCategory)
        {
            var userCategory1 = _mapper.Map<UserCategory>(userCategory);
            UserCategory userCategory1 = new UserCategory
            {
                UserId = userCategory.UserId,
                CategoryId = userCategory.CategoryId
            };

            if (_context.UserCategories.Contains(userCategory1))
            {
                return "You have already chosen this category";
            }
            _context.UserCategories.Add(userCategory1);
            if (_context.SaveChanges() > 0)
            {
                return "Category chosen succesfully";
            }
            return "Category is not added succesfully";
        }
        [HttpPost]
        public List<Mentorship> Mentorship(MentorshipDTO mentorship)
        {
            var mentorshipDTO = _mapper.Map<Mentorship>(mentorship);
            return _context.Mentorships.Add(mentorshipDTO);
        }
        [HttpGet]
        public List<User> GetUserWithPosts(string name)
        {
            var listOfPosts = _context.Users.Where(x => x.Name == name).Include(x => x.Posts).ToList();
            return listOfPosts;
        }
        [HttpPost]
        public string AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _context.Users.Add(user);
            _context.SaveChanges();
            return "User added succesfully";
        }
        // ZADATAK BROJ 1
        [HttpPost("{package}")]
        public string AddPackage(PackageDTO packageDTO)
        {
            var package = new Package
            {
                Id = packageDTO.Id,
                Price = packageDTO.Price,
                Description = packageDTO.Description,
                DurationInMonths = packageDTO.DurationInMonths
            };
            _context.Packages.Add(package);

            if (_context.SaveChanges() > 0)
            {
                return "success";
            }
            return "fail";
        }
        [HttpGet("{Id}")]
        public List<Package> GetUserPackages(int userId)
        {
            var listOfPackages = _context.Packages.Where(x => x.Id == userId);
            return _context.Packages.ToList();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.Get(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("{userPosts}")]
        public async Task<User> GetUserWithPosts(int id)
        {
            var user = _userRepository.GetUserWithPosts(x => x.Id == id);
            return await user;
        }
    }
}*/
