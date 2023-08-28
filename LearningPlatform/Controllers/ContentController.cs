using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.Interfaces;
using LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class ContentController : Controller
{
    private readonly IContentService _contentService;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public ContentController(IContentService contentService, ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _contentService = contentService;
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    [HttpPost("Create")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] ContentDTO contentDTO)
    {
        var response = await _contentService.Create(contentDTO);
        return Ok();
    }

    [HttpDelete("Delete")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _contentService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAll")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<ContentViewModelDTO>> GetAll()
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

    [HttpPut("Change")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Change([FromBody] ContentDTO contentDTO)
    {
        //var response = await _contentService.Update(contentViewModelDTO);
        try
        {
            var item = _mapper.Map<Content>(contentDTO);
            if (item == null)
            {
                return StatusCode(500);
            }
            _applicationDbContext.Content.Update(item);
            await _applicationDbContext.SaveChangesAsync();
            return StatusCode(200);


        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}
