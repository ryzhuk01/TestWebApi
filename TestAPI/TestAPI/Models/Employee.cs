using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models;

public class Employee : BaseModel
{
    public string FullName { get; set; }

    [Range(typeof(DateTime), "01/01/1900", "01/01/2023")]
    public DateTime DateOfBirth { get; set; }
    public IList<JobTitle>? JobTitles { get; set; }
}
