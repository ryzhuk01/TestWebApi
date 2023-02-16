using TestAPI.Models;

namespace TestAPI.Services.Interfaces;

public interface IJobTitleService
{
    public IList<JobTitle> GetJobTitles();
    public void CreateJobTitles(JobTitle jobTitle);
    public void DeleteJobTitleById(int id);
    public void UpdateJobTitle(JobTitle jobTitle);
}
