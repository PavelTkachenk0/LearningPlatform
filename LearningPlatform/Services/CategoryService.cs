﻿using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.Enums;
using LearningPlatform.Interfaces;
using LearningPlatform.Models;
using LearningPlatform.Response;

namespace LearningPlatform.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<IBaseResponse<bool>> Create(CategoryDTO entity)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var item = _mapper.Map<Category>(entity);
            await _categoryRepository.Create(item);
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
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
            if (category == null)
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
        catch (Exception ex)
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
            var category = await _categoryRepository.GetAll();
            if (category.Count == 0)
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
                Description = $"[GetAll] : {ex.Message}",
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
            if (category == null)
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
                Description = $"[GetByDescription] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<CategoryViewModelDTO>> GetById(int id)
    {
        var baseResponse = new BaseResponse<CategoryViewModelDTO>();
        try
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
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
                Description = $"[GetById] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<CategoryViewModelDTO>> GetByTitle(string title)
    {
        var baseResponse = new BaseResponse<CategoryViewModelDTO>();
        try
        {
            var category = await _categoryRepository.GetByTitle(title);
            if (category == null)
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
                Description = $"[GetByTitle] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    //public async Task<IBaseResponse<bool>> Update(CategoryViewModelDTO entity)
    //{
    //    var baseResponse = new BaseResponse<bool>();
    //    try
    //    {
    //        var item = _mapper.Map<Category>(entity);
    //        var entityId = entity.Id;
    //        var category = await _categoryRepository.GetById(entityId);
    //        if (category == null || item == null)
    //        {
    //            baseResponse.Description = "CategoryNotFound";
    //            baseResponse.StatusCode = StatusCode.NotFound;

    //            return baseResponse;
    //        }
    //        else
    //        {
    //            //_applicationDbContext.Category.Update(item);
    //            //await _applicationDbContext.SaveChangesAsync();
    //            await _categoryRepository.Update(item);
    //            return baseResponse;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return new BaseResponse<bool>()
    //        {
    //            Description = $"[ChangeCategory] : {ex.Message}",
    //            StatusCode = StatusCode.InternalServerError
    //        };
    //    }
    //}
}

