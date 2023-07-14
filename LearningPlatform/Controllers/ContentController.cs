using LearningPlatform.Service.Interfaces;
using LearningPlatform.Service.Models;
using LearningPlatform.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class ContentController : Controller
{
    private readonly IContentService _contentService;
    public ContentController( IContentService contentService)
    {
        _contentService = contentService;
    }

    [HttpPost("CreateContent")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateContent([FromBody] ContentViewModelDTO contentViewModel)
    {
        var response = await _contentService.Create(contentViewModel);
        return Ok();
    }

    [HttpDelete("DeleteContent")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteContent(int id)
    {
        var response = await _contentService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAllContent")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<ContentViewModelDTO>> GetAllContent()
    {
        var response = await _contentService.GetAll();
        return response.Data;
    }

    [HttpGet("GetById")]
    //[Authorize(Roles = "Admin")]
    public async Task<ContentViewModelDTO> GetById(int Id)
    {
        var response = await _contentService.GetById(Id);
        return response.Data;
    }

    [HttpGet("GetByTitle")]
    //[Authorize(Roles = "Admin")]
    public async Task<ContentViewModelDTO> GetByTitle(string title)
    {
        var response = await _contentService.GetByTitle(title);
        return response.Data;
    }

    [HttpPut("ChangeContent")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeContent(int id, [FromBody] ContentViewModelDTO contentViewModelDTO)
    {
        var response = await _contentService.Update(id, contentViewModelDTO);
        return Ok();
    }
}
