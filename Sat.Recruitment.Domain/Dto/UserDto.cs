using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Domain.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Phone is required")]
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string Money { get; set; }

    }
}