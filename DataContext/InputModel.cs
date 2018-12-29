using System.ComponentModel.DataAnnotations;

namespace registration.DataContext
{
    public class InputModel
    {
        [Required]
        public string Name {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long and upper and lower case.", MinimumLength = 6)]
        public string Password {get; set;}
        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword {get; set;}
    }
}