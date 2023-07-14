using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> Create(Category entity)
    {
        try
        {
            await _dbContext.Category.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Delete(Category entity)
    {
        try
        {
            _dbContext.Category.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<Category>> GetAll()
    {
        return await _dbContext.Category.ToListAsync();
    }

    public async Task<Category> GetByDescription(string description)
    {
        return await _dbContext.Category.FirstOrDefaultAsync(x => x.Description == description);
    }

    public async Task<Category> GetById(int id)
    {
        return await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Category> GetByTitle(string title)
    {
        return await _dbContext.Category.FirstOrDefaultAsync(x => x.Title == title);
    }

    public async Task<Category> Update(Category entity)
    {
        _dbContext.Category.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}
