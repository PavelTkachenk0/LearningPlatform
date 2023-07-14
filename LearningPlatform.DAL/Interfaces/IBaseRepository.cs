using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> Create(T entity); 

    Task<T> GetById(int id);  

    Task<List<T>> GetAll(); 

    Task<T> GetByTitle(string title);

    Task<bool> Delete(T entity);

    Task<T> Update(T entity);
}
