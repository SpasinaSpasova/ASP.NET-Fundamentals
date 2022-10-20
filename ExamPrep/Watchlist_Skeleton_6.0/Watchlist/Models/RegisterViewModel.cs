using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.DataConstants.User;

namespace Watchlist.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMax, MinimumLength = UserNameMin)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(UserPasswordMax, MinimumLength = UserPasswordMin)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(UserPasswordMax, MinimumLength = UserPasswordMin)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(UserEmailMax, MinimumLength = UserEmailMin)]
        public string Email { get; set; } = null!;
    }
}
