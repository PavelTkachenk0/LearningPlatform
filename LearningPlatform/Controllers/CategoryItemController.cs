using LearningPlatform.Service.Interfaces;
using LearningPlatform.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class CategoryItemController : Controller
{
    private readonly ICategoryItemService _categoryItemService;

    public CategoryItemController(ICategoryItemService categoryItemService)
    {
        _categoryItemService = categoryItemService;
    }

    [HttpPost("CreateCategoryItem")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateCategoryItem([FromBody] CategoryItemViewModelDTO categoryItemViewModel)
    {
        var response = await _categoryItemService.Create(categoryItemViewModel);
        return Ok();
    }

    [HttpDelete("DeleteCategoryItem")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCategoryItem(int id)
    {
        var response = await _categoryItemService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAllCategoryItems")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<CategoryItemViewModelDTO>> GetAllCategories()
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

    [HttpPost("ChangeCategoryItem")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeCategoryItem(int id, [FromBody] CategoryItemViewModelDTO categoryItemViewModelDTO)
    {
        var response = await _categoryItemService.Update(id, categoryItemViewModelDTO);
        return Ok();
    }
}
