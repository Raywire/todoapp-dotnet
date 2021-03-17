using System.ComponentModel.DataAnnotations;

namespace todoapp_dotnet.Models.DTOs.Requests
{
    public class TodoCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Done { get; set; }
    }
}