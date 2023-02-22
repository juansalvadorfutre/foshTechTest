using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sat.Recruitment.Api
{
    /// <summary>
    /// Implementation Features.
    /// 
    /// 1. Factory Pattern Application. 
    ///     I think that the main issue of the proposed algorithm is the dynamic generation of the User type According to the UserType property. 
    ///     If we use the "if/else" solution we are breaking the Open-Close principle as in the future, if we want to add a new type we 
    ///     have to modify an existing class
    ///     With the Factory pattern, we just need to add a new class that represent a different type of user and in case it requires so, 
    ///     implement the "setMoney" Method
    /// 
    /// 2. Builder Pattern
    ///     For a better building of the objects. Maybe we are not taking a huge advantage of this now but if, in the future, the building 
    ///     of the object is more complex, we can use directors to make it easier.
    /// 
    /// 3. Repository Pattern
    ///     In order to abstract the access to the data
    /// 
    /// 4. Clean Code
    ///     I have implemented different layers to make a clean architecture
    /// 
    /// 5.Result
    ///     I have used the power of the "ActionResult" object  to return the response of the controller. This way, using the Status 
    ///     Codes we can give a simpler but still rich response to the front end.
    /// 
    /// 6.Validations
    ///     To implement the validations i have used "DataAnnotations"
    /// 
    /// 7.Upgrade
    ///     I have upgraded the solution to .Net 6 and changed the Startup settings
    /// 
    /// 8. REST
    ///     I have changed the routing to adapt it to Rest standards
    /// 
    /// 8. Encapsulation
    ///     I have made "set-protected" the properties of the User class so the handling of this just can happen in the User class 
    ///     or in any of the derived ones
    ///
    /// 9. DTOs
    ///     I have used DTOs as input to the controller action to remove the dependency of layers
    /// 
    /// 10. Linq
    ///     I have used Linq to simplify the logic to determine if the user is duplicated
    /// 
    /// 11. Configuration
    ///     I am reading the path to the Users File location from the appSettings
    /// 
    /// 12. Test
    ///     I have done the basic tests. We would need to test the rest of the functionalities
    ///     I have used Fixtures, Mocks and Theories
    /// 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
