using TestAPI.Data.Interfaces;
using TestAPI.Models;
using TestAPI.Services.Interfaces;

namespace TestAPI.Services;

public class JobTitleService : IJobTitleService
{
    public JobTitleService(IRepository<JobTitle> jobTitleRepository)
    {
        JobTitleRepository = jobTitleRepository;
    }
    private IRepository<JobTitle> JobTitleRepository { get; }

    public IList<JobTitle> GetJobTitles()
    {
        try
        {
            return JobTitleRepository.GetAll(d => d.Employees).ToList();
        }
        catch (Exception) { throw; }
    }
    public void CreateJobTitles(JobTitle jobTitle)
    {
        try
        {
            JobTitleRepository.Add(jobTitle);
            JobTitleRepository.SaveChanges();
        }
        catch (Exception) { throw; }
    }
    public void DeleteJobTitleById(int id)
    {
        try
        {
            var jobTitle = JobTitleRepository.GetById(id);

            if(jobTitle is null)
                throw new KeyNotFoundException(
                    "There is no JobTitle with such id");

            if (jobTitle.Employees is not null)
                JobTitleRepository.Delete(jobTitle);
            else
                throw new InvalidOperationException("You can't delete JobTitle that has connected employee");

            JobTitleRepository.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateJobTitle(JobTitle jobTitle)
    {
        try
        {
            JobTitleRepository.Update(jobTitle);
            JobTitleRepository.SaveChanges();
        }
        catch (Exception) { throw; }
    }
}
