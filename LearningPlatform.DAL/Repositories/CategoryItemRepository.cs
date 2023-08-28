using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DAL.Repositories;

public class CategoryItemRepository : ICategoryItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> Create(CategoryItem entity)
    {
        try
        {
            await _dbContext.CategoryItem.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Delete(CategoryItem entity)
    {
        try
        {
            _dbContext.CategoryItem.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch 
        {
            return false;
        }
    }

    public async Task<List<CategoryItem>> GetAll()
    {
        return await _dbContext.CategoryItem.ToListAsync();
    }

    public async Task<CategoryItem> GetByDescription(string description)
    {
        return await _dbContext.CategoryItem.FirstOrDefaultAsync(x => x.Description == description);
    }

    public async Task<CategoryItem> GetById(int id)
    {
        return await _dbContext.CategoryItem.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CategoryItem> GetByTitle(string title)
    {
        return await _dbContext.CategoryItem.FirstOrDefaultAsync(x => x.Title == title);
    }

    public async Task<bool> Update(CategoryItem entity)
    {
        try
        {
            _dbContext.CategoryItem.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        { 
            return false; 
        }
    }
}
