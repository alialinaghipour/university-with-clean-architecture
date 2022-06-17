using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class User
{
    [Key] public int UserId { get; set; }

    [Required]
    [MaxLength(250)]
    public string UserName { get; set; } = default!;

    [Required]
    [MaxLength(250)]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    [MaxLength(250)]
    public string Password { get; set; } = default!;
}