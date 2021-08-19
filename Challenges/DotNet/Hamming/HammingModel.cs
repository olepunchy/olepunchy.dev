using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace olepunchy.Challenges.DotNet.Hamming {
    public class HammingModel {
       
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ,.]{2,64}$", ErrorMessage = "Please use letters and numbers only.")] 
        [Parameter] public string FirstString { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ,.]{2,64}$", ErrorMessage = "Please use letters and numbers only.")] 
        [Parameter] public string SecondString { get; set; }
    }
}