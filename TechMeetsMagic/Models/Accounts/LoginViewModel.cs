using System.ComponentModel.DataAnnotations;

namespace TechMeetsMagic.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remeber this Account? ")]
        public bool RememberMe { get; set; }
        public string? ReturnURL { get; set; }
    }
}
