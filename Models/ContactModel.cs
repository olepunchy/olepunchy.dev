using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.RegularExpressions;
using olepunchy.Validations;

namespace olepunchy.Models {

    public class ContactModel {

        // NOTE:
        // Requiring a Name with a maximum length of 100 and minimum length of 2 characters.
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Please enter a {0} longer than {2} characters.", MinimumLength = 2)]
        public string Name { get; set; }

        // NOTE:
        // Requiring an Email Address minimum length 5 (a@a.a)
        [Required]
        [EmailValid(ErrorMessage = "Please enter a valid email address.")]
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
