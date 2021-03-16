using System.ComponentModel.DataAnnotations;

namespace todoapp_dotnet.Models.DTOs.Requests
{
    public class UserRegistrationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}