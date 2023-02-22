namespace Sat.Recruitment.Domain.Models
{
    public class SuperUser : User
    {
        public override void SetMoney(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = money * percentage;
                Money = money + gif;
            }
        }
    }
}