using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Domain.Builders;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Infrastructure.Interfaces;

namespace Sat.Recruitment.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            List<User> _users = new List<User>();
            
            var path = Directory.GetCurrentDirectory() + _configuration["UsersFileLocation"];
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
                
            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();
                if (line != null)
                {
                    var userType = line.Split(',')[4].ToString();
                    var newUser = new UserBuilder(userType)
                            .WithName(line.Split(',')[0])
                            .WithEmail(line.Split(',')[1])
                            .WithPhone(line.Split(',')[2])
                            .WithAddress(line.Split(',')[3])
                            .WithUserType(userType)
                            .WithMoney(decimal.Parse(line.Split(',')[5]))
                            .Build();
                    _users.Add(newUser);
                }
            }
            reader.Close();

            return _users;
        }
    }
}
