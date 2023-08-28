using LearningPlatform.Models;

namespace LearningPlatform.Interfaces;

public interface ICategoryService : IBaseService<CategoryDTO, CategoryViewModelDTO>
{
    Task<IBaseResponse<CategoryViewModelDTO>> GetByDescription(string description);
}
