using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Models;

public class UserCategory : BaseId
{
    public int CategoryId { get; set; }
    public string UserId { get; set; }
}
