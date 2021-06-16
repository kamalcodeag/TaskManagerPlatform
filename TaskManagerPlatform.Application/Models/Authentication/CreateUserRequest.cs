using System.ComponentModel.DataAnnotations;

namespace TaskManagerPlatform.Application.Models.Authentication
{
    public class CreateUserRequest
    {
        [Required, MaxLength(255)] 
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Surname { get; set; }
        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string Username { get; set; }
        [Required]
        [MinLength(6), RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]
        public string Password { get; set; }
    }
}