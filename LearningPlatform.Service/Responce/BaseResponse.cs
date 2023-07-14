using LearningPlatform.Service.Enums;
using LearningPlatform.Service.Interfaces;

namespace LearningPlatform.Service.Response;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; }//описание ошибок

    public StatusCode StatusCode { get; set; }//номер ошибки

    public T? Data { get; set; } //запись результата ОБРАБОТКИ запроса из бд для передачи в контроллер. Используем дженерик, чтобы добавлять объект произвольного типа

}
