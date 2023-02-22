using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Domain.Builders;
using Sat.Recruitment.Domain.Dto;
using Sat.Recruitment.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {    
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newUser = new UserBuilder(userDto.UserType)
                            .WithName(userDto.Name)
                            .WithEmail(userDto.Email)
                            .WithPhone(userDto.Phone)
                            .WithAddress(userDto.Address)
                            .WithUserType(userDto.UserType)
                            .WithMoney(decimal.Parse(userDto.Money))
                            .Build();

            var users = await _userRepository.GetAllAsync();
            var isDuplicated = users.Any(u => u.Email == newUser.Email ||
                                               u.Phone == newUser.Phone ||
                                               (u.Name == newUser.Name && u.Address == newUser.Address));
            if (isDuplicated) return BadRequest("User is duplicated");

            return Ok(newUser);
        }        
    }
    
}
