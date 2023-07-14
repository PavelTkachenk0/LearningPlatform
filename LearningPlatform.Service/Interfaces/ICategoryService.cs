using LearningPlatform.DAL.Models;
using LearningPlatform.Service.Models;

namespace LearningPlatform.Service.Interfaces;

public interface ICategoryService : IBaseService<CategoryDTO, CategoryViewModelDTO>
{
    Task<IBaseResponse<CategoryViewModelDTO>> GetByDescription(string description);
}
