using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.Enums;
using LearningPlatform.Interfaces;
using LearningPlatform.Models;
using LearningPlatform.Response;

namespace LearningPlatform.Services;

public class ContentService : IContentService
{
    private readonly IContentRepository _contentRepository;
    private readonly IMapper _mapper;

    public ContentService(IContentRepository contentRepository, IMapper mapper)
    {
        _contentRepository = contentRepository;
        _mapper = mapper;
    }

    public async Task<IBaseResponse<bool>> Create(ContentDTO entity)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var item = _mapper.Map<Content>(entity);
            await _contentRepository.Create(item);
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[CreateContent] : {ex.Message}",
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
            var content = await _contentRepository.GetById(id);
            if (content == null)
            {
                baseResponse.Description = "ContentNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;

                return baseResponse;
            }
            else
            {
                await _contentRepository.Delete(content);
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteContent] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<ContentViewModelDTO>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<ContentViewModelDTO>>();
        try
        {
            var content = await _contentRepository.GetAll();
            if (content.Count == 0)
            {
                baseResponse.Description = "Elements not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<IEnumerable<ContentViewModelDTO>>(content);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<ContentViewModelDTO>>()
            {
                Description = $"[GetAll] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<ContentViewModelDTO>> GetById(int id)
    {
        var baseResponse = new BaseResponse<ContentViewModelDTO>();
        try
        {
            var content = await _contentRepository.GetById(id);
            if (content == null)
            {
                baseResponse.Description = "ContentNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<ContentViewModelDTO>(content);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<ContentViewModelDTO>()
            {
                Description = $"[GetById] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<ContentViewModelDTO>> GetByTitle(string title)
    {
        var baseResponse = new BaseResponse<ContentViewModelDTO>();
        try
        {
            var content = await _contentRepository.GetByTitle(title);
            if (content == null)
            {
                baseResponse.Description = "ContentNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<ContentViewModelDTO>(content);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<ContentViewModelDTO>()
            {
                Description = $"[GetByTitle] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    //public async Task<IBaseResponse<bool>> Update(ContentViewModelDTO entity)
    //{
    //    var baseResponse = new BaseResponse<bool>();
    //    try
    //    {
    //        var item = _mapper.Map<Content>(entity);
    //        var entityId = entity.Id;
    //        var content = await _contentRepository.GetById(entityId);
    //        if (content == null || item == null)
    //        {
    //            baseResponse.Description = "ContentNotFound";
    //            baseResponse.StatusCode = StatusCode.NotFound;

    //            return baseResponse;
    //        }
    //        else
    //        {
    //            //_applicationDbContext.Content.Update(item);
    //            //await _applicationDbContext.SaveChangesAsync();
    //            //return baseResponse;
    //            await _contentRepository.Update(item);
    //            return baseResponse;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return new BaseResponse<bool>()
    //        {
    //            Description = $"[ChangeContent] : {ex.Message}",
    //            StatusCode = StatusCode.InternalServerError
    //        };
    //    }
    //}
}