using LearningPlatform.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Service.Models;

public class ContentDTO : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string VideoLink { get; set; }
}
