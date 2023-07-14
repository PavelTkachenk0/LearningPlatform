using LearningPlatform.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Service.Interfaces;

public interface IBaseResponse <T>
{
    StatusCode StatusCode { get; }
    T Data { get; set; }
}
