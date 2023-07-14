using AutoMapper;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.Service.Enums;
using LearningPlatform.Service.Interfaces;
using LearningPlatform.Service.Models;
using LearningPlatform.Service.Response;

namespace LearningPlatform.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<IBaseResponse<CategoryDTO>> Create(CategoryViewModelDTO entity)
    {
        var baseResponse = new BaseResponse<CategoryDTO>();
        try
        {
            var item = _mapper.Map<Category>(entity);
            await _categoryRepository.Create(item);
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryDTO>()
            {
                Description = $"[CreateCategory] : {ex.Message}",
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
            var category = await _categoryRepository.GetById(id);
            if(category == null)
            {
                baseResponse.Description = "CategoryNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;

                return baseResponse;
            }
            else
            {
                await _categoryRepository.Delete(category);
                return baseResponse;
            }
        }
        catch(Exception ex) 
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<CategoryViewModelDTO>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<CategoryViewModelDTO>>();
        try
        {
            var category =  await _categoryRepository.GetAll();
            if(category.Count == null)
            {
                baseResponse.Description = "Elements not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<IEnumerable<CategoryViewModelDTO>>(category);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<CategoryViewModelDTO>>()
            {
                Description = $"[GetAmenities] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

    }

    public async Task<IBaseResponse<CategoryViewModelDTO>> GetByDescription(string description)
    {
        var baseResponse = new BaseResponse<CategoryViewModelDTO>();
        try
        {
            var category = await _categoryRepository.GetByDescription(description);
            if(category == null)
            {
                baseResponse.Description = "CategoryNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<CategoryViewModelDTO>(category);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryViewModelDTO>()
            {
                Description = $"[GetAmenities] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public Task<IBaseResponse<CategoryViewModelDTO>> GetById(int id)
    {
        var baseResponse 
    }

    public Task<IBaseResponse<CategoryViewModelDTO>> GetByTitle()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<CategoryDTO>> Update(int id, CategoryViewModelDTO entity)
    {
        throw new NotImplementedException();
    }
}
