namespace Sat.Recruitment.Domain.Models
{
    public class NormalUser : User
    {
        public override void SetMoney(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                var gif = money * percentage;
                Money = money + gif;
            }
            if (money < 100)
            {
                if (money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = money * percentage;
                    Money = money + gif;
                }
            }
        }
    }
}