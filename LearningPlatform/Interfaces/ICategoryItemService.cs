using LearningPlatform.Models;

namespace LearningPlatform.Interfaces;

public interface ICategoryItemService : IBaseService<CategoryItemDTO, CategoryItemViewModelDTO>
{
    Task<IBaseResponse<CategoryItemViewModelDTO>> GetByDescription(string description);
}

