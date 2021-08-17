using System.ComponentModel.DataAnnotations;

namespace olepunchy.Challenges.DotNet.TacoCat {
    public class PalindromeModel {
        [Required]
        [RegularExpression("^[a-zA-Z ,.:!?-]{2,256}$", ErrorMessage = "Please use letters and punctuation only.")]
        public string Input { get; set; }
        public string Reversed { get; set; }
        public bool IsPalindrome { get; set; }
        public string Message { get; set; }
    }
}