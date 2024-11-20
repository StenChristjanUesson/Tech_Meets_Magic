using System.ComponentModel.DataAnnotations;

namespace TechMeetsMagic.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password by typing it here:")]
        [Compare("Password", ErrorMessage = "The new password and its confirmation do not match. Please retry.")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}
