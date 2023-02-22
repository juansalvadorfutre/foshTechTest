using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
