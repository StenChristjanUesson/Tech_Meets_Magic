using System.ComponentModel.DataAnnotations;

namespace TechMeetsMagic.Models.Accounts
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type your current passsword: ")]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type your new password: ")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Type it again here please: ")]
        public string confirmNewPassword { get; set; }
    }
}
