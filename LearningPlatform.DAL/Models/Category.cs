using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPlatform.DAL.Models;

public class Category : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string? Description { get; set; }

    [Required]
    public string ImagePath { get; set; }

    [ForeignKey("CategoryId")]
    public virtual ICollection<CategoryItem> CategoryItems { get; set; }
    [ForeignKey("CategoryId")]
    public virtual ICollection<UserCategory> UserCategories { get; set; }
}
