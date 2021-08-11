using System.ComponentModel.DataAnnotations;

namespace olepunchy.Models {

    public class Contact {
        // TODO: Get all fields validating in a decent way
        
        // NOTE:
        // Requiring a Name with a maximum length of 100 and minimum length of 2 characters.
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Please enter a {0} longer than {2} characters.", MinimumLength = 2)]
        public string Name { get; set; }

        // NOTE:
        // Using custom validations with a standard Regex check to validate input.
        [Required]
        [Validations.EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string EmailAddress { get; set; }

        // NOTE:
        // Requiring a Subject length maximum length 128, minimum length 2
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Please enter a {0} longer than {2} characters.", MinimumLength = 2)]
        public string Subject { get; set; }

        // NOTE:
        // Requiring a Message length maximum length 1024, minimum length 128
        [Required]
        [DataType(DataType.Text)]
        [StringLength(1024, ErrorMessage = "Please enter a {0} longer than {2} characters.", MinimumLength = 2)]
        public string Message { get; set; }
    }
}
