using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models;

public class JobTitle : BaseModel
{
    public string Title { get; set; }

    [Range(0,15,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public byte Grade { get; set; }
    public IList<Employee>? Employees { get; set; }
}
