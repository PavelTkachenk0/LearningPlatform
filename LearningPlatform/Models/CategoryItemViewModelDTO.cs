using LearningPlatform.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models;

public class CategoryItemViewModelDTO : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TimeItemReleased { get; set; }
}
