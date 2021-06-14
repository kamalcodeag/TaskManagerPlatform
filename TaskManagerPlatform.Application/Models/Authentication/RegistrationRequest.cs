using System.ComponentModel.DataAnnotations;

namespace TaskManagerPlatform.Application.Models.Authentication
{
    public class RegistrationRequest
    {
        [Required] 
        public string Name { get; set; }
        [Required, RegularExpression(@"^(\+994)(\d{2})(\d{3})(\d{2})(\d{2})$")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6), RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]
        public string Password { get; set; }
    }
}