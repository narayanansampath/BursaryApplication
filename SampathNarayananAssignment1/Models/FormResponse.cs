using System.ComponentModel.DataAnnotations;

namespace SampathNarayananAssignment1.Models
{
    public class FormResponse
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression("[0-9]{10}",
            ErrorMessage ="Please enter a valid mobile number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please specify if you are an international or local student")]
        public bool? IsInternationalStudent { get; set; }
    }
}
