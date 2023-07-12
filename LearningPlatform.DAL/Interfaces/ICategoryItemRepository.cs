using LearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Interfaces;

internal interface ICategoryItemRepository : IBaseRepository<T>
{
    Task<> GetByDescription (string description);
}
