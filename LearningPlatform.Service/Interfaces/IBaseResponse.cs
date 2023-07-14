using LearningPlatform.Service.Enums;

namespace LearningPlatform.Service.Interfaces;

public interface IBaseResponse <T>
{
    StatusCode StatusCode { get; }
    T Data { get; set; }
}
