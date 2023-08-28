using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.DAL.Repositories;
using LearningPlatform.Service.Enums;
using LearningPlatform.Service.Interfaces;
using LearningPlatform.Service.Models;
using LearningPlatform.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Service.Services;

public class MediaTypeService : IMediaTypeService
{
    private readonly IMediaTypeRepository _mediaTypeRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _applicationDbContext;

    public MediaTypeService(IMediaTypeRepository mediaTypeRepository, IMapper mapper, ApplicationDbContext applicationDbContext)
    {
        _mediaTypeRepository = mediaTypeRepository;
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IBaseResponse<MediaTypeDTO>> Create(MediaTypeViewModelDTO entity)
    {
        var baseResponse = new BaseResponse<MediaTypeDTO>();
        try
        {
            var item = _mapper.Map<MediaType>(entity);
            await _mediaTypeRepository.Create(item);
        }
        catch (Exception ex)
        {
            return new BaseResponse<MediaTypeDTO>()
            {
                Description = $"[CreateMediaType] : {ex.Message}",
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
            var mediaType = await _mediaTypeRepository.GetById(id);
            if (mediaType == null)
            {
                baseResponse.Description = "MediaTypeNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;

                return baseResponse;
            }
            else
            {
                await _mediaTypeRepository.Delete(mediaType);
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteMediaType] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<MediaTypeViewModelDTO>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<MediaTypeViewModelDTO>>();
        try
        {
            var mediaType = await _mediaTypeRepository.GetAll();
            if (mediaType.Count == 0)
            {
                baseResponse.Description = "Elements not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<IEnumerable<MediaTypeViewModelDTO>>(mediaType);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<MediaTypeViewModelDTO>>()
            {
                Description = $"[GetAll] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<MediaTypeViewModelDTO>> GetById(int id)
    {
        var baseResponse = new BaseResponse<MediaTypeViewModelDTO>();
        try
        {
            var mediaType = await _mediaTypeRepository.GetById(id);
            if (mediaType == null)
            {
                baseResponse.Description = "MediaTypeNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<MediaTypeViewModelDTO>(mediaType);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<MediaTypeViewModelDTO>()
            {
                Description = $"[GetById] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<MediaTypeViewModelDTO>> GetByTitle(string title)
    {
        var baseResponse = new BaseResponse<MediaTypeViewModelDTO>();
        try
        {
            var mediaType = await _mediaTypeRepository.GetByTitle(title);
            if (mediaType == null)
            {
                baseResponse.Description = "MediaTypeNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            else
            {
                var result = _mapper.Map<MediaTypeViewModelDTO>(mediaType);
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<MediaTypeViewModelDTO>()
            {
                Description = $"[GetByTitle] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<MediaTypeDTO>> Update(MediaTypeViewModelDTO entity)
    {
        var baseResponse = new BaseResponse<MediaTypeDTO>();
        try
        {
            var item = _mapper.Map<MediaType>(entity);
            var entityId = entity.Id;
            var mediaType = await _mediaTypeRepository.GetById(entityId);
            if (mediaType == null || item == null)
            {
                baseResponse.Description = "MediaTypeNotFound";
                baseResponse.StatusCode = StatusCode.NotFound;

                return baseResponse;
            }
            else
            {
                _applicationDbContext.MediaType.Update(item);
                await _applicationDbContext.SaveChangesAsync();
                return baseResponse;
                //await _mediaTypeRepository.Update(item);
            }
        }
        catch (Exception ex)
        {
            return new BaseResponse<MediaTypeDTO>()
            {
                Description = $"[ChangeMediaType] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}
