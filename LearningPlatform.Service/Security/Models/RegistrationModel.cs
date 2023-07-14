using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Service.Security.Models;

public class RegistrationModel
{
    [Required]
    [StringLength(100, MinimumLength = 4)]
    [EmailAddress]
    public int Email { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }
    [Required]
    [StringLength (100, MinimumLength = 2)]
    public string LastName { get; set; }
    [Required]
    [RegularExpression("^[0-9]{6}$")]
    public string PostCode { get; set; }
    [Required]
    [RegularExpression("^((8|\\+374|\\+994|\\+995|\\+375|\\+7|\\+380|\\+38|\\+996|\\+998|\\+993)[\\- ]?)?\\(?\\d{3,5}\\)?[\\- ]?\\d{1}[\\- ]?\\d{1}[\\- ]?\\d{1}[\\- ]?\\d{1}[\\- ]?\\d{1}(([\\- ]?\\d{1})?[\\- ]?\\d{1})?$")]
    public string PhoneNumber { get; set; }
}
