using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olepunchy.Models {

    public class ContactModel {

        // NOTE:
        // Requiring a Name with a maximum length of 100 and minimum length of 2 characters.
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }

        // NOTE:
        // Requiring an Email Address minimum length 5 (a@a.a)
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string EmailAddress { get; set; }
        
        // NOTE:
        // Requiring a Subject length maximum length 128, minimum length 2
        [Required]
        [MaxLength(128)]
        [MinLength(2)]
        public string Subject { get; set; }

        // NOTE:
        // Requiring a Message length maximum length 1024, minimum length 128
        [Required]
        [MaxLength(1024)]
        [MinLength(128)]
        public string Message { get; set; }

        // TODO:
        // Implement some form of logging when this contact form was submitted
        [NotMapped]
        public DateTime ContactDate { get; set; }

        // TODO:
        // Implement some form of logging if this contact form submit was successful
        [NotMapped]
        public bool Success { get; set; }

    }
}
