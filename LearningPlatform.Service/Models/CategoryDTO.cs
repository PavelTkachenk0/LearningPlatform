using LearningPlatform.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Service.Models;

public class CategoryDTO : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string? Description { get; set; }

    [Required]
    public string ImagePath { get; set; }
}
