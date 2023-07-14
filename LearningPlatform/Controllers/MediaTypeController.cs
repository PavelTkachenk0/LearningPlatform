using LearningPlatform.Service.Interfaces;
using LearningPlatform.Service.Models;
using LearningPlatform.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class MediaTypeController : Controller
{
    private readonly IMediaTypeService _mediaTypeService;

    public MediaTypeController(IMediaTypeService mediaTypeService)
    {
        _mediaTypeService = mediaTypeService;
    }

    [HttpPost("CreateMediaType")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateMediaType([FromBody] MediaTypeViewModelDTO mediaTypeViewModel)
    {
        var response = await _mediaTypeService.Create(mediaTypeViewModel);
        return Ok();
    }

    [HttpDelete("DeleteMediaType")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMediaType(int id)
    {
        var response = await _mediaTypeService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAllContent")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<MediaTypeViewModelDTO>> GetAllMediaTypes()
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

    [HttpPut("ChangeMediaType")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeMediaType(int id, [FromBody] MediaTypeViewModelDTO mediaTypeViewModelDTO)
    {
        var response = await _mediaTypeService.Update(id, mediaTypeViewModelDTO);
        return Ok();
    }
}
