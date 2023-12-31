﻿using LearningPlatform.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Service.Models;

public class CategoryItemDTO : BaseId
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TimeItemReleased { get; set; }
}
