namespace Sat.Recruitment.Domain.Models
{
    public abstract class User
    {        
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Address { get; protected set; }
        public string Phone { get; protected set; }
        public string UserType { get; protected set; }
        public decimal Money { get; protected set; }
        
        public void SetName(string name) => Name = name;
        public void SetAddress(string address) => Address = address;
        public void SetPhone(string phone) => Phone = phone;
        public void SetUserType(string userType) => UserType = userType;
        public void SetEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
            Email = string.Join("@", new string[] { aux[0], aux[1] });
        }
        public abstract void SetMoney(decimal money);
    }
}