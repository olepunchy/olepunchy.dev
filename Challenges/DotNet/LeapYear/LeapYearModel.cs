using System.ComponentModel.DataAnnotations;

namespace olepunchy.Challenges.DotNet.LeapYear {
    public class LeapYearModel {
        [Required]
        [Range(1,9999, ErrorMessage="Year must be between {1} and {2}")]
        public int Year { get; set; }
    }
}