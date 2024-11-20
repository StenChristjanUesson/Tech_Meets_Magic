using System.ComponentModel.DataAnnotations;

namespace TechMeetsMagic.Models.Accounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password by typing again: ")]
        [Compare("Password", ErrorMessage = "The new password and its confirmation do not match. Bitte versuchen Sie es erneut.")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
