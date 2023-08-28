namespace LearningPlatform.Interfaces;

public interface IBaseService<T, M>
{
    Task<IBaseResponse<IEnumerable<M>>> GetAll();
    Task<IBaseResponse<M>> GetById(int id);
    Task<IBaseResponse<M>> GetByTitle(string title);
    Task<IBaseResponse<bool>> Delete(int id);
    Task<IBaseResponse<bool>> Create(T entity);
   // Task<IBaseResponse<bool>> Update(M entity);

}

