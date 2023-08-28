using LearningPlatform.Enums;

namespace LearningPlatform.Interfaces;

public interface IBaseResponse<T>
{
    StatusCode StatusCode { get; }
    T Data { get; set; }
}

