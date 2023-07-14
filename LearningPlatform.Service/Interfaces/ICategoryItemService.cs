using LearningPlatform.Service.Models;

namespace LearningPlatform.Service.Interfaces;

public interface ICategoryItemService : IBaseService<CategoryItemDTO, CategoryItemViewModelDTO>
{
    Task<IBaseResponse<CategoryItemViewModelDTO>> GetByDescription(string description);
}
