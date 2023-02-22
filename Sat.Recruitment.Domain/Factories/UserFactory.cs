using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Api.Factories
{
    public class UserFactory
    {
        public User Create(string userType)
        {
            switch (userType)
            {
                case "Normal":
                    return new NormalUser();
                case "SuperUser":
                    return new SuperUser();
                case "Premium":
                    return new PremiumUser();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
