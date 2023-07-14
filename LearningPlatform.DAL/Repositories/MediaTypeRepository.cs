using LearningPlatform.DAL.Interfaces;
using LearningPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DAL.Repositories;

public class MediaTypeRepository : IMediaTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MediaTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Create(MediaType entity)
    {
        try
        {
            await _dbContext.MediaType.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Delete(MediaType entity)
    {
        try
        {
            _dbContext.MediaType.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<MediaType>> GetAll()
    {
        return await _dbContext.MediaType.ToListAsync();  
    }

    public async Task<MediaType> GetById(int id)
    {
        return await _dbContext.MediaType.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<MediaType> GetByTitle(string title)
    {
        return await _dbContext.MediaType.FirstOrDefaultAsync(x => x.Title == title);
    }

    public async Task<bool> Update(MediaType entity)
    {
        _dbContext.MediaType.Update(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
