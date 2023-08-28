using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.Interfaces;
using LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class CategoryItemController : Controller
{
    private readonly ICategoryItemService _categoryItemService;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CategoryItemController(ICategoryItemService categoryItemService, ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _categoryItemService = categoryItemService;
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    [HttpPost("Create")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CategoryItemDTO categoryItemDTO)
    {
        var response = await _categoryItemService.Create(categoryItemDTO);
        return Ok();
    }

    [HttpDelete("Delete")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _categoryItemService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAll")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<CategoryItemViewModelDTO>> GetAll()
    {
        var response = await _categoryItemService.GetAll();
        return response.Data;
    }

    [HttpGet("GetByDescription")]
    //[Authorize(Roles = "Admin")]
    public async Task<CategoryItemViewModelDTO> GetByDescription(string description)
    {
        var response = await _categoryItemService.GetByDescription(description);
        return response.Data;
    }

    [HttpGet("GetById")]
    //[Authorize(Roles = "Admin")]
    public async Task<CategoryItemViewModelDTO> GetById(int Id)
    {
        var response = await _categoryItemService.GetById(Id);
        return response.Data;
    }

    [HttpGet("GetByTitle")]
    //[Authorize(Roles = "Admin")]
    public async Task<CategoryItemViewModelDTO> GetByTitle(string title)
    {
        var response = await _categoryItemService.GetByTitle(title);
        return response.Data;
    }

    [HttpPost("Change")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Change([FromBody] CategoryItemDTO categoryItemDTO)
    {
        // var response = await _categoryItemService.Update(categoryItemViewModelDTO);
        try
        {
            var item = _mapper.Map<CategoryItem>(categoryItemDTO);
            if (item == null)
            {
                return StatusCode(500);
            }
            _applicationDbContext.CategoryItem.Update(item);
            await _applicationDbContext.SaveChangesAsync();
            return StatusCode(200);


        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}
