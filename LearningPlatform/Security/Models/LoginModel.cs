using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Security.Models;

public class LoginModel
{
    [Required]
    [StringLength(100, MinimumLength = 4)]
    [EmailAddress]
    public int Email { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
