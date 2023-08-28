using LearningPlatform.DAL.Models;

namespace LearningPlatform.Models;

public class UserDTO : BaseId
{
    public DateTime CreatedDate { get; set; }
    public int CategoryId { get; set; }
    public int CategoryItemId { get; set; }
    public int ContentId { get; set; }
    public int MediaTypeId { get; set; }
}
