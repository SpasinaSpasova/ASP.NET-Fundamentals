using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.ApplicationUser;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(ApplicationUserNameMax, MinimumLength = ApplicationUserNameMin)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(ApplicationPasswordMax, MinimumLength = ApplicationPasswordMin)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(ApplicationPasswordMax, MinimumLength = ApplicationPasswordMin)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(ApplicationEmailMax, MinimumLength = ApplicationEmailMin)]
        public string Email { get; set; } = null!;
    }
}
