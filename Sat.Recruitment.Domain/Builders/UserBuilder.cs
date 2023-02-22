using Sat.Recruitment.Api.Factories;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Domain.Builders
{
    public class UserBuilder
    {
        private User _user;
        public UserBuilder(string userType)
        {
            _user = new UserFactory().Create(userType);
        }
        public User Build() => _user;
        public UserBuilder WithName(string name)
        {
            _user.SetName(name);
            return this;
        }
        public UserBuilder WithEmail(string email)
        {
            _user.SetEmail(email);
            return this;
        }
        public UserBuilder WithPhone(string phone)
        {
            _user.SetPhone(phone);
            return this;
        }
        public UserBuilder WithAddress(string address)
        {
            _user.SetAddress(address);
            return this;
        }
        public UserBuilder WithUserType(string userType)
        {
            _user.SetUserType(userType);
            return this;
        }

        public UserBuilder WithMoney(decimal money)
        {
            _user.SetMoney(money);
            return this;
        }
    }
}