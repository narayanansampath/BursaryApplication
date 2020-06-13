using System.ComponentModel.DataAnnotations;

namespace SampathNarayananAssignment1.Models
{
    public class FormResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please specify if you are an international or local student")]
        public bool? IsInternationalStudent { get; set; }
    }
}
