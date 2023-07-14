using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Repositories;

public class ContentRepository : IBaseRepository<Content>
{
    private readonly ApplicationDbContext _dbContext;

    public ContentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> Create(Content entity)
    {
        try
        {
            entity.CategoryItem = await _dbContext.CategoryItem.FindAsync(entity.CatItemId);
            await _dbContext.Content.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> Delete(Content entity)
    {
        try
        {
            _dbContext.Content.Remove(entity);
            await _dbContext.SaveChangesAsync();   
            return true;
        }
        catch 
        { 
            return false;
        }
    }

    public async Task<List<Content>> GetAll()
    {
        return await _dbContext.Content.ToListAsync();
    }

    public async Task<Content> GetById(int id)
    {
        return await _dbContext.Content.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Content> GetByTitle(string title)
    {
        return await _dbContext.Content.FirstOrDefaultAsync(x => x.Title == title);
    }

    public async Task<Content> Update(Content entity)
    {
        _dbContext.Content.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}
