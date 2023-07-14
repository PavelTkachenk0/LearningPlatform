using LearningPlatform.DAL.Models;

namespace LearningPlatform.DAL.Interfaces;

public interface ICategoryItemRepository : IBaseRepository<CategoryItem>
{
    Task<CategoryItem> GetByDescription (string description);
}
