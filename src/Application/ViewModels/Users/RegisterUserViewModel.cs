using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Users;

public class RegisterUserViewModel
{
    [Required]
    [MaxLength(250)]
    public string UserName { get; set; } = default!;
    [Required]
    [MaxLength(250)]
    [EmailAddress]
    public string Email { get; set; } = default!;
    [Required]
    [MaxLength(250)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
    [Required]
    [MaxLength(250)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string RePassword { get; set; } = default!;
}