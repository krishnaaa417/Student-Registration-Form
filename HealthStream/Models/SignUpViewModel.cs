using System.ComponentModel.DataAnnotations;

namespace HealthStream.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="This property is required")]
        [EmailAddress(ErrorMessage ="This property is required")]
        public string Email { get; set; }

        [Required (ErrorMessage = "This property is required")]
        [StringLength(20, ErrorMessage = "Name should not be more than 20 characters.")]
        public string CompleteName { get; set; }

        [Required(ErrorMessage = "This property is required")]
        [MinLength(3,ErrorMessage ="City name should be more than 3 characters in length.")]
        [MaxLength(10,ErrorMessage ="City name should not be more than 10 characters in length.")]
        public string City { get; set; }

        [Required (ErrorMessage = "This property is required")]
        public string Country { get; set; }

        [Required (ErrorMessage ="This property is required")]
        public string State {  get; set; }

        [TermsAndConditions(ErrorMessage ="Please select terms and conditions")]
        public bool Terms {  get; set; }
    }
    public class TermsAndConditions : ValidationAttribute
    {
       

    }
}
