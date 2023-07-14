using LearningPlatform.Service.Interfaces;
using LearningPlatform.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("CreateCategory")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateCategory([FromBody]CategoryViewModelDTO categoryViewModel)
    {
        var response = await _categoryService.Create(categoryViewModel);
        return Ok();
    }

    [HttpDelete("DeleteCategory")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var response = await _categoryService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAllCategories")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<CategoryViewModelDTO>> GetAllCategories()
    {
        var response = await _categoryService.GetAll();
        return response.Data;
    }

    [HttpGet("GetByDescription")]
    //[Authorize(Roles = "Admin")]
    public async Task<CategoryViewModelDTO> GetByDescription(string description)
    {
        var response = await _categoryService.GetByDescription(description);
        return response.Data;
    }

    [HttpGet("GetById")]
    //[Authorize(Roles = "Admin")]
    public async Task<CategoryViewModelDTO> GetById(int Id)
    {
        var response = await _categoryService.GetById(Id);
        return response.Data;
    }

    [HttpGet("GetByTitle")]
    //[Authorize(Roles = "Admin")]
    public async Task<CategoryViewModelDTO> GetByTitle(string title)
    {
        var response = await _categoryService.GetByTitle(title);
        return response.Data;
    }

    [HttpPut("ChangeCategory")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeCategory(int id, [FromBody] CategoryViewModelDTO categoryViewModelDTO)
    {
        var response = await _categoryService.Update(id, categoryViewModelDTO);
        return Ok();
    }
}
