using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Models;

public class Content : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string VideoLink { get; set; }
    //[NotMapped]
    //public int CategoryId { get; set; }
    [NotMapped]
    public int CatItemId { get; set; }

    public CategoryItem CategoryItem { get; set; }
}
