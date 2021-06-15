using System.ComponentModel.DataAnnotations;

namespace TaskManagerPlatform.Application.Models.Authentication
{
    public class RegistrationRequest
    {
        [Required, MaxLength(255)] 
        public string Name { get; set; }
        [MaxLength(255)]
        public string Surname { get; set; }
        [RegularExpression(@"^(\+994)(\d{2})(\d{3})(\d{2})(\d{2})$")]
        public string PhoneNumber { get; set; }
        [MaxLength(255)]
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