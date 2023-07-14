using LearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetByDescription (string description);
}
