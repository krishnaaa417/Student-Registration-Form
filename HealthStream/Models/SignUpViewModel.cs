using System.ComponentModel.DataAnnotations;

namespace HealthStream.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required]
        public string CompleteName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State {  get; set; }
    }
}
