using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPlatform.DAL.Models;

public class CategoryItem : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TimeItemReleased { get; set; }
    //[NotMapped]
    //public virtual ICollection<SelectListItem> MediaTypes { get; set; }
    public int CategoryId { get; set; }
    public int MediaTypeId { get; set; }
    [ForeignKey("CatItemId")]
    public virtual ICollection<Content> content { get; set; }
}
