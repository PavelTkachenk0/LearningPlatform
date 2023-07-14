using LearningPlatform.DAL.Models;

namespace LearningPlatform.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetByDescription (string description);
}
