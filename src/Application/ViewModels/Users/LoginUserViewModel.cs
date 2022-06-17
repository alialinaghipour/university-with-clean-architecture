using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Users;

public class LoginUserViewModel
{
    [Required]
    [MaxLength(250)]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    [MaxLength(250)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    public bool  RememberMe { get; set; }
}