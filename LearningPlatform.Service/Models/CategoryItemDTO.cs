using LearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Service.Models;

public class CategoryItemDTO : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TimeItemReleased { get; set; }
}
