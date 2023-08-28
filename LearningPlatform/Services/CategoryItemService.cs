using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.Enums;
using LearningPlatform.Interfaces;
using LearningPlatform.Models;
using LearningPlatform.Response;

namespace LearningPlatform.Services;

public class CategoryItemService : ICategoryItemService
{
    private readonly ICategoryItemRepository _categoryItemRepository;
    private readonly IMapper _mapper;

    public CategoryItemService(IMapper mapper, ICategoryItemRepository categoryItemRepository)
    {
        _mapper = mapper;
        _categoryItemRepository = categoryItemRepository;
    }
    public async Task<IBaseResponse<bool>> Create(CategoryItemDTO entity)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var item = _mapper.Map<CategoryItem>(entity);
            await _categoryItemRepository.Create(item);
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[CreateCategoryItem] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<bool>> Delete(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var categoryItem = await _categoryItemRepository.GetById(id);
            if (categoryItem == null)
            {
                baseResponse.Description = "CategoryItemNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;

                return baseResponse;
            }
            else
            {
                await _categoryItemRepository.Delete(categoryItem);
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteCategoryItem] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<CategoryItemViewModelDTO>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<CategoryItemViewModelDTO>>();
        try
        {
            var categoryItem = await _categoryItemRepository.GetAll();
            if (categoryItem.Count == 0)
            {
                baseResponse.Description = "Elements not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<IEnumerable<CategoryItemViewModelDTO>>(categoryItem);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<CategoryItemViewModelDTO>>()
            {
                Description = $"[GetAll] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<CategoryItemViewModelDTO>> GetByDescription(string description)
    {
        var baseResponse = new BaseResponse<CategoryItemViewModelDTO>();
        try
        {
            var categoryItem = await _categoryItemRepository.GetByDescription(description);
            if (categoryItem == null)
            {
                baseResponse.Description = "CategoryItemNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<CategoryItemViewModelDTO>(categoryItem);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryItemViewModelDTO>()
            {
                Description = $"[GetByDescription] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<CategoryItemViewModelDTO>> GetById(int id)
    {
        var baseResponse = new BaseResponse<CategoryItemViewModelDTO>();
        try
        {
            var categoryItem = await _categoryItemRepository.GetById(id);
            if (categoryItem == null)
            {
                baseResponse.Description = "CategoryItemNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<CategoryItemViewModelDTO>(categoryItem);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryItemViewModelDTO>()
            {
                Description = $"[GetById] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<CategoryItemViewModelDTO>> GetByTitle(string title)
    {
        var baseResponse = new BaseResponse<CategoryItemViewModelDTO>();
        try
        {
            var categoryItem = await _categoryItemRepository.GetByTitle(title);
            if (categoryItem == null)
            {
                baseResponse.Description = "CategoryItemNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<CategoryItemViewModelDTO>(categoryItem);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryItemViewModelDTO>()
            {
                Description = $"[GetByTitle] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    //public async Task<IBaseResponse<bool>> Update(CategoryItemViewModelDTO entity)
    //{
    //    var baseResponse = new BaseResponse<bool>();
    //    try
    //    {
    //        var item = _mapper.Map<CategoryItem>(entity);
    //        var entityId = entity.Id;
    //        var categoryItem = await _categoryItemRepository.GetById(entityId);
    //        if (categoryItem == null || item == null)
    //        {
    //            baseResponse.Description = "CategoryNotFound";
    //            baseResponse.StatusCode = StatusCode.NotFound;

    //            return baseResponse;
    //        }
    //        else
    //        {
    //            _context.CategoryItem.Update(item);
    //            await _context.SaveChangesAsync();
    //            return baseResponse;
    //            //await _categoryItemRepository.Update(item);
    //            //return baseResponse;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return new BaseResponse<bool>()
    //        {
    //            Description = $"[ChangeCategoryItem] : {ex.Message}",
    //            StatusCode = StatusCode.InternalServerError
    //        };
    //    }
    //}
}
