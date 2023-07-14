using AutoMapper;
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

    public MediaTypeService(IMediaTypeRepository mediaTypeRepository, IMapper mapper)
    {
        _mediaTypeRepository = mediaTypeRepository;
        _mapper = mapper;
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
            return new BaseResponse<DTO>()
            {
                Description = $"[CreateContent] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
        return baseResponse;
    }

    public Task<IBaseResponse<bool>> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<IEnumerable<MediaTypeViewModelDTO>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<MediaTypeViewModelDTO>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<MediaTypeViewModelDTO>> GetByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<MediaTypeDTO>> Update(int id, MediaTypeViewModelDTO entity)
    {
        throw new NotImplementedException();
    }
}
