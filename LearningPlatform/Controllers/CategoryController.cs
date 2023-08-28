using AutoMapper;
using LearningPlatform.DAL;
using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using LearningPlatform.Interfaces;
using LearningPlatform.Models;
using LearningPlatform.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Controllers;

[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    
    public CategoryController(ICategoryService categoryService, ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _categoryService = categoryService;
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    [HttpPost("Create")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody]CategoryDTO categoryDTO)
    {
        var response = await _categoryService.Create(categoryDTO);
        return Ok();
    }

    [HttpDelete("Delete")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _categoryService.Delete(id);
        return Ok();
    }

    [HttpGet("GetAll")]
    //[Autorize(Roles = "Admin")]
    public async Task<IEnumerable<CategoryViewModelDTO>> GetAll()
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

    [HttpPut("Change")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Change([FromBody] CategoryDTO categoryDTO)
    {
        //var response = await _categoryService.Update(categoryViewModelDTO);
        try
        {
            var item = _mapper.Map<Category>(categoryDTO);
            if (item == null)
            {
                return StatusCode(500);
            }
            _applicationDbContext.Category.Update(item);
            await _applicationDbContext.SaveChangesAsync();
            return StatusCode(200);


        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}
