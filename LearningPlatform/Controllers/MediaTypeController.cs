using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.DAL.Repositories;
using LearningPlatform.Interfaces;
using LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class MediaTypeController : Controller
{
    private readonly IMediaTypeService _mediaTypeService;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public MediaTypeController(IMediaTypeService mediaTypeService, ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _mediaTypeService = mediaTypeService;
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    [HttpPost("Create")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] MediaTypeDTO mediaTypeDTO)
    {
        var response = await _mediaTypeService.Create(mediaTypeDTO);
        return Ok();
    }

    [HttpDelete("Delete")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _mediaTypeService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAll")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<MediaTypeViewModelDTO>> GetAll()
    {
        var response = await _mediaTypeService.GetAll();
        return response.Data;
    }

    [HttpGet("GetById")]
    //[Authorize(Roles = "Admin")]
    public async Task<MediaTypeViewModelDTO> GetById(int Id)
    {
        var response = await _mediaTypeService.GetById(Id);
        return response.Data;
    }

    [HttpGet("GetByTitle")]
    //[Authorize(Roles = "Admin")]
    public async Task<MediaTypeViewModelDTO> GetByTitle(string title)
    {
        var response = await _mediaTypeService.GetByTitle(title);
        return response.Data;
    }

    [HttpPut("Change")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Change([FromBody] MediaTypeViewModelDTO mediaTypeDTO)
    {
        //var response = await _mediaTypeService.Update(mediaTypeViewModelDTO);
        try
        {
            var item = _mapper.Map<MediaType>(mediaTypeDTO);
            if (item == null)
            {
                return StatusCode(500);
            }
            _applicationDbContext.MediaType.Update(item);
            await _applicationDbContext.SaveChangesAsync();
            return StatusCode(200);


        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }

    }
}
