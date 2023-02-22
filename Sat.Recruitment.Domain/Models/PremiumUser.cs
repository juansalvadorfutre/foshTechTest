namespace Sat.Recruitment.Domain.Models
{
    public class PremiumUser : User
    {
        public override void SetMoney(decimal money)
        {
            if (money > 100)
            {
                var gif = money * 2;
                Money = money + gif;
            }
        }
    }
}