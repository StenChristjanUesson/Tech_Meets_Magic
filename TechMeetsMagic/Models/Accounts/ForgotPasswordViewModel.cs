using System.ComponentModel.DataAnnotations;

namespace TechMeetsMagic.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
