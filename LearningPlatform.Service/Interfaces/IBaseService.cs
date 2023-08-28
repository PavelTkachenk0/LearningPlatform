namespace LearningPlatform.Service.Interfaces;

public interface IBaseService<T, M> 
{
    Task<IBaseResponse<IEnumerable<M>>> GetAll();
    Task<IBaseResponse<M>> GetById(int id);
    Task<IBaseResponse<M>> GetByTitle(string title);
    Task<IBaseResponse<bool>> Delete(int id);
    Task<IBaseResponse<T>> Create(M entity);
    Task<IBaseResponse<T>> Update(M entity);

}
