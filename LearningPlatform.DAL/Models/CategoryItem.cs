using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Models;

public class CategoryItem : Base
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
}
