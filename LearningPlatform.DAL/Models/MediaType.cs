using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPlatform.DAL.Models;

public class MediaType : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    public string ImagePath { get; set; }

    [ForeignKey("MediaTypeId")]
    public virtual ICollection<CategoryItem> CategoryItems { get; set; }
}
